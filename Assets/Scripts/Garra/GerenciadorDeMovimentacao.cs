using UnityEngine;

public class GerenciadorDeMovimentacao : ComunicadorComGerMovimentacao
{
    private Vector2 posicaoInicial;

    private MovimentacaoDaGarra movimentacaoAtual;
    private MovimentacaoParaBaixo movimentacaoParaBaixo;
    private MovimentacaoDaGarra movimentacaoAgarrando;
    private MovimentacaoParaCima movimentacaoParaCima;
    private MovimentacaoDaGarraHorizontal movimentacaoLateral;

    public GerenciadorDeMovimentacao(ComponentesDaGarraDto componentesDaGarraDto, 
        GarraManager.MECANICA_GARRA mecanicaGarraEscolhida, InputGame inputGame)
    {
        MovimentacaoDaGarra.configurarComponentesMovimentacaoGarra(componentesDaGarraDto, this, inputGame);        

        movimentacaoLateral = selecionarMecanicaHorizontal(mecanicaGarraEscolhida);
        movimentacaoParaCima = new MovimentacaoParaCima();
        movimentacaoParaBaixo = new MovimentacaoParaBaixo();
        movimentacaoAgarrando = new MovimentacaoAgarrando();
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
    public void trocarParaAcaoDescendo(Vector2 posicaoInicial)
    {
        AudioController.current.PlayAudioGarra();
        this.posicaoInicial = posicaoInicial;
        trocarMovimentador(movimentacaoParaBaixo);
    }

    public void trocarParaAcaoSubindo()
    {
        movimentacaoParaCima.setPosicalInicialDeReferencia(posicaoInicial);
        trocarMovimentador(movimentacaoParaCima);
    }

    public void trocarParaAcaoNormal()
    {
        AudioController.current.StopAudioGarra();
        trocarMovimentador(movimentacaoLateral);
    }

    public void trocarParaAgarrada()
    {
        trocarMovimentador(movimentacaoAgarrando);
    }

    private void trocarMovimentador(MovimentacaoDaGarra movimentador)
    {
        movimentador.preInicio();
        movimentacaoAtual = movimentador;
    }
    //IMPLEMENTACAO INTERFACE COMMUNICATORCOMGARRA FIM

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
