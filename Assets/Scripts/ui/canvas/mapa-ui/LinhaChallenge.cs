using System.Collections;
using System.Collections.Generic;
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
}
