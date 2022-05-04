using UnityEngine;

public class BotoesPowerUp : Draggavel,
                             AcaoBotaoPowerUpVazio.ProdutorEvento,
                             //AcaoBBarItemEscolhido<PowerUpBtnInfo>.ConsumidorEvento,
                             AcaoColetado.ConsumidorEvento,
                             AcaoDesligarMaquinaResultado.ConsumidorEvento,
                             AcaoTempoEsgotado.ConsumidorEvento,
                             AcaoColetadoFim.ConsumidorEvento
{
    private BotaoPowerUp[] btnsPowerUp;    
    private BotaoPowerUp btnAcionado;
    private ControleAcionamentoPowerUp  controleAcionamentoPup;    

    private BotaoDraggavel btnDragavelAtual;
    private BotaoDraggavel btnDragavelVazio;

    public BotoesPowerUp(BotoesPowerUpDto btnsPowerUpsDto)
    {        
        BotaoPowerUp.configurar(btnsPowerUpsDto);
        inicializarBotoes(btnsPowerUpsDto);
        
        controleAcionamentoPup  = new ControleAcionamentoPowerUp();        
        btnDragavelVazio = new AdapterBotaoDraggavelVazio();
        btnDragavelAtual = btnDragavelVazio;
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
                if (btnsPowerUp[contador].isCliqueValido(controleAcionamentoPup, posicaoTap))
                {
                    acionarBotao(contador, botoesPowerUpDto);
                    break;
                }
            }
        }           
    }

    public bool isDragAcionavel(Vector2 posicaoDrag)
    {
        if (controleAcionamentoPup.podeAcionarPupDraggavel())
        {
            btnDragavelAtual = btnDragavelVazio;
            for (int contador = 0; contador < btnsPowerUp.Length; contador++)
            {
                if (btnsPowerUp[contador].isDragValido(posicaoDrag))
                {
                    btnDragavelAtual = btnsPowerUp[contador];
                    btnAcionado = btnsPowerUp[contador];
                    break;
                }
            }
        }
        return btnDragavelAtual != btnDragavelVazio;
    }

    public bool foiDragAcionado()
    {
        return btnDragavelAtual != btnDragavelVazio && controleAcionamentoPup.podeAcionarPupDraggavel(); 
    }

    public void onBeginDrag(Vector3 posicao)
    {
        btnDragavelAtual.prepararDraggagem(posicao);        
    }

    public void onDrag(Vector2 delta, MaquinaDto maquinaDto)
    {
        btnDragavelAtual.updateDrag(delta, maquinaDto.BotoesPowerUpDto);
    }

    public void onEndDrag(MaquinaDto maquinaDto)
    {
        bool result = btnDragavelAtual.isDragFinalizadoAtivouPowerUp(maquinaDto.BotoesPowerUpDto);
        if (result)
        {
            draggarBotao(btnAcionado);
        }
        btnDragavelAtual = btnDragavelVazio;
    }

    //public void beginDrag(Vector2 posicaoDrag)
    //{
    //    //Debug.Log("begindrag");
    //    if (controlePup.podeAcionarPupDraggavel())
    //    {
    //        btnDragavelAtual = btnDragavelVazio;
    //        for (int contador = 0; contador < btnsPowerUp.Length; contador++)
    //        {
    //            if (btnsPowerUp[contador].isDragValido(posicaoDrag))
    //            {
    //                btnDragavelAtual = btnsPowerUp[contador];                   
    //                btnAcionado = btnsPowerUp[contador];
    //                break;
    //            }
    //        }
    //        btnDragavelAtual.prepararDraggagem(posicaoDrag);
    //    }
    //}

    //public void drag(Vector2 delta, BotoesPowerUpDto botoesPowerUpDto)
    //{
    //    if (controlePup.podeAcionarPupDraggavel())
    //    {
    //        btnDragavelAtual.updateDrag(delta, botoesPowerUpDto);
    //    }
    //}

    //public void endDrag(BotoesPowerUpDto botoesPowerUpDto)
    //{
    //    if (controlePup.podeAcionarPupDraggavel())
    //    {
    //        bool result = btnDragavelAtual.isDragFinalizadoAtivouPowerUp(botoesPowerUpDto);            
    //        if (result)
    //        {
    //            draggarBotao(btnAcionado);
    //        }
    //        btnDragavelAtual = btnDragavelVazio;
    //    }
    //}

    public void processarFimPowerUp()
    {
        controleAcionamentoPup.habilitarPowerUp();
        btnAcionado.desclicar();        
    }

    public void desativarPowerUp()
    {
        controleAcionamentoPup.desabilitarPowerUp();        
    }    

    public void reativarPowerUp()
    {
        controleAcionamentoPup.habilitarPowerUp();
    }

    public void reativarPowerUpPosDisplay()
    {
        //Debug.Log("Reativado btns pup pos display");
        controleAcionamentoPup.habilitarPowerUpPosDisplay();
    }

    private void acionarBotao(int indice, BotoesPowerUpDto btnsPowerUpsDto)
    {   
        BotaoPowerUp btn = btnsPowerUp[indice];
        btn.clicar(btnsPowerUpsDto, controleAcionamentoPup);
        btnAcionado = btn;
    }       

    private void draggarBotao(BotaoPowerUp btn)
    {   
        btn.draggar(controleAcionamentoPup);
        btnAcionado = btn;
    }   

    private void devolverPowerUps()
    {
        for(int contador = 0; contador < btnsPowerUp.Length; contador++)
        {
            btnsPowerUp[contador].devolverPowerUp();
        }        
    }

    //void AcaoBBarItemEscolhido<PowerUpBtnInfo>.ConsumidorEvento.consumirEvento(PowerUpBtnInfo evento)
    //{        
    //    btnsPowerUp[evento.indiceBotao].receberAcaoPowerUp(evento, controleAcionamentoPup);
    //}

    void AcaoColetado.ConsumidorEvento.consumirEvento(InformacoesColetadoDto evento)
    {
        controleAcionamentoPup.suspenderPowerUp();
        if (evento.infosFimDeJogo.fimColetados)
        {
            devolverPowerUps();
        }
    }   

    ProdutorDeEvento<int> AcaoBotaoPowerUpVazio.ProdutorEvento.getProdutorDeEvento()
    {
        return controleAcionamentoPup.produtorDeEventoEscolhaPup;
    }

    void AcaoDesligarMaquinaResultado.ConsumidorEvento.consumirEvento(ResultadoDesligarMaquinaDto evento)
    {
        if (evento.resultadoSair && evento.isGameLevel)
        {
            devolverPowerUps();
        }
    }

    void AcaoTempoEsgotado.ConsumidorEvento.consumirEvento(TempoEsgotadoDto evento)
    {
        desativarPowerUp();
    }

    void AcaoColetadoFim.ConsumidorEvento.consumirEvento(ColetadoFimDto evento)
    {
        reativarPowerUpPosDisplay();
    }
}
