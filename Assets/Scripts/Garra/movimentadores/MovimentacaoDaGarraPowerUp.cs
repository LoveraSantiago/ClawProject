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
        if (garraInteracaoComPowerUp.getInteracaoComGarra() == PowerUpEntidade.INTERACAOGARRA.NAO_INTERACAO)
        {
            garraInteracaoComPowerUp.iniciar();
        }
    }

    public void acionarTimeout()
    {
        garraInteracaoComPowerUp.timeout();        
    }

    public void finalizarPowerUp()
    {
        garraInteracaoComPowerUp = null;
    }
}
