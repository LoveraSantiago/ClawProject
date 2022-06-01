using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class ItemScrollDto 
{
    [SerializeField] private SpriteRenderer sprRendererDivisoria;
    [SerializeField] private SpriteRenderer sprRendererImgPup;
    [SerializeField] private SpriteRenderer sprRendererDigito1;
    [SerializeField] private SpriteRenderer sprRendererDigito2;

    public SpriteRenderer SprRendererDivisoria { get { return sprRendererDivisoria; } }
    public SpriteRenderer SprRendererImgPup { get { return sprRendererImgPup; } }
    public SpriteRenderer SprRendererDigito1 { get { return sprRendererDigito1; } }
    public SpriteRenderer SprRendererDigito2 { get { return sprRendererDigito2; } }
}
