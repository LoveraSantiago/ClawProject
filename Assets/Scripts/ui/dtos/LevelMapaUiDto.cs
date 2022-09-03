using UnityEngine;
using UnityEngine.UI;
using TMPro;

#pragma warning disable 0649
[System.Serializable]
public class LevelMapaUiDto
{
    [SerializeField] private float delayEntreBaloes;
    [SerializeField] private float delayInicioMapa;
    [SerializeField] private float delayInicioBaloes;
    [Space(3)]
    [SerializeField] private TextMeshProUGUI lblJorney;
    [SerializeField] private TextMeshProUGUI lblTitle;
    [Space(3)]
    [SerializeField] private Animator animatorMainMapa;
    [SerializeField] private Image imgMapa;
    [Space(3)]
    [SerializeField] private Button[] btnLevels = new Button[10];
    [SerializeField] private BalaoLevelBtnDto[] baloesLevels = new BalaoLevelBtnDto[10];

    public float DelayEntreBaloes { get { return delayEntreBaloes; } }
    public float DelayInicioMapa { get { return delayInicioMapa; } }
    public float DelayInicioBaloes { get { return delayInicioBaloes; } }

    public TextMeshProUGUI LblJorney { get { return lblJorney; } }
    public TextMeshProUGUI LblTitle { get { return lblTitle; } }

    public Animator AnimatorMainMapa { get { return animatorMainMapa; } }
    public Image ImgMapa { get { return imgMapa; } }

    public Button[] BtnLevels { get { return btnLevels; } }
    public BalaoLevelBtnDto[] BaloesLevels { get { return baloesLevels; } }
}
