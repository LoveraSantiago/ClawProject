public abstract class MovimentacaoDaGarraPowerUp : MovimentacaoDaGarra
{
    protected static ComunicadorComGerMovPowerUp comunicadorComGerMovimentacao;
    protected static GarraInteracaoComPowerUp garraInteracaoComPowerUp;

    public static void configurarComunicadorComGerMovimentacao(ComunicadorComGerMovPowerUp comunicadorComGerMovimentacaoArg)
    {
        comunicadorComGerMovimentacao = comunicadorComGerMovimentacaoArg;
    }

    public static void receberInteracaoComPowerUp(GarraInteracaoComPowerUp garraInteracaoComPowerUpArg)
    {
        garraInteracaoComPowerUp = garraInteracaoComPowerUpArg;
        if (!garraInteracaoComPowerUp.garraPodeSegurar())
        {
            garraInteracaoComPowerUp.ligar();
        }
    }
}
