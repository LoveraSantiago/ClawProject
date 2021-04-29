public abstract class MovimentacaoDaGarraNormal : MovimentacaoDaGarra
{
    protected static ComunicadorComGerMovNormal comunicadorComGerMovimentacao;

    public static void configurarComunicadorComGerMovimentacao(ComunicadorComGerMovNormal comunicadorComGerMovimentacaoArg)
    {
        comunicadorComGerMovimentacao = comunicadorComGerMovimentacaoArg;
    }
}
