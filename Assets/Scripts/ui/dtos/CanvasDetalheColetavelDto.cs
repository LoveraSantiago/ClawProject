using UnityEngine;
using UnityEngine.UI;
using TMPro;

#pragma warning disable 0649
[System.Serializable]
public class CanvasDetalheColetavelDto 
{
    [SerializeField] private Animator animatorCanvas;
    [SerializeField] private Image imgDetalhe;
    [Space(3)]
    [SerializeField] private TextMeshProUGUI lblNome;
    [SerializeField] private TextMeshProUGUI lblFamilia;
    [SerializeField] private TextMeshProUGUI lblTexto;
    [Space(3)]
    [SerializeField] private Canvas canvasBotoes;
    [SerializeField] private Button btnColetavel;

    public Animator AnimatorCanvas { get { return animatorCanvas; } }
    public Image ImgDetalhe { get { return imgDetalhe; } }
    public TextMeshProUGUI LblNome { get { return lblNome; } }
    public TextMeshProUGUI LblFamilia { get { return lblFamilia; } }
    public TextMeshProUGUI LblTexto { get { return lblTexto; } }
    public Canvas CanvasBotoes { get { return canvasBotoes; } }
    public Button BtnColetavel { get { return btnColetavel; } }
}
