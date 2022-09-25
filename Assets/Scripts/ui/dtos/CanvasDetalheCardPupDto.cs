using UnityEngine;
using UnityEngine.UI;
using TMPro;

#pragma warning disable 0649
[System.Serializable]
public class CanvasDetalheCardPupDto
{
    
    [Space(3)]    
    [SerializeField] private Image imgBackground;
    [SerializeField] private Image imgCirculo;
    [SerializeField] private Image imgExplicacao;
    [SerializeField] private Image imgPup;
    [SerializeField] private Image imgBtn;
    [Space(3)]    
    [SerializeField] private Image[] imgsCorBtns = new Image[3];    
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
    
    public Image[] ImgsCorBtns { get { return imgsCorBtns; } }    

    public TextMeshProUGUI LblPreco { get { return lblPreco; } }
    public TextMeshProUGUI LblExplicacao { get { return lblExplicacao; } }
    public TextMeshProUGUI LblQtd { get { return lblQtd; } }
    public TextMeshProUGUI LblNome { get { return lblNome; } }
    public TextMeshProUGUI LblTipo { get { return lblTipo; } }

    public Button BtnPratica { get { return btnPratica; } }
    public Button BtnCacaNiquelPupIndividual { get { return btnCacaNiquelPupIndividual; } }
    public Button BtnCacaNiquelPupGeral { get { return btnCacaNiquelPupGeral; } }    
}
