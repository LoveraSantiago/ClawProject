using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class CardsPupsDto
{
    [SerializeField] private Button btn;
    [SerializeField] private Image imgCard;

    public Button Btn { get { return btn; } }
    public Image ImgCard { get { return imgCard; } }
}
