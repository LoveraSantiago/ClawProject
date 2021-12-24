using UnityEngine;

public class BotoesPowerUp : AcaoBotaoPUpVazio.ProdutorEvento,
                             AcaoBBarItemEscolhido<PowerUpBtnInfo>.ConsumidorEvento,
                             AcaoColetado.ConsumidorEvento
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
        btnsPowerUp[0] = new BotaoPowerUp(0, btnsPowerUpsDto);
        btnsPowerUp[1] = new BotaoPowerUp(1, btnsPowerUpsDto);
        btnsPowerUp[2] = new BotaoPowerUp(2, btnsPowerUpsDto);
        btnsPowerUp[3] = new BotaoPowerUp(3, btnsPowerUpsDto);
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

    public void reativarPowerUp()
    {
        controlePup.habilitarPowerUp();
    }

    public void reativarPowerUpPosDisplay()
    {
        //Debug.Log("Reativado btns pup pos display");
        controlePup.habilitarPowerUpPosDisplay();
    }

    private void acionarBotao(int indice)
    {
        colocarBtnsEmMaterialArcoIris();
        BotaoPowerUp btn = btnsPowerUp[indice];
        btn.clicar(controlePup, produtorDeEventoEscolhaPup);
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

    void AcaoBBarItemEscolhido<PowerUpBtnInfo>.ConsumidorEvento.consumirEvento(PowerUpBtnInfo evento)
    {        
        btnsPowerUp[evento.indiceBotao].receberAcaoPowerUp(evento, controlePup);
    }

    void ProdutorConsumidoresDeEvento<InformacoesColetadoDto>.ConsumidorEvento.consumirEvento(InformacoesColetadoDto evento)
    {
        controlePup.suspenderPowerUp();
        if (evento.infosFimDeJogo.fimColetados)
        {
            btnsPowerUp[0].devolverPowerUp();
            btnsPowerUp[1].devolverPowerUp();
            btnsPowerUp[2].devolverPowerUp();
            btnsPowerUp[3].devolverPowerUp();
        }
    }

    ProdutorDeEvento<int> AcaoBotaoPUpVazio.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEventoEscolhaPup;
    }   
}
