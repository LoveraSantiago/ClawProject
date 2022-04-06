using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class TuboDtoV2 
{
    [SerializeField] private SpriteRenderer sprRendererBase;
    [SerializeField] private SpriteRenderer sprRendererTopo;

    public SpriteRenderer SprRendererBase { get { return sprRendererBase; } }
    public SpriteRenderer SprRendererTopo { get { return sprRendererTopo; } }
}
