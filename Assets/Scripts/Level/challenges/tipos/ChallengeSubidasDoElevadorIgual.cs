public class ChallengeSubidasDoElevadorIgual : Challenge
{
    private int qtdSubidas;

    public ChallengeSubidasDoElevadorIgual(AbstractLevelElevador abstracLevelElevador, int qtdSubidas)
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
