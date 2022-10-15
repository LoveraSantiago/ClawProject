using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeCombinacaoColetaveis : Challenge
{
    private int indice1;
    private int indice2;
    private int indice3;

    public ChallengeCombinacaoColetaveis(int indice1, int indice2, int indice3)
    {
        this.indice1 = indice1;
        this.indice2 = indice2;
        this.indice3 = indice3;
    }

    public ChallengeLabel getLabelChallenge()
    {
        ChallengeLabel challengeLabel = new ChallengeLabel("Colete a combinacao ");
        return challengeLabel; ;
    }

    public bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {
        return false;
    }
}
