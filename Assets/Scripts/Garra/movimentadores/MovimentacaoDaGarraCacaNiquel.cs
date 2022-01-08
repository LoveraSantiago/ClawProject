public abstract class MovimentacaoDaGarraCacaNiquel : AbstractMovimentacaoDaGarra
{
    protected static ComunicadorComGerMovCacaNiquel comunicadorComGerMovimentacao;

    public static void configurarComunicadorComGerMovimentacao(ComunicadorComGerMovCacaNiquel comunicadorComGerMovimentacaoArg)
    {
        comunicadorComGerMovimentacao = comunicadorComGerMovimentacaoArg;
    }
}
