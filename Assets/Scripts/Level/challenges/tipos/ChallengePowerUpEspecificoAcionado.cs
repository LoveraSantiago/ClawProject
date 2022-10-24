using System.Collections.Generic;

public class ChallengePowerUpEspecificoAcionado : Challenge
{
    private PowerUpEntidade pupEntidade;

    public ChallengePowerUpEspecificoAcionado(PowerUpEnums.TIPO tipo)
    {
        pupEntidade = FactoryPowerUpEntidade.getPowerUpEntidadeByEnum(tipo);
    }

    public ChallengeLabel getLabelChallenge(MapaEntidade mapaEntidade)
    {
        ChallengeLabel challengeLabel = new ChallengeLabel("Acione o power up\n " + pupEntidade.nome);
        challengeLabel.addIgms(null, pupEntidade.sprIconPowerUp, null);
        return challengeLabel;
    }

    public bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {
        List<PowerUpUsadoDto> listaPupsUsados  = resultadoLevelsDto.resultadosPowerUp.listaPupsUsados;
        for(int contador = 0; contador < listaPupsUsados.Count; contador++)
        {
            if (listaPupsUsados[contador].tipo == pupEntidade.tipo)
            {
                return true;
            }
        }
        return false;
    }
}
