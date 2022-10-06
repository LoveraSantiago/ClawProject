using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinhasChallenge 
{
    private LinhaChallenge[] linhasChallenge;

    public LinhasChallenge(LinhaChallengeDto[] linhasChallengesDto)
    {
        linhasChallenge = new LinhaChallenge[linhasChallengesDto.Length];
        for(int contador =0; contador < linhasChallenge.Length; contador++)
        {
            linhasChallenge[contador] = new LinhaChallenge(linhasChallengesDto[contador]);
        }
    }

    public void addEstrelasChallenges(Color cor, int challenge)
    {
        bool[] estrelasChallenges = ChallengesUtils.toArray(challenge);

        for (int contador = 0; contador < estrelasChallenges.Length; contador++)
        {
            Color corAtual = Color.white;
            if (estrelasChallenges[contador])
            {
                corAtual = cor;
            }
            linhasChallenge[contador].colorirEstrela(corAtual);            
        }
    }
}
