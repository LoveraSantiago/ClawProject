public class TempoChallenge : Challenge
{
    private string tempoEstimado;

    public TempoChallenge(string tempoEstimado)
    {
        this.tempoEstimado = tempoEstimado;
    }

    public string getLabelChallenge()
    {
        return "Complete o level antes de " + tempoEstimado;
    }

    public bool resultado(ResultadoLevelsDto resultadoLevelsDto)
    {
        double tempoEstimadoDouble = TempoUtils.parseTimeFromString(tempoEstimado);
        double tempoLevel = TempoUtils.parseTimeFromString(resultadoLevelsDto.tempoPartida);
        return tempoLevel < tempoEstimadoDouble;
    }
}
