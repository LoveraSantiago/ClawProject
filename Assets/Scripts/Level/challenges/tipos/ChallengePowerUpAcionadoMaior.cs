public class ChallengePowerUpAcionadoMaior : Challenge
{
    private int qtdEsperada;

    public ChallengePowerUpAcionadoMaior(int qtdEsperada)
    {
        this.qtdEsperada = qtdEsperada;
    }

    public ChallengeLabel getLabelChallenge(MapaEntidade mapaEntidade)
    {
        return new ChallengeLabel("Acione pelo menos " + qtdEsperada.ToString() + " Power Ups");
    }

    public bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {
        return qtdEsperada <= resultadoLevelsDto.resultadosPowerUp.totalPowerUps;
    }
}
