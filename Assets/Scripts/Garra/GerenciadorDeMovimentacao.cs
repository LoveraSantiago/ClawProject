using UnityEngine;

public class GerenciadorDeMovimentacao : CommunicatorComGarra
{
    private Vector2 posicaoInicial;

    private MovimentacaoDaGarra movimentacaoAtual;
    private MovimentacaoDaGarra movimentacaoParaBaixo;
    private MovimentacaoDaGarra movimentacaoAgarrando;
    private MovimentacaoParaCima movimentacaoParaCima;
    private MovimentacaoDaGarra movimentacaoLateral;

    public GerenciadorDeMovimentacao(ComponentesDaGarraDto componentesDaGarraDto)
    {
        MovimentacaoDaGarra.configurarComponentesDaGarraDto(componentesDaGarraDto);
        MovimentacaoDaGarra.configurarCommunicatorComGarra(this);

        movimentacaoLateral   = new MovimentacaoLateral();
        movimentacaoParaCima  = new MovimentacaoParaCima();
        movimentacaoParaBaixo = new MovimentacaoParaBaixo(null);
        movimentacaoAgarrando = new MovimentacaoAgarrando();
        movimentacaoAtual = movimentacaoLateral;
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
