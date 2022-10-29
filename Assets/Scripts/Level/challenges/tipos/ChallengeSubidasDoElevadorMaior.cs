public class ChallengeSubidasDoElevadorMaior : Challenge
{
    private int qtdSubidas;

    public ChallengeSubidasDoElevadorMaior(AbstractLevelElevador abstracLevelElevador, int qtdSubidas)
    {
        this.qtdSubidas = qtdSubidas;
    }

    public ChallengeLabel getLabelChallenge(MapaEntidade mapaEntidade)
    {
        return new ChallengeLabel("Finalize o level depois de " + qtdSubidas.ToString() + " subidas do elevador.");
    }

    public bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {
        return resultadoLevelsDto.subidasDoElevador > qtdSubidas;
    }
}
