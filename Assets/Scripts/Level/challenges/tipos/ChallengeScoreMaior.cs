public class ChallengeScoreMaior : Challenge
{
    private int scoreEstimado;

    public ChallengeScoreMaior(int scoreEstimado)
    {
        this.scoreEstimado = scoreEstimado;
    }

    public string getLabelChallenge()
    {
        return "Supere o score total de " + scoreEstimado.ToString();
    }

    public bool resultado(ResultadoLevelsDto resultadoLevelsDto)
    {        
        return scoreEstimado < resultadoLevelsDto.score;
    }
}
