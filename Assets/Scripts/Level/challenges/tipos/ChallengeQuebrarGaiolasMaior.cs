public class ChallengeQuebrarGaiolasMaior : ChallengeQuebrarGaiolasTodas
{
    private int qtdGaiolas;

    public ChallengeQuebrarGaiolasMaior(AbstractLevelObstaculos abstractLevelObstaculo, int qtdGaiolas) 
        : base(abstractLevelObstaculo)
    {
        this.qtdGaiolas = qtdGaiolas;
    }

    public override ChallengeLabel getLabelChallenge(MapaEntidade mapaEntidade)
    {
        return new ChallengeLabel("Quebra mais gaiolas do que " + qtdGaiolas.ToString());
    }

    public override bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {
        return qtdGaiolas < resultadoLevelsDto.resultadosColetaveis.totalGaiolasQuebradas;
    }
}
