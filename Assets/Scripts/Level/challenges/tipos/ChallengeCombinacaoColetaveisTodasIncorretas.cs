using System.Collections.Generic;

public class ChallengeCombinacaoColetaveisTodasIncorretas : ChallengeCombinacaoColetaveis
{
    public ChallengeCombinacaoColetaveisTodasIncorretas(
       AbstractLevel abstractLevel) :
       base(abstractLevel, 0, 0, 0)
    {
    }

    public override ChallengeLabel getLabelChallenge(MapaEntidade mapaEntidade)
    {
        return new ChallengeLabel("Consiga todas as combinações imperfeitas");
    }

    public override bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {
        List<TrincaColetaveisDescartadosDto> coletaveisDescartados = resultadoLevelsDto.resultadosColetaveis.coletaveisDescartados.listaDeTrincaDeDescartados;
        for (int contador = 0; contador < coletaveisDescartados.Count; contador++)
        {
            if (coletaveisDescartados[contador].isMesmosSprites())
            {
                return false;
            }
        }
        return true;
    }
}
