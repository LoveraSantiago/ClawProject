using UnityEngine;
using UnityEngine.UI;
using TMPro;

#pragma warning disable 0649
[System.Serializable]
public class BlocoImgDetalheColetavelDto 
{
    [SerializeField] private TextMeshProUGUI lblName;
    [SerializeField] private Image imgDetalhe;
    [Space(5)]
    [SerializeField] private Button btnGanharColetavel;

    public TextMeshProUGUI LblName { get { return lblName; } }
    public Image ImgDetalhe { get { return imgDetalhe; } }

    public Button BtnGanharColetavel { get { return btnGanharColetavel; } }
}
