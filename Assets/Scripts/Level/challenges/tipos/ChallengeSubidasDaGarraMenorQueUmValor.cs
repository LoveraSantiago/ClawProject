public class ChallengeSubidasDaGarraMenorQueUmValor : Challenge
{
    private int subidas;

    public ChallengeSubidasDaGarraMenorQueUmValor(int subidas)
    {
        this.subidas = subidas;
    }

    public ChallengeLabel getLabelChallenge(MapaEntidade mapaEntidade)
    {
        return new ChallengeLabel("Finalize o level com menos de " + subidas.ToString() + " subidas da Garra");
    }

    public bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {        
        return resultadoLevelsDto.subidasDaGarra < subidas;
    }
}
