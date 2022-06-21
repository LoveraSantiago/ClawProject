using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class CanvasDetalheCardPupDto
{
    [SerializeField] private Image imgBackground;
    [SerializeField] private Image imgCirculo;
    [SerializeField] private Image imgExplicacao;

    public Image ImgBackground { get { return imgBackground; } }
    public Image ImgCirculo { get { return imgCirculo; } }
    public Image ImgExplicacao { get { return imgExplicacao; } }
}
