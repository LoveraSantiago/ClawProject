public class ChallengeScoreMenor : Challenge
{
    private int scoreEstimado;

    public ChallengeScoreMenor(int scoreEstimado)
    {
        this.scoreEstimado = scoreEstimado;
    }

    public string getLabelChallenge()
    {
        return "Fique abaixo do score total de " + scoreEstimado.ToString();
    }

    public bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {
        return scoreEstimado > resultadoLevelsDto.score;
    }
}
