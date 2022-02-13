public abstract class AbstractMovimentacaoDaGarraPowerUp : AbstractMovimentacaoDaGarra
{
    protected static ComunicadorComGerMovPowerUp comunicadorComGerMovimentacao;
    protected static PupInteracaoComGarra garraInteracaoComPowerUp;

    public static void configurarComunicadorComGerMovimentacao(ComunicadorComGerMovPowerUp comunicadorComGerMovimentacaoArg)
    {
        comunicadorComGerMovimentacao = comunicadorComGerMovimentacaoArg;
    }

    public static void receberInteracaoComPowerUp(PupInteracaoComGarra garraInteracaoComPowerUpArg)
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

    public bool isEstadoSegurandoParado()
    {
        return (this is MovimentacaoAgarrandoEmcima) || (this is MovimentacaoParadoPowerUp);
    }

    public bool isEstadoSegurandoEmCimaMovimentando()
    {
        return (this is MovimentacaoAgarrandoEmcimaEmMovimento);
    }
}
