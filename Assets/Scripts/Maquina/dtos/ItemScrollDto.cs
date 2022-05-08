using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class ItemScrollDto 
{
    [SerializeField] private SpriteRenderer sprRendererDivisoria;
    [SerializeField] private SpriteRenderer sprRendererImgPup;
    [SerializeField] private SpriteRenderer sprRednererDigito1;
    [SerializeField] private SpriteRenderer sprRednererDigito2;

    public SpriteRenderer SprRendererDivisoria { get { return sprRendererDivisoria; } }
    public SpriteRenderer SprRendererImgPup { get { return sprRendererImgPup; } }
    public SpriteRenderer SprRednererDigito1 { get { return sprRednererDigito1; } }
    public SpriteRenderer SprRednererDigito2 { get { return sprRednererDigito2; } }
}
