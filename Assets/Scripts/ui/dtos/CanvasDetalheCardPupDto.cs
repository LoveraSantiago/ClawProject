using UnityEngine;
using UnityEngine.UI;
using TMPro;

#pragma warning disable 0649
[System.Serializable]
public class CanvasDetalheCardPupDto
{
    [SerializeField] private float delayMostrarPremios;
    [Space(3)]    
    [SerializeField] private Image imgBackground;
    [SerializeField] private Image imgCirculo;
    [SerializeField] private Image imgExplicacao;
    [SerializeField] private Image imgPup;    
    [Space(3)]
    [SerializeField] private Image[] imgCorBtnPrincipal  = new Image[3];
    [SerializeField] private Image[] imgCorBtnSecundario = new Image[3];    
    [SerializeField] private Image[] imgBtns               = new Image[3];    
    [Space(3)]
    [SerializeField] private TextMeshProUGUI lblPreco;
    [SerializeField] private TextMeshProUGUI lblExplicacao;
    [SerializeField] private TextMeshProUGUI lblQtd;
    [SerializeField] private TextMeshProUGUI lblQtdGanhos;
    [SerializeField] private TextMeshProUGUI lblNome;
    [SerializeField] private TextMeshProUGUI lblTipo;
    [Space(3)]
    [SerializeField] private Button btnPratica;
    [SerializeField] private Button btnCacaNiquelPupIndividual;
    [SerializeField] private Button btnCacaNiquelPupGeral;    

    public float DelayMostrarPremios { get { return delayMostrarPremios; } }
    public Image ImgBackground { get { return imgBackground; } }
    public Image ImgCirculo { get { return imgCirculo; } }
    public Image ImgExplicacao { get { return imgExplicacao; } }
    public Image ImgPup { get { return imgPup; } }    
    
    public Image[] ImgCorBtnPrin { get { return imgCorBtnPrincipal; } }    
    public Image[] ImgCorBtnSec { get { return imgCorBtnSecundario; } }        
    public Image[] ImgBtns { get { return imgBtns; } }        

    public TextMeshProUGUI LblPreco { get { return lblPreco; } }
    public TextMeshProUGUI LblExplicacao { get { return lblExplicacao; } }
    public TextMeshProUGUI LblQtd { get { return lblQtd; } }
    public TextMeshProUGUI LblQtdGanhos { get { return lblQtdGanhos; } }
    public TextMeshProUGUI LblNome { get { return lblNome; } }
    public TextMeshProUGUI LblTipo { get { return lblTipo; } }

    public Button BtnPratica { get { return btnPratica; } }
    public Button BtnCacaNiquelPupIndividual { get { return btnCacaNiquelPupIndividual; } }
    public Button BtnCacaNiquelPupGeral { get { return btnCacaNiquelPupGeral; } }    
}
