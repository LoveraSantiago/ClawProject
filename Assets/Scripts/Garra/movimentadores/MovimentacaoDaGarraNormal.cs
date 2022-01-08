public abstract class MovimentacaoDaGarraNormal : AbstractMovimentacaoDaGarra
{
    protected static ComunicadorComGerMovNormal comunicadorComGerMovimentacao;

    public static void configurarComunicadorComGerMovimentacao(ComunicadorComGerMovNormal comunicadorComGerMovimentacaoArg)
    {
        comunicadorComGerMovimentacao = comunicadorComGerMovimentacaoArg;
    }
}
