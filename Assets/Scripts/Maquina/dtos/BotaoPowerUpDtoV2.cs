using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class BotaoPowerUpDtoV2 
{
    [SerializeField] private SpriteRenderer sprRendererBtnBase;
    [SerializeField] private SpriteRenderer sprRendererBtnTampa;
    [SerializeField] private SpriteRenderer sprRendererImgBtn;

    public SpriteRenderer SprRendererBtnBase { get { return sprRendererBtnBase; } }
    public SpriteRenderer SprRendererBtnTampa { get { return sprRendererBtnTampa; } }
    public SpriteRenderer SprRendererImgBtn { get { return sprRendererImgBtn; } }

    public Transform TransformBtnTampa { get { return sprRendererBtnTampa.transform; } }
    public Transform TransformImgBtn { get { return sprRendererImgBtn.transform; } }
}
