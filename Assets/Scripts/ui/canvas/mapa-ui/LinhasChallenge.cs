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

    public void addEstrelasChallenges(Material materialCorEstrela, int challenge)
    {
        bool[] estrelasChallenges = ChallengesUtils.toArray(challenge);
        addEstrelasChallenges(materialCorEstrela, estrelasChallenges);
    }

    public void addEstrelasChallenges(Material materialCorEstrela, bool[] challenges)
    {
        for (int contador = 0; contador < linhasChallenge.Length; contador++)
        {            
            if (challenges[contador])
            {
                linhasChallenge[contador].colorirEstrela(materialCorEstrela);                
            }
        }
    }

    public void addConfiguracaoChallenges(MapaEntidade mapaEntidade, Challenge[] challenges)
    {
        for (int contador = 0; contador < linhasChallenge.Length; contador++)
        {
            linhasChallenge[contador].configurarChallenge(mapaEntidade, challenges[contador]);
        }
    }
}
