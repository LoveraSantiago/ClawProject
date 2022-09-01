using UnityEngine;
using UnityEngine.UI;
using TMPro;

#pragma warning disable 0649
[System.Serializable]
public class LevelMapaUiDto
{
    [SerializeField] private TextMeshProUGUI lblJorney;
    [SerializeField] private TextMeshProUGUI lblTitle;
    [Space(3)]
    [SerializeField] private Image imgMapa;
    [Space(3)]
    [SerializeField] private Button[] btnLevels = new Button[10];

    public TextMeshProUGUI LblJorney { get { return lblJorney; } }
    public TextMeshProUGUI LblTitle { get { return lblTitle; } }

    public Image ImgMapa { get { return imgMapa; } }

    public Button[] BtnLevels { get { return btnLevels; } }
}
