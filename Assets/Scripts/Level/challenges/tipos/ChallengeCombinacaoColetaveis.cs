using UnityEngine;

public class ChallengeCombinacaoColetaveis : Challenge
{
    private int indice1;
    private int indice2;
    private int indice3;
    private bool prevencao;

    public ChallengeCombinacaoColetaveis(AbstractLevel abstractLevel, int indice1, int indice2, int indice3)
    {
        this.indice1 = indice1;
        this.indice2 = indice2;
        this.indice3 = indice3;
    }

    public ChallengeLabel getLabelChallenge(MapaEntidade mapaEntidade)
    {
        Sprite spr1 = mapaEntidade.getColetavelEntidadeByIndice(indice1).sprite;
        Sprite spr2 = mapaEntidade.getColetavelEntidadeByIndice(indice2).sprite;
        Sprite spr3 = mapaEntidade.getColetavelEntidadeByIndice(indice3).sprite;

        ChallengeLabel challengeLabel = new ChallengeLabel("Colete a combinacao ");
        challengeLabel.addIgms(spr1, spr2, spr3);
        return challengeLabel; 
    }

    public bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {
        return prevencao;
    }

    private void validarPrevencaoDeChallenge(AbstractLevel abstractLevel)
    {
        if(abstractLevel.devolverParaBoard() && !isMesmoIndices())
        {
            prevencao = true;
        }
    }

    private bool isMesmoIndices()
    {
        return indice1 == indice2 && indice2 == indice3;
    }
}
