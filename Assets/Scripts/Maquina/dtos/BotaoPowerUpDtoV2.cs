using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class BotaoPowerUpDtoV2 
{
    [SerializeField] private float posXBotao;
    [SerializeField] private float posXPlaca;
    [SerializeField] private float rotacaoY;
    [Space(3)]
    [SerializeField] private SpriteRenderer sprRendererBtnBase;
    [SerializeField] private SpriteRenderer sprRendererBtnTampa;
    [SerializeField] private SpriteRenderer sprRendererImgBtn;

    public float PosXBotao { get { return posXBotao; } }
    public float PosXPlaca { get { return posXPlaca; } }
    public float RotacaoY { get { return rotacaoY; } }

    public SpriteRenderer SprRendererBtnBase { get { return sprRendererBtnBase; } }
    public SpriteRenderer SprRendererBtnTampa { get { return sprRendererBtnTampa; } }
    public SpriteRenderer SprRendererImgBtn { get { return sprRendererImgBtn; } }

    public Transform TransformBtnTampa { get { return sprRendererBtnTampa.transform; } }
    public Transform TransformImgBtn { get { return sprRendererImgBtn.transform; } }
}
