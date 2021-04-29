public abstract class MovimentacaoDaGarraPowerUp : MovimentacaoDaGarra
{
    protected static ComunicadorComGerMovPowerUp comunicadorComGerMovimentacao;

    public static void configurarComunicadorComGerMovimentacao(ComunicadorComGerMovPowerUp comunicadorComGerMovimentacaoArg)
    {
        comunicadorComGerMovimentacao = comunicadorComGerMovimentacaoArg;
    }
}
