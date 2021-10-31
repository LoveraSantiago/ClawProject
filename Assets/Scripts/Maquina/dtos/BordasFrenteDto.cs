using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class BordasFrenteDto : ParteEfeitoDto
{
    [SerializeField] private SpriteRenderer sprBordaVidro;
    [SerializeField] private SpriteRenderer sprBordaVidroEfeito;

    public SpriteRenderer SprBordaVidro { get { return sprBordaVidro; } }
    public SpriteRenderer SprBordaVidroEfeito { get { return sprBordaVidroEfeito;  } }
    public GameObject BordaVidroEfeito { get { return sprBordaVidroEfeito.gameObject; } }
}
