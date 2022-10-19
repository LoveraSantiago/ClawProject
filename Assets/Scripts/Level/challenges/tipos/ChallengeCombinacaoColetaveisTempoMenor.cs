using System.Collections.Generic;
using UnityEngine;

public class ChallengeCombinacaoColetaveisTempoMenor : ChallengeCombinacaoColetaveis
{
    private string tempoEstimado;

    public ChallengeCombinacaoColetaveisTempoMenor(
        AbstractLevel abstractLevel, int indice1, int indice2, int indice3, string tempoEstimado) : 
        base(abstractLevel, indice1, indice2, indice3)
    {
        this.tempoEstimado = tempoEstimado;
    }

    public override ChallengeLabel getLabelChallenge(MapaEntidade mapaEntidade)
    {
        ChallengeLabel challengeLabel = base.getLabelChallenge(mapaEntidade);
        string novoConteudo = challengeLabel.conteudo + "\nantes de " + tempoEstimado;
        challengeLabel.addConteudo(novoConteudo);
        return challengeLabel;
    }

    public override bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {
        return prevencao ||
            validarCombinacao(resultadoLevelsDto) ||
            isCombinacaoNaoPossivelInGame(resultadoLevelsDto);
    }

    private bool validarCombinacao(ResultadoLevelDto resultadoLevelsDto)
    {
        Sprite[] sprites = indicesToSprite();
        double tempoEstimadoNumerico = TempoUtils.parseTimeFromString(tempoEstimado);

        List<TrincaColetaveisDescartadosDto> coletaveisDescartados = resultadoLevelsDto.resultadosColetaveis.coletaveisDescartados.coletaveisDescartados;
        for (int contador = 0; contador < coletaveisDescartados.Count; contador++)
        {
            TrincaColetaveisDescartadosDto trincaIt = coletaveisDescartados[contador];
            bool resultado = trincaIt.isSpritesIguais(sprites[0], sprites[1], sprites[2]);
            if (resultado && (tempoEstimadoNumerico < trincaIt.timeStamp))
            {
                return resultado;
            }
        }
        return false;
    }    
}
