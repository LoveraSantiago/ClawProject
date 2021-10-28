using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class BotaoLigaDesligaDto
{
    [SerializeField] private SpriteRenderer sprRendererBtnBordas;
    [SerializeField] private SpriteRenderer sprRendererBtnOnOff;

    public SpriteRenderer SprRendererBtnBordas { get { return sprRendererBtnBordas; } }
    public SpriteRenderer SprRendererBtnOnOff  { get { return sprRendererBtnOnOff; } }

}
