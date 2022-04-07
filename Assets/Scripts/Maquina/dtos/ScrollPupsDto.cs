using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class ScrollPupsDto
{
    [SerializeField] private SpriteRenderer sprRendererPlacaExterna;
    [SerializeField] private SpriteRenderer sprRendererPlacaInterna;
    [SerializeField] private SpriteRenderer sprRendererPlacaSetaEsquerda;
    [SerializeField] private SpriteRenderer sprRendererPlacaSetaDireita;
    [SerializeField] private SpriteRenderer sprRendererPlacaSetaCima;

    public SpriteRenderer SprRendererPlacaExterna { get { return sprRendererPlacaExterna; } }
    public SpriteRenderer SprRendererPlacaInterna { get { return sprRendererPlacaInterna; } }
    public SpriteRenderer SprRendererPlacaSetaEsquerda { get { return sprRendererPlacaSetaEsquerda; } }
    public SpriteRenderer SprRendererPlacaSetaDireita { get { return sprRendererPlacaSetaDireita; } }
    public SpriteRenderer SprRendererPlacaSetaCima { get { return sprRendererPlacaSetaCima; } }
}
