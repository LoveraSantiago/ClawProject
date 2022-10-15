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
        ChallengeLabel challengeLabel = challenge.getLabelChallenge();
        linhaChallengeDto.LblTextoChallenge.text = challengeLabel.conteudo;

        if (challengeLabel.temImg1)
        {
            linhaChallengeDto.Img1.gameObject.SetActive(true);
            linhaChallengeDto.Img1.sprite = challengeLabel.img1;
        }

        if (challengeLabel.temImg2)
        {
            linhaChallengeDto.Img2.gameObject.SetActive(true);
            linhaChallengeDto.Img2.sprite = challengeLabel.img2;
        }

        if (challengeLabel.temImg3)
        {
            linhaChallengeDto.Img3.gameObject.SetActive(true);
            linhaChallengeDto.Img3.sprite = challengeLabel.img3;
        }        
    }
}
