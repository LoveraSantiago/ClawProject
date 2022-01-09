public abstract class AbstractMovimentacaoDaGarraPowerUp : AbstractMovimentacaoDaGarra
{
    protected static ComunicadorComGerMovPowerUp comunicadorComGerMovimentacao;
    protected static PowerUpInteracaoComGarra garraInteracaoComPowerUp;

    public static void configurarComunicadorComGerMovimentacao(ComunicadorComGerMovPowerUp comunicadorComGerMovimentacaoArg)
    {
        comunicadorComGerMovimentacao = comunicadorComGerMovimentacaoArg;
    }

    public static void receberInteracaoComPowerUp(PowerUpInteracaoComGarra garraInteracaoComPowerUpArg)
    {
        garraInteracaoComPowerUp = garraInteracaoComPowerUpArg;
        if (garraInteracaoComPowerUp.getInteracaoComGarra() == PowerUpEnums.INTERACAOGARRA.NAO_INTERACAO)
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
