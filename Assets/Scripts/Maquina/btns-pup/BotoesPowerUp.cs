using UnityEngine;

public class BotoesPowerUp : AcaoBotaoPowerUpVazio.ProdutorEvento,
                             AcaoBBarItemEscolhido<PowerUpBtnInfo>.ConsumidorEvento,
                             AcaoColetado.ConsumidorEvento,
                             AcaoDesligarMaquinaResultado.ConsumidorEvento
{
    private BotaoPowerUp[] btnsPowerUp;    
    private BotaoPowerUp btnAcionado;
    private ControleAcionamentoPowerUp controlePup;

    private Draggavel dragavelAtual;
    private Draggavel dragavelVazio;

    public BotoesPowerUp(BotoesPowerUpDto btnsPowerUpsDto)
    {        
        BotaoPowerUp.configurar(btnsPowerUpsDto);
        inicializarBotoes(btnsPowerUpsDto);
        
        controlePup   = new ControleAcionamentoPowerUp();
        dragavelVazio = new AdapterDraggavelVazio();
        dragavelAtual = dragavelVazio;
    }

    private void inicializarBotoes(BotoesPowerUpDto btnsPowerUpsDto)
    {
        btnsPowerUp = new BotaoPowerUp[btnsPowerUpsDto.BtnPowerUpV2.Length];
        for(int contador = 0; contador < btnsPowerUp.Length; contador++)
        {
            btnsPowerUp[contador] = new BotaoPowerUp(contador, btnsPowerUpsDto);
        }        
    }

    public void configuradoPeloLevel(AbstractLevel level)
    {        
        new ColoridorBotoesV2().colorir(btnsPowerUp, level.getDicionarioDeCores());        
    }   
    
    public void update(BotoesPowerUpDto botoesPowerUpDto, InputGame inputGame)
    {
        if (inputGame.aconteceuTapNaAreaInferior())
        {
            Vector2 posicaoTap = inputGame.getPosicaoTap();
            for (int contador = 0; contador < btnsPowerUp.Length; contador++)
            {
                if (btnsPowerUp[contador].isCliqueValido(controlePup, posicaoTap))
                {
                    acionarBotao(contador, botoesPowerUpDto);
                    break;
                }
            }
        }           
    }

    public void beginDrag(Vector2 posicaoDrag)
    {
        //Debug.Log("begindrag");
        if (controlePup.podeAcionarPupDraggavel())
        {
            dragavelAtual = dragavelVazio;
            for (int contador = 0; contador < btnsPowerUp.Length; contador++)
            {
                if (btnsPowerUp[contador].isDragValido(posicaoDrag))
                {
                    dragavelAtual = btnsPowerUp[contador];                   
                    btnAcionado = btnsPowerUp[contador];
                    break;
                }
            }
            dragavelAtual.prepararDraggagem(posicaoDrag);
        }
    }

    public void drag(Vector2 delta, BotoesPowerUpDto botoesPowerUpDto)
    {
        if (controlePup.podeAcionarPupDraggavel())
        {
            dragavelAtual.updateDrag(delta, botoesPowerUpDto);
        }
    }

    public void endDrag(BotoesPowerUpDto botoesPowerUpDto)
    {
        if (controlePup.podeAcionarPupDraggavel())
        {
            bool result = dragavelAtual.isDragFinalizadoAtivouPowerUp(botoesPowerUpDto);            
            if (result)
            {
                draggarBotao(btnAcionado);
            }
            dragavelAtual = dragavelVazio;
        }
    }

    public void processarFimPowerUp()
    {
        controlePup.habilitarPowerUp();
        btnAcionado.desclicar();        
    }

    public void desativarPowerUp()
    {
        controlePup.desabilitarPowerUp();        
    }    

    public void reativarPowerUp()
    {
        controlePup.habilitarPowerUp();
    }

    public void reativarPowerUpPosDisplay()
    {
        //Debug.Log("Reativado btns pup pos display");
        controlePup.habilitarPowerUpPosDisplay();
    }

    private void acionarBotao(int indice, BotoesPowerUpDto btnsPowerUpsDto)
    {   
        BotaoPowerUp btn = btnsPowerUp[indice];
        btn.clicar(btnsPowerUpsDto, controlePup);
        btnAcionado = btn;
    }       

    private void draggarBotao(BotaoPowerUp btn)
    {   
        btn.draggar(controlePup);
        btnAcionado = btn;
    }   

    private void devolverPowerUps()
    {
        for(int contador = 0; contador < btnsPowerUp.Length; contador++)
        {
            btnsPowerUp[contador].devolverPowerUp();
        }        
    }

    void AcaoBBarItemEscolhido<PowerUpBtnInfo>.ConsumidorEvento.consumirEvento(PowerUpBtnInfo evento)
    {        
        btnsPowerUp[evento.indiceBotao].receberAcaoPowerUp(evento, controlePup);
    }

    void AcaoColetado.ConsumidorEvento.consumirEvento(InformacoesColetadoDto evento)
    {
        controlePup.suspenderPowerUp();
        if (evento.infosFimDeJogo.fimColetados)
        {
            devolverPowerUps();
        }
    }   

    ProdutorDeEvento<int> AcaoBotaoPowerUpVazio.ProdutorEvento.getProdutorDeEvento()
    {
        return controlePup.produtorDeEventoEscolhaPup;
    }

    void AcaoDesligarMaquinaResultado.ConsumidorEvento.consumirEvento(ResultadoDesligarMaquinaDto evento)
    {
        if (evento.resultadoSair && evento.isGameLevel)
        {
            devolverPowerUps();
        }
    }
}
