public class GerenciadorDeMovimentacaoCacaNiquel : GerenciadorDeMovimentacao,
                                                   ComunicadorComGerMovCacaNiquel
{
    private AbstractMovimentacaoDaGarra movParado;
    private AbstractMovimentacaoDaGarra movIrCacaNiquel;
    private AbstractMovimentacaoDaGarra movAtual;

    public GerenciadorDeMovimentacaoCacaNiquel()
    {
        MovimentacaoDaGarraCacaNiquel.configurarComunicadorComGerMovimentacao(this);
        movParado = new MovimentacaoParadoNormal();
        movIrCacaNiquel = new MovimentacaoIrParaCacaNiquel();
        movAtual = movParado;
    }

    public override void iniciarMovimentacoes()
    {
        movAtual = movIrCacaNiquel;
    }

    public override void update(InputGame inputGame)
    {
        movAtual.update(inputGame);
    }

    public override void fixedUpdate()
    {
        movAtual.fixedUpdate();
    }

    public override void garraComemorar()
    {
        movAtual.playAnimacaoGirando();
    }

    public void trocarParaAcaoParado()
    {
        movAtual = movParado;
        movAtual.preInicio();
    }

    public override int getContagemDeSubidas()
    {
        return movAtual.getContagemDeSubidas();
    }

    public override ProdutorDeEvento<Direcao> getProdutorDeEvento()
    {
        return ((AcaoSincroniaComDirecaoDaGarra.ProdutorEvento)movAtual).getProdutorDeEvento();
    }
}
