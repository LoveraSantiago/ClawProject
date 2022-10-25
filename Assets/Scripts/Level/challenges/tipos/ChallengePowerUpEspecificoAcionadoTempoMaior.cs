using System.Collections.Generic;

public class ChallengePowerUpEspecificoAcionadoTempoMaior : Challenge
{
    private string tempoEstimado;
    private PowerUpEntidade pupEntidade;

    public ChallengePowerUpEspecificoAcionadoTempoMaior(PowerUpEnums.TIPO tipo, string tempoEstimado)
    {
        this.tempoEstimado = tempoEstimado;
        pupEntidade = FactoryPowerUpEntidade.getPowerUpEntidadeByEnum(tipo);
    }

    public ChallengeLabel getLabelChallenge(MapaEntidade mapaEntidade)
    {
        ChallengeLabel challengeLabel = new ChallengeLabel("Acione o power up " + pupEntidade.nome + "\n antes de " + tempoEstimado);
        challengeLabel.addIgms(null, null, pupEntidade.sprIconPowerUp);
        return challengeLabel;
    }

    public bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {
        double tempoEstimadoNumerico = TempoUtils.parseTimeFromString(tempoEstimado);
        List<PowerUpUsadoDto> listaPupsUsados = resultadoLevelsDto.resultadosPowerUp.listaPupsUsados;
        for (int contador = 0; contador < listaPupsUsados.Count; contador++)
        {
            PowerUpUsadoDto powerUpUsado = listaPupsUsados[contador];
            if (powerUpUsado.tipo == pupEntidade.tipo && powerUpUsado.tempoAcionamento > tempoEstimadoNumerico)
            {
                return true;
            }
        }
        return false;
    }
}
