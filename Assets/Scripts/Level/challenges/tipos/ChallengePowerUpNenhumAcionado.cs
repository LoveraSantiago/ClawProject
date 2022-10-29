public class ChallengePowerUpNenhumAcionado : Challenge
{
    public ChallengeLabel getLabelChallenge(MapaEntidade mapaEntidade)
    {
        return new ChallengeLabel("Não acione nenhum power up");
    }

    public bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {
        return resultadoLevelsDto.resultadosPowerUp.totalPowerUps == 0;
    }
}
