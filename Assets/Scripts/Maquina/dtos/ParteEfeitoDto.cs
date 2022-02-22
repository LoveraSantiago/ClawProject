using UnityEngine;

#pragma warning disable 0649
public class ParteEfeitoDto
{
    [SerializeField] private SpriteRenderer sprRenderColorir;
    [SerializeField] private SpriteRenderer sprRenderEfeito;

    public SpriteRenderer SprRenderColorir { get { return sprRenderColorir; } }
    public SpriteRenderer SprRenderEfeito { get { return sprRenderEfeito;  } }
    public GameObject GoEfeito { get { return sprRenderEfeito.gameObject; } }
}
