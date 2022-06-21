using UnityEngine;
using UnityEngine.UI;
using TMPro;

#pragma warning disable 0649
[System.Serializable]
public class CanvasDetalheCardPupDto
{
    [SerializeField] private Image imgBackground;
    [SerializeField] private Image imgCirculo;
    [SerializeField] private Image imgExplicacao;
    [SerializeField] private TextMeshProUGUI lblPreco;
    [SerializeField] private TextMeshProUGUI lblExplicacao;
    [SerializeField] private TextMeshProUGUI lblQtd;
    [SerializeField] private TextMeshProUGUI lblNome;
    [SerializeField] private TextMeshProUGUI lblTipo;

    public Image ImgBackground { get { return imgBackground; } }
    public Image ImgCirculo { get { return imgCirculo; } }
    public Image ImgExplicacao { get { return imgExplicacao; } }
    public TextMeshProUGUI LblPreco { get { return lblPreco; } }
    public TextMeshProUGUI LblExplicacao { get { return lblExplicacao; } }
    public TextMeshProUGUI LblQtd { get { return lblQtd; } }
    public TextMeshProUGUI LblNome { get { return lblNome; } }
    public TextMeshProUGUI LblTipo { get { return lblTipo; } }
}
