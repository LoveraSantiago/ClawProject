public class ChallengeSubidasDaGarraMaior : Challenge
{
    private int subidas;

    public ChallengeSubidasDaGarraMaior(int subidas)
    {
        this.subidas = subidas;
    }

    public ChallengeLabel getLabelChallenge()
    {
        return new ChallengeLabel("Finalize o level com mais de " + subidas.ToString() + " subidas da Garra");
    }

    public bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {
        return resultadoLevelsDto.subidasDaGarra < subidas;
    }
}
