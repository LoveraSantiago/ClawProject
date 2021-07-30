public class PowerUpInfo
{
    public enum ESTADO { INICIO, PREFINALIZAR, FINALIZAR}

    public ESTADO estadoAtual;
    public int duracaoTempo{ get; private set; }
    public ColetavelTile coletavelTile { get; private set; }
    public GarraInteracaoComPowerUp garraInteracaoPowerUp { get; private set; }

    public PowerUpInfo(ESTADO estado)
    {
        estadoAtual = estado;
    }

    public PowerUpInfo configurarDuracaoTempo(int duracao)
    {
        duracaoTempo = duracao;
        return this;
    }

    public PowerUpInfo configurarObjetoInteracaoComGarra(GarraInteracaoComPowerUp garraInteracaoPowerUp)
    {
        this.garraInteracaoPowerUp = garraInteracaoPowerUp;
        return this;
    }

    public PowerUpInfo addColetavel(ColetavelTile coletavelTile)
    {
        this.coletavelTile = coletavelTile;        
        return this;
    }

    public bool isInicio()
    {
        return estadoAtual == ESTADO.INICIO;
    }

    public bool isPreFinalizar()
    {
        return estadoAtual == ESTADO.PREFINALIZAR;
    }

    public bool isFinalizar()
    {
        return estadoAtual == ESTADO.FINALIZAR;
    }

    public bool hasColetavel()
    {
        return coletavelTile != null;
    }
}
