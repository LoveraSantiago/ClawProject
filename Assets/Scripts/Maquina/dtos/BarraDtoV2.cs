using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class BarraDtoV2 
{
    [SerializeField] private SpriteRenderer sprRendererBarra;
    [SerializeField] private SpriteRenderer sprRendererSuporteEsquerda;
    [SerializeField] private SpriteRenderer sprRendererSuporteDireita;

    public SpriteRenderer SprRendererBarra { get { return sprRendererBarra; } }
    public SpriteRenderer SprRendererSuporteEsquerda { get { return sprRendererSuporteEsquerda; } }
    public SpriteRenderer SprRendererSuporteDireita { get { return sprRendererSuporteDireita; } }
}
