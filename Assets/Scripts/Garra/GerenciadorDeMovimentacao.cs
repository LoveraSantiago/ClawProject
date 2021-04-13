using UnityEngine;

public class GerenciadorDeMovimentacao : ComunicadorComGerMovimentacao
{
    private MovimentacaoDaGarra movimentacaoAtual;
    private MovimentacaoParaBaixo movimentacaoParaBaixo;
    private MovimentacaoDaGarra movimentacaoSegBaixo;
    private MovimentacaoParaCima movimentacaoParaCima;
    private MovimentacaoDaGarraHorizontal movimentacaoLateral;
    private MovimentacaoDaGarra movimentacaoSegCima;

    public GerenciadorDeMovimentacao(ComponentesDaGarraDto componentesDaGarraDto, 
        GarraManager.MECANICA_GARRA mecanicaGarraEscolhida, InputGame inputGame)
    {
        MovimentacaoDaGarra.configurarComponentesMovimentacaoGarra(componentesDaGarraDto, this, inputGame);        

        movimentacaoLateral   = selecionarMecanicaHorizontal(mecanicaGarraEscolhida);
        movimentacaoParaCima  = new MovimentacaoParaCima();
        movimentacaoParaBaixo = new MovimentacaoParaBaixo();
        movimentacaoSegBaixo  = new MovimentacaoAgarrandoEmbaixo();
        movimentacaoSegCima   = new MovimentacaoAgarrandoEmcima();
    }

    public void iniciarMovimentacoes()
    {
        trocarMovimentador(movimentacaoLateral);
    }

    public void update()
    {
        movimentacaoAtual.update();
    }

    public void fixedUpdate()
    {
        movimentacaoAtual.fixedUpdate();
    }

    public void garraColidiuCom(Collider2D other)
    {
        movimentacaoAtual.garraColidiuCom(other.gameObject);
    }

    private MovimentacaoDaGarraHorizontal selecionarMecanicaHorizontal(GarraManager.MECANICA_GARRA mecanicaGarraEscolhida)
    {
        switch (mecanicaGarraEscolhida)
        {
            case (GarraManager.MECANICA_GARRA.ZIG_ZAG):
                return new MovimentacaoLateralZigZag();

            case (GarraManager.MECANICA_GARRA.TELEGUIADA):
                return new MovimentacaoLateralTeleguiada();

            case (GarraManager.MECANICA_GARRA.ZIG_ZAGTELEGUIADO):
                return new MovimentacaoLateralZigTeleguiado();

        }
        return new MovimentacaoLateralZigZag();
    }

    //IMPLEMENTACAO INTERFACE COMMUNICATORCOMGARRA INICIO    
    public void trocarParaAcaoDescendo()
    {
        AudioController.current.PlayAudioGarra();        
        trocarMovimentador(movimentacaoParaBaixo);
    }

    public void trocarParaAcaoSubindo()
    {        
        trocarMovimentador(movimentacaoParaCima);
    }

    public void trocarParaAcaoNormal()
    {
        AudioController.current.StopAudioGarra();
        trocarMovimentador(movimentacaoLateral);
    }

    public void trocarParaAcaoAgarrada()
    {
        trocarMovimentador(movimentacaoSegBaixo);
    }

    public void trocarParaAcaoSegurando()
    {
        trocarMovimentador(movimentacaoSegCima);
    }
    //IMPLEMENTACAO INTERFACE COMMUNICATORCOMGARRA FIM

    private void trocarMovimentador(MovimentacaoDaGarra movimentador)
    {
        movimentador.preInicio();
        movimentacaoAtual = movimentador;
    }

    public ProdutorDeEvento<DirecaoDaGarra> getDisparadorDeEventoDeDirecao()
    {
        return MovimentacaoDaGarraHorizontal.produtorEventoDirecao;
    }

    public ProdutorDeEvento<string> getProdutorDeEventoTocadoPelaGarra()
    {
        return movimentacaoParaBaixo.produtorEventoGarraAcertou;
    }

    public ProdutorDeEvento<int> getProdutorDeEventoSubidaDaGarra()
    {
        return movimentacaoParaCima.produtorDeEventoSubidaDaGarra;
    }

}
