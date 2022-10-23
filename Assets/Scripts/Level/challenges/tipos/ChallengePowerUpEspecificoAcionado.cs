public class ChallengePowerUpEspecificoAcionado : Challenge
{
    private PowerUpEntidade pupEntidade;

    public ChallengePowerUpEspecificoAcionado(PowerUpEnums.TIPO tipo)
    {
        pupEntidade = FactoryPowerUpEntidade.getPowerUpEntidadeByEnum(tipo);
    }

    public ChallengeLabel getLabelChallenge(MapaEntidade mapaEntidade)
    {
        ChallengeLabel challengeLabel = new ChallengeLabel("Acione o power up " + pupEntidade.nome);
        challengeLabel.addIgms(null, null, pupEntidade.sprIconPowerUp);
        return challengeLabel;
    }

    public bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {
        throw new System.NotImplementedException();
    }
}
