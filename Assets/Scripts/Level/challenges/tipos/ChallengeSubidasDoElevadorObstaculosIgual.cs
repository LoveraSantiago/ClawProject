public class ChallengeSubidasDoElevadorObstaculosIgual : Challenge
{
    private int qtdSubidas;

    public ChallengeSubidasDoElevadorObstaculosIgual(AbstractLevelElevadorComObstaculo abstracLevelElevador, int qtdSubidas)
    {
        this.qtdSubidas = qtdSubidas;
    }

    public ChallengeLabel getLabelChallenge(MapaEntidade mapaEntidade)
    {
        return new ChallengeLabel("Finalize o level com " + qtdSubidas.ToString() + " subidas do elevador.");
    }

    public bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {
        return resultadoLevelsDto.subidasDoElevador == qtdSubidas;
    }
}
