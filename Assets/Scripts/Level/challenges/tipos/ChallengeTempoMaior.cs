public class ChallengeTempoMaior : Challenge
{
    private bool prevencao;
    private string tempoEstimado;

    public ChallengeTempoMaior(AbstractLevel abstractLevel, string tempoEstimado)
    {
        this.tempoEstimado = tempoEstimado;
        validarPrevencaoDeChallenge(abstractLevel);
    }

    public ChallengeLabel getLabelChallenge()
    {
        return new ChallengeLabel("Complete o level depois de " + tempoEstimado);
    }

    public bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {
        double tempoEstimadoDouble = TempoUtils.parseTimeFromString(tempoEstimado);
        double tempoLevel = TempoUtils.parseTimeFromString(resultadoLevelsDto.tempoPartida);
        return prevencao || (tempoLevel > tempoEstimadoDouble);
    }

    private void validarPrevencaoDeChallenge(AbstractLevel abstractLevel)
    {
        prevencao = false;
        TipoContagemTempoDto tipoContagemTempo = abstractLevel.getTempoContagem();
        if (tipoContagemTempo.isContagemRegressiva() && 
            isTempoEstimadoMaiorQueTempoContagemRegressiva(tipoContagemTempo.tempo))
        {
            prevencao = true;
        }
    }

    private bool isTempoEstimadoMaiorQueTempoContagemRegressiva(string tempoContagemRegressiva)
    {
        double tempoContagemRegressivaNumerico = TempoUtils.parseTimeFromString(tempoContagemRegressiva);
        double tempoEstimadoNumerico = TempoUtils.parseTimeFromString(tempoEstimado);
        return tempoContagemRegressivaNumerico < tempoEstimadoNumerico;
    }
}
