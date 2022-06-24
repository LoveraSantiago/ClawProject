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
    [SerializeField] private Image imgPup;
    [SerializeField] private Image imgBtn;
    [SerializeField] private Image imgCorBtn1;
    [SerializeField] private Image imgCorBtn2;
    [SerializeField] private Image imgCorBtn3;
    [Space(3)]
    [SerializeField] private TextMeshProUGUI lblPreco;
    [SerializeField] private TextMeshProUGUI lblExplicacao;
    [SerializeField] private TextMeshProUGUI lblQtd;
    [SerializeField] private TextMeshProUGUI lblNome;
    [SerializeField] private TextMeshProUGUI lblTipo;
    [Space(3)]
    [SerializeField] private Button btnPratica;
    [SerializeField] private Button btnCacaNiquelPupIndividual;
    [SerializeField] private Button btnCacaNiquelPupGeral;

    public Image ImgBackground { get { return imgBackground; } }
    public Image ImgCirculo { get { return imgCirculo; } }
    public Image ImgExplicacao { get { return imgExplicacao; } }
    public Image ImgPup { get { return imgPup; } }
    public Image ImgBtn { get { return imgBtn; } }
    public Image ImgCorBtn1 { get { return imgCorBtn1; } }
    public Image ImgCorBtn2 { get { return imgCorBtn2; } }
    public Image ImgCorBtn3 { get { return imgCorBtn3; } }

    public TextMeshProUGUI LblPreco { get { return lblPreco; } }
    public TextMeshProUGUI LblExplicacao { get { return lblExplicacao; } }
    public TextMeshProUGUI LblQtd { get { return lblQtd; } }
    public TextMeshProUGUI LblNome { get { return lblNome; } }
    public TextMeshProUGUI LblTipo { get { return lblTipo; } }

    public Button BtnPratica { get { return btnPratica; } }
    public Button BtnCacaNiquelPupIndividual { get { return btnCacaNiquelPupIndividual; } }
    public Button BtnCacaNiquelPupGeral { get { return btnCacaNiquelPupGeral; } }
}
