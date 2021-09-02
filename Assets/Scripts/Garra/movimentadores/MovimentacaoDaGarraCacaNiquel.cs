public abstract class MovimentacaoDaGarraCacaNiquel : MovimentacaoDaGarra
{
    protected static ComunicadorComGerMovCacaNiquel comunicadorComGerMovimentacao;

    public static void configurarComunicadorComGerMovimentacao(ComunicadorComGerMovCacaNiquel comunicadorComGerMovimentacaoArg)
    {
        comunicadorComGerMovimentacao = comunicadorComGerMovimentacaoArg;
    }
}
