public class ChallengeLevelCompleto : Challenge
{
    public ChallengeLabel getLabelChallenge()
    {
        return new ChallengeLabel("Colete todos os itens");
    }

    public bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {
        return true;
    }
}
