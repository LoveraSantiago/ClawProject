using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class DisplayDeScoreDto 
{
    [SerializeField] private int qtdBlinks;
    [SerializeField] private float tempoBlink;
    [Space(3)]
    [SerializeField] private Material materialEfeitoLedAditivo;
    [SerializeField] private Material materialEfeitoLedAlpha;
    [Space(3)]
    [SerializeField] private SpriteRenderer sprRendererPlacaGrupo;
    [SerializeField] private SingleDisplayScoreDto[] singleDisplayScoreDto = new SingleDisplayScoreDto[3];

    public int QtdBlinks { get { return qtdBlinks; } }
    public float TempoBlink { get { return tempoBlink; } }

    public Material MaterialEfeitoLedAditivo { get { return materialEfeitoLedAditivo;  } }
    public Material AaterialEfeitoLedAlpha { get { return materialEfeitoLedAlpha;  } }

    public SpriteRenderer SprRendererPlacaGrupo { get { return sprRendererPlacaGrupo; } }
    public SingleDisplayScoreDto[] SingleDisplayScoreDto { get { return singleDisplayScoreDto;  } }
}
