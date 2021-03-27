using UnityEngine;

public class GerenciadorDeMovimentacao : ComunicadorComGerMovimentacao
{
    private Vector2 posicaoInicial;

    private MovimentacaoDaGarra movimentacaoAtual;
    private MovimentacaoDaGarra movimentacaoParaBaixo;
    private MovimentacaoDaGarra movimentacaoAgarrando;
    private MovimentacaoParaCima movimentacaoParaCima;
    private MovimentacaoDaGarra movimentacaoLateral;

    public GerenciadorDeMovimentacao(ComponentesDaGarraDto componentesDaGarraDto, 
        Garra.MECANICA_GARRA mecanicaGarraEscolhida)
    {
        MovimentacaoDaGarra.configurarComponentesDaGarraDto(componentesDaGarraDto);
        MovimentacaoDaGarra.configurarCommunicatorComGarra(this);

        movimentacaoLateral = selecionarMecanicaHorizontal(mecanicaGarraEscolhida);
        movimentacaoParaCima  = new MovimentacaoParaCima();
        movimentacaoParaBaixo = new MovimentacaoParaBaixo();
        movimentacaoAgarrando = new MovimentacaoAgarrando();
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

    private MovimentacaoDaGarra selecionarMecanicaHorizontal(Garra.MECANICA_GARRA mecanicaGarraEscolhida)
    {
        switch (mecanicaGarraEscolhida)
        {
            case (Garra.MECANICA_GARRA.ZIG_ZAG):
                return new MovimentacaoLateralZigZag();

            case (Garra.MECANICA_GARRA.TELEGUIADA):
                return new MovimentacaoLateralTeleguiada();

            case (Garra.MECANICA_GARRA.ZIG_ZAGTELEGUIADO):
                return new MovimentacaoLateralZigTeleguiado();

        }
        return new MovimentacaoLateralZigZag();
    }

    //IMPLEMENTACAO INTERFACE COMMUNICATORCOMGARRA INICIO
    public void trocarParaAcaoDescendo(Vector2 posicaoInicial)
    {
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

}
