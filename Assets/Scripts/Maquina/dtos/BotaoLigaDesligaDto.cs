using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class BotaoLigaDesligaDto
{
    [SerializeField] private SpriteRenderer sprRendererBtnLigaDesliga;

    public SpriteRenderer SprRendererBtnLigaDesliga { get { return sprRendererBtnLigaDesliga; } }

}
