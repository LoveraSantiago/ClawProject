public class GerenciadorDeMovimentacaoCacaNiquel : GerenciadorDeMovimentacao,
                                                   ComunicadorComGerMovCacaNiquel
{
    private MovimentacaoDaGarra movParado;
    private MovimentacaoDaGarra movIrCacaNiquel;
    private MovimentacaoDaGarra movAtual;

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
        
    }

    public void trocarParaAcaoParado()
    {
        movAtual = movParado;
        movAtual.preInicio();
    }
}
