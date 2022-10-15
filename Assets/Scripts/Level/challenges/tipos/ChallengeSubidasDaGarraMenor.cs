public class ChallengeSubidasDaGarraMenor : Challenge
{
    private int subidas;

    public ChallengeSubidasDaGarraMenor(int subidas)
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
