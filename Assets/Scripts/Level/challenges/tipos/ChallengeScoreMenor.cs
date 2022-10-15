public class ChallengeScoreMenor : Challenge
{
    private int scoreEstimado;

    public ChallengeScoreMenor(int scoreEstimado)
    {
        this.scoreEstimado = scoreEstimado;
    }

    public ChallengeLabel getLabelChallenge()
    {
        return new ChallengeLabel("Fique abaixo do score total de " + scoreEstimado.ToString());
    }

    public bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {
        return scoreEstimado > resultadoLevelsDto.resultadosColetaveis.score;
    }
}
