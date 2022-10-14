public class ChallengeSubidasDaGarra : Challenge
{
    private int subidas;

    public ChallengeSubidasDaGarra(int subidas)
    {
        this.subidas = subidas;
    }

    public string getLabelChallenge()
    {
        return "Finalize o level com menos de " + subidas.ToString() + " subidas da Garra";
    }

    public bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {        
        return resultadoLevelsDto.subidasDaGarra < subidas;
    }
}
