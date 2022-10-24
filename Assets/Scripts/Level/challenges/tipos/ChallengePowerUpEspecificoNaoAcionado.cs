using System.Collections.Generic;

public class ChallengePowerUpEspecificoNaoAcionado : Challenge
{
    private PowerUpEntidade pupEntidade;

    public ChallengePowerUpEspecificoNaoAcionado(PowerUpEnums.TIPO tipo)
    {
        pupEntidade = FactoryPowerUpEntidade.getPowerUpEntidadeByEnum(tipo);
    }

    public ChallengeLabel getLabelChallenge(MapaEntidade mapaEntidade)
    {
        ChallengeLabel challengeLabel = new ChallengeLabel("Nao acione o power up\n " + pupEntidade.nome);
        challengeLabel.addIgms(null, pupEntidade.sprIconPowerUp, null);
        return challengeLabel;
    }

    public bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {
        List<PowerUpUsadoDto> listaPupsUsados = resultadoLevelsDto.resultadosPowerUp.listaPupsUsados;
        for (int contador = 0; contador < listaPupsUsados.Count; contador++)
        {
            if (listaPupsUsados[contador].tipo == pupEntidade.tipo)
            {
                return false;
            }
        }
        return true;
    }
}
