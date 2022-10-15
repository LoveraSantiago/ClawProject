public class ChallengeTempoMenor : Challenge
{
    private string tempoEstimado;

    public ChallengeTempoMenor(string tempoEstimado)
    {
        this.tempoEstimado = tempoEstimado;
    }

    public ChallengeLabel getLabelChallenge(MapaEntidade mapaEntidade)
    {
        return new ChallengeLabel("Complete o level antes de " + tempoEstimado);
    }

    public bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {
        double tempoEstimadoDouble = TempoUtils.parseTimeFromString(tempoEstimado);
        double tempoLevel = TempoUtils.parseTimeFromString(resultadoLevelsDto.tempoPartida);
        return tempoLevel < tempoEstimadoDouble;
    }
}
