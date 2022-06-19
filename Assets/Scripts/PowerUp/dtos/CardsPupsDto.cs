using UnityEngine;
using UnityEngine.UI;
using TMPro;

#pragma warning disable 0649
[System.Serializable]
public class CardsPupsDto
{
    [SerializeField] private Button btn;
    [SerializeField] private Image imgContornoCard;
    [SerializeField] private Image imgCard;
    [SerializeField] private TextMeshProUGUI lblPreco;
    [SerializeField] private TextMeshProUGUI lblQtd;

    public Button Btn { get { return btn; } }
    public Image ImgContornoCard { get { return imgContornoCard; } }
    public Image ImgCard { get { return imgCard; } }
    public TextMeshProUGUI LblPreco { get { return lblPreco; } }
    public TextMeshProUGUI LblQtd { get { return lblQtd; } }
}
