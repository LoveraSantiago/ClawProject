using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class BotaoPowerUpDtoV2 
{
    [SerializeField] private SpriteRenderer sprRendererBtnBase;
    [SerializeField] private SpriteRenderer sprRendererBtnTampa;

    public SpriteRenderer SprRendererBtnBase { get { return sprRendererBtnBase; } }
    public SpriteRenderer SprRendererBtnTampa { get { return sprRendererBtnTampa; } }
}
