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

        for (int contador = 0; contador < linhasChallenge.Length; contador++)
        {
            Color corAtual = Color.white;
            if (estrelasChallenges[contador])
            {
                corAtual = cor;
            }
            linhasChallenge[contador].colorirEstrela(corAtual);            
        }
    }

    public void addConfiguracaoChallenges(Challenge[] challenges)
    {
        for (int contador = 0; contador < linhasChallenge.Length; contador++)
        {
            linhasChallenge[contador].configurarChallenge(challenges[contador]);
        }
    }
}
