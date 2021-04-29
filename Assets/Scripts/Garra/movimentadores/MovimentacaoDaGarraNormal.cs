public abstract class MovimentacaoDaGarraNormal : MovimentacaoDaGarra
{
    protected static ComunicadorComGerMovimentacao comunicadorComGerMovimentacao;

    public static void configurarComunicadorComGerMovimentacao(ComunicadorComGerMovimentacao comunicadorComGerMovimentacaoArg)
    {
        comunicadorComGerMovimentacao = comunicadorComGerMovimentacaoArg;
    }
}
