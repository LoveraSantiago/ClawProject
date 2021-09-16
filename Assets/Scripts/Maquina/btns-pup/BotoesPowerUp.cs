using UnityEngine;

public class BotoesPowerUp : AcaoBotaoPUpVazio.ProdutorEvento,
                             AcaoBBarPupEscolhido<PowerUpBtnInfo>.ConsumidorEvento
{
    private BotaoPowerUp[] btnsPowerUp;    
    private BotaoPowerUp btnAcionado;

    private ProdutorDeEvento<int> produtorDeEventoEscolhaPup;
    private ControleAcionamentoPowerUp controlePup;

    private Draggavel dragavelAtual;
    private Draggavel dragavelVazio;

    public BotoesPowerUp(BotoesPowerUpDto btnsPowerUpsDto)
    {        
        BotaoPowerUp.configurar(btnsPowerUpsDto);
        inicializarBotoes(btnsPowerUpsDto);
        produtorDeEventoEscolhaPup = new ProdutorDeEvento<int>();
        controlePup   = new ControleAcionamentoPowerUp();
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
        new ColoridorBotoes().colorir(btnsPowerUp, level.getDicionarioDeCores());        
    }

    public ArcoIrisConjunto getBotoesGlow()
    {
        return new BotoesPowerUpArcoIris(btnsPowerUp);
    }
    
    public void update(InputGame inputGame)
    {
        if (inputGame.aconteceuTapNaAreaInferior())
        {
            Vector2 posicaoTap = inputGame.getPosicaoTap();
            for (int contador = 0; contador < btnsPowerUp.Length; contador++)
            {
                if (btnsPowerUp[contador].isCliqueValido(controlePup, posicaoTap))
                {
                    acionarBotao(contador);
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

    public void drag(Vector2 delta)
    {
        if (controlePup.podeAcionarPupDraggavel())
        {
            dragavelAtual.updateDrag(delta);
        }
    }

    public void endDrag()
    {
        if (controlePup.podeAcionarPupDraggavel())
        {
            bool result = dragavelAtual.isDragFinalizadoAtivouPowerUp();            
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

    public void suspenderPowerUp()
    {
        controlePup.suspenderPowerUp();
    }

    public void reativarPowerUp()
    {
        controlePup.habilitarPowerUp();
    }

    public void reativarPowerUpPosDisplay()
    {
        controlePup.habilitarPowerUpPosDisplay();
    }

    private void acionarBotao(int indice)
    {
        colocarBtnsEmMaterialArcoIris();
        BotaoPowerUp btn = btnsPowerUp[indice];
        btn.clicar(controlePup, produtorDeEventoEscolhaPup, indice);
        btnAcionado = btn;
    }   

    private void colocarBtnsEmMaterialArcoIris()
    {
        for (int contador = 0; contador < btnsPowerUp.Length; contador++)
        {
            btnsPowerUp[contador].mudarParaMaterialArcoIris();
        }
    }

    private void draggarBotao(BotaoPowerUp btn)
    {
        colocarBtnsEmMaterialArcoIris();
        btn.draggar(controlePup);
        btnAcionado = btn;
    }   

    void AcaoBBarPupEscolhido<PowerUpBtnInfo>.ConsumidorEvento.consumirEvento(PowerUpBtnInfo evento)
    {        
        btnsPowerUp[evento.indiceBotao].receberAcaoPowerUp(controlePup, evento.powerUpEntidade);
    }

    ProdutorDeEvento<int> AcaoBotaoPUpVazio.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEventoEscolhaPup;
    }   
}
