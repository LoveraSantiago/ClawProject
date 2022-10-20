public class ChallengeQuebrarGaiolasIgual : ChallengeQuebrarGaiolasTodas
{
    private int qtdGaiolas;

    public ChallengeQuebrarGaiolasIgual(AbstractLevelObstaculos abstractLevelObstaculo, int qtdGaiolas) 
        : base(abstractLevelObstaculo)
    {
        this.qtdGaiolas = qtdGaiolas;
    }

    public override ChallengeLabel getLabelChallenge(MapaEntidade mapaEntidade)
    {
        return new ChallengeLabel("Quebre " + qtdGaiolas.ToString() + " Gaiolas");
    }

    public override bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {
        return qtdGaiolas == resultadoLevelsDto.resultadosColetaveis.totalGaiolasQuebradas;
    }
}
