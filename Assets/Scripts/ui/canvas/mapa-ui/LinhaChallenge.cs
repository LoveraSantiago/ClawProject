using UnityEngine;
using UnityEngine.UI;

public class LinhaChallenge
{
    private LinhaChallengeDto linhaChallengeDto;

    public LinhaChallenge(LinhaChallengeDto linhaChallengeDto)
    {
        this.linhaChallengeDto = linhaChallengeDto;
    }

    public void colorirEstrela(Material materialCorEstrela)
    {
        linhaChallengeDto.ImgEstrela.material = materialCorEstrela;
    }

    public void configurarChallenge(MapaEntidade mapaEntidade, Challenge challenge)
    {
        ChallengeLabel challengeLabel = challenge.getLabelChallenge(mapaEntidade);
        linhaChallengeDto.LblTextoChallenge.text = challengeLabel.conteudo;

        configurarLinha(challengeLabel.temImg1, linhaChallengeDto.Img1, challengeLabel.img1);
        configurarLinha(challengeLabel.temImg2, linhaChallengeDto.Img2, challengeLabel.img2);
        configurarLinha(challengeLabel.temImg3, linhaChallengeDto.Img3, challengeLabel.img3);        
    }

    private void configurarLinha(bool configurar, Image img, Sprite sprite)
    {
        if (configurar)
        {
            img.gameObject.SetActive(true);
            img.sprite = sprite;
        }
        else
        {
            img.gameObject.SetActive(false);
        }
    }
}
