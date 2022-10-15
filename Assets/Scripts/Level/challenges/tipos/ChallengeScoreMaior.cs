public class ChallengeScoreMaior : Challenge
{
    private int scoreEstimado;

    public ChallengeScoreMaior(int scoreEstimado)
    {
        this.scoreEstimado = scoreEstimado;
    }

    public ChallengeLabel getLabelChallenge(MapaEntidade mapaEntidade)
    {
        return new ChallengeLabel("Supere o score total de " + scoreEstimado.ToString());
    }

    public bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {               
        return scoreEstimado < resultadoLevelsDto.resultadosColetaveis.score;
    }
}
