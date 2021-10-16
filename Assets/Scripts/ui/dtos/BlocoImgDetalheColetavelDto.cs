using UnityEngine;
using UnityEngine.UI;
using TMPro;

#pragma warning disable 0649
[System.Serializable]
public class BlocoImgDetalheColetavelDto 
{
    [SerializeField] private TextMeshProUGUI lblName;
    [SerializeField] private Image imgDetalhe;

    public TextMeshProUGUI LblName { get { return lblName; } }
    public Image ImgDetalhe { get { return imgDetalhe; } }
}
