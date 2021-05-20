using UnityEngine;
using System.Collections.Generic;

public class BotoesPowerUp 
{
    private bool acionadoPowerUp;

    private BotaoPowerUp[] btnsPowerUp;    
    private BotaoPowerUp btnAcionado;
    private DistribuidorParaBotoesPowerUp distribuidor;

    private Draggavel dragavelAtual;
    private Draggavel dragavelVazio;

    private InputGame inputGame;        

    public BotoesPowerUp(BotoesPowerUpDto btnsPowerUpsDto, InputGame inputGame)
    {
        this.inputGame = inputGame;       

        BotaoPowerUp.configurar(btnsPowerUpsDto.BordasBtns, btnsPowerUpsDto.AreaDraggavel);

        inicializarBotoes(btnsPowerUpsDto);
        distribuidor = new DistribuidorParaBotoesPowerUp(btnsPowerUp, btnsPowerUpsDto.SpritesDeBotoes);

        dragavelVazio = new AdapterDraggavelVazio();
        dragavelAtual = dragavelVazio;
    }

    private void inicializarBotoes(BotoesPowerUpDto btnsPowerUpsDto)
    {
        btnsPowerUp = new BotaoPowerUp[4];
        btnsPowerUp[0] = new BotaoPowerUp(btnsPowerUpsDto.BtnPowerUp[0]);
        btnsPowerUp[1] = new BotaoPowerUp(btnsPowerUpsDto.BtnPowerUp[1]);
        btnsPowerUp[2] = new BotaoPowerUp(btnsPowerUpsDto.BtnPowerUp[2]);
        btnsPowerUp[3] = new BotaoPowerUp(btnsPowerUpsDto.BtnPowerUp[3]);
    }

    public void configuradoPeloLevel(AbstractLevel level)
    {
        distribuidor.distribuirArray(level.getPowerUpsParaBotoesMaquina());

        Dictionary<string, string> dicionarioDeCores = level.getDicionarioDeCores();

        string hexBotao = dicionarioDeCores[ConstantesCoresMaquina.BTN_POWERUP_1];
        string hexDentro = dicionarioDeCores[ConstantesCoresMaquina.BTN_PARTEDENTRO_1];
        string hexContorno = dicionarioDeCores[ConstantesCoresMaquina.BTN_CONTORNO_1];
        btnsPowerUp[0].receberCorLevel(hexBotao, hexDentro, hexContorno);

        hexBotao = dicionarioDeCores[ConstantesCoresMaquina.BTN_POWERUP_2];
        hexDentro = dicionarioDeCores[ConstantesCoresMaquina.BTN_PARTEDENTRO_2];
        hexContorno = dicionarioDeCores[ConstantesCoresMaquina.BTN_CONTORNO_2];
        btnsPowerUp[1].receberCorLevel(hexBotao, hexDentro, hexContorno);

        hexBotao = dicionarioDeCores[ConstantesCoresMaquina.BTN_POWERUP_3];
        hexDentro = dicionarioDeCores[ConstantesCoresMaquina.BTN_PARTEDENTRO_3];
        hexContorno = dicionarioDeCores[ConstantesCoresMaquina.BTN_CONTORNO_3];
        btnsPowerUp[2].receberCorLevel(hexBotao, hexDentro, hexContorno);

        hexBotao = dicionarioDeCores[ConstantesCoresMaquina.BTN_POWERUP_4];
        hexDentro = dicionarioDeCores[ConstantesCoresMaquina.BTN_PARTEDENTRO_4];
        hexContorno = dicionarioDeCores[ConstantesCoresMaquina.BTN_CONTORNO_4];
        btnsPowerUp[3].receberCorLevel(hexBotao, hexDentro, hexContorno);
    }
    
    public void update()
    {
        if (!acionadoPowerUp && inputGame.aconteceuTapNaAreaInferior())
        {
            Vector2 posicaoTap = inputGame.getPosicaoTap();
            if (btnsPowerUp[0].isCliqueValido(posicaoTap))
            {
                acionarBotao(btnsPowerUp[0]);                
            }
            else if (btnsPowerUp[1].isCliqueValido(posicaoTap))
            {
                acionarBotao(btnsPowerUp[1]);
            }
            else if (btnsPowerUp[2].isCliqueValido(posicaoTap))
            {
                acionarBotao(btnsPowerUp[2]);
            }
            else if (btnsPowerUp[3].isCliqueValido(posicaoTap))
            {
                acionarBotao(btnsPowerUp[3]);
            }
        }        
    }

    private void acionarBotao(BotaoPowerUp btn)
    {
        btn.clicar();
        acionadoPowerUp = true;
        btnAcionado = btn;
    }

    private void draggarBotao(BotaoPowerUp btn)
    {
        btn.draggar();
        acionadoPowerUp = true;
        btnAcionado = btn;
    }

    public void acionarFimPowerUp()
    {
        acionadoPowerUp = false;
        btnAcionado.desclicar();
        distribuidor.distribuirProxItem();
    }   

    public void beginDrag(Vector2 posicaoDrag)
    {
        //Debug.Log("begindrag");
        if (!acionadoPowerUp)
        {
            if (btnsPowerUp[0].isDragValido(posicaoDrag))
            {   
                dragavelAtual = btnsPowerUp[0];
                btnAcionado = btnsPowerUp[0];
            }
            else if (btnsPowerUp[1].isDragValido(posicaoDrag))
            {            
                dragavelAtual = btnsPowerUp[1];
                btnAcionado = btnsPowerUp[1];
            }
            else if (btnsPowerUp[2].isDragValido(posicaoDrag))
            {            
                dragavelAtual = btnsPowerUp[2];
                btnAcionado = btnsPowerUp[2];
            }
            else if (btnsPowerUp[3].isDragValido(posicaoDrag))
            {            
                dragavelAtual = btnsPowerUp[3];
                btnAcionado = btnsPowerUp[3];
            }
            else
            {
                dragavelAtual = dragavelVazio;
            }
            dragavelAtual.prepararDraggagem(posicaoDrag);
        }
    }

    public void drag(Vector2 delta)
    {
        if (!acionadoPowerUp)
        {
            dragavelAtual.updateDrag(delta);
        }
    }

    public void endDrag(MonoBehaviour monoBehaviour)
    {
        if (!acionadoPowerUp)
        {
            bool result = dragavelAtual.isDragFinalizadoAtivouPowerUp(monoBehaviour);
            acionadoPowerUp = result;
            if (result)
            {
                draggarBotao(btnAcionado);
            }

            dragavelAtual = dragavelVazio;
        }
    }   
}
