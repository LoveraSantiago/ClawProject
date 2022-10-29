public class ChallengeQuebrarGaiolasMenor : ChallengeQuebrarGaiolasTodas
{
    private int qtdGaiolas;

    public ChallengeQuebrarGaiolasMenor(AbstractLevelObstaculos abstractLevelObstaculo, int qtdGaiolas)
        : base(abstractLevelObstaculo)
    {
        this.qtdGaiolas = qtdGaiolas;
    }

    public override ChallengeLabel getLabelChallenge(MapaEntidade mapaEntidade)
    {
        return new ChallengeLabel("Quebre menos do que " + qtdGaiolas.ToString() + " Gaiolas");
    }

    public override bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {
        return qtdGaiolas > resultadoLevelsDto.resultadosColetaveis.totalGaiolasQuebradas;
    }
}
