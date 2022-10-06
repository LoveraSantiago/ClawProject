using UnityEngine;

public class LinhaChallenge
{
    private LinhaChallengeDto linhaChallengeDto;

    public LinhaChallenge(LinhaChallengeDto linhaChallengeDto)
    {
        this.linhaChallengeDto = linhaChallengeDto;
    }

    public void colorirEstrela(Color cor)
    {
        linhaChallengeDto.ImgEstrela.color = cor;
    }

    public void configurarChallenge(Challenge challenge)
    {
        linhaChallengeDto.LblTextoChallenge.text = challenge.getLabelChallenge();
    }
}
