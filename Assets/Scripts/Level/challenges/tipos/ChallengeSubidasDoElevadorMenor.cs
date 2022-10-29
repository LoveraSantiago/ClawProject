public class ChallengeSubidasDoElevadorMenor : Challenge
{
    private int qtdSubidas;

    public ChallengeSubidasDoElevadorMenor(AbstractLevelElevador abstracLevelElevador, int qtdSubidas)
    {
        this.qtdSubidas = qtdSubidas;
    }

    public ChallengeLabel getLabelChallenge(MapaEntidade mapaEntidade)
    {
        return new ChallengeLabel("Finalize o level antes de " + qtdSubidas.ToString() + " subidas do elevador.");
    }

    public bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {
        return resultadoLevelsDto.subidasDoElevador < qtdSubidas;
    }
}
