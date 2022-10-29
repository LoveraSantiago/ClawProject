public class ChallengeLevelCompleto : Challenge
{
    public ChallengeLabel getLabelChallenge(MapaEntidade mapaEntidade)
    {
        return new ChallengeLabel("Colete todos os itens");
    }

    public bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {
        return true;
    }
}
