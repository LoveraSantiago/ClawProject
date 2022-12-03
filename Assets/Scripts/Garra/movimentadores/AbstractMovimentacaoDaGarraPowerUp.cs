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
    }    

    public void finalizarPowerUp()
    {
        garraInteracaoComPowerUp = null;
    }

    public bool isEstadoSegurandoParado()
    {
        return (this is MovimentacaoAgarrandoEmcima) || (this is MovimentacaoParadoPowerUp);
    }

    public bool isEstadoSegurandoEmCimaMovimentando()
    {
        return (this is MovimentacaoAgarrandoEmcimaEmMovimento);
    }

    protected bool isInteracaoComPowerUp()
    {
        return isInteracaoComPowerUpMovimento() ||
                garraInteracaoComPowerUp.getInteracaoComGarra() == TipoInteracaoGarra.PARADO;
    }

    protected bool isInteracaoComPowerUpMovimento()
    {
        return garraInteracaoComPowerUp.getInteracaoComGarra() == TipoInteracaoGarra.MOVIMENTO;
    }
}
