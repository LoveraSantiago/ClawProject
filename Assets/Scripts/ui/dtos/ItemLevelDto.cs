using UnityEngine;
using TMPro;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class ItemLevelDto 
{
    [SerializeField] private RectTransform rItem;
    [Space(3)]
    [SerializeField] private Button btnLinha;
    [Space(3)]
    [SerializeField] private Image imgMaquina;
    [SerializeField] private GameObject exclamacao;
    [Space(3)]
    [SerializeField] private TextMeshProUGUI lblLevel;
    [SerializeField] private TextMeshProUGUI lblMap;
    [SerializeField] private TextMeshProUGUI lblMaquina;
    [SerializeField] private TextMeshProUGUI lblTempo;
    [SerializeField] private TextMeshProUGUI lblScore;
    [Space(3)]
    [SerializeField] private Image imgEstrela1;
    [SerializeField] private Image imgEstrela2;
    [SerializeField] private Image imgEstrela3;

    public RectTransform RItem { get { return rItem; } }
    public Button BtnLinha { get { return btnLinha; } }

    public Image ImgMaquina { get { return imgMaquina; } }
    public GameObject Exclamacao { get { return exclamacao; } }

    public TextMeshProUGUI LblLevel { get { return lblLevel; } }
    public TextMeshProUGUI LblMap { get { return lblMap; } }
    public TextMeshProUGUI LblMaquina { get { return lblMaquina; } }
    public TextMeshProUGUI LblTempo { get { return lblTempo; } }
    public TextMeshProUGUI LblScore { get { return lblScore; } }

    public Image ImgEstrela1 { get { return imgEstrela1; } }
    public Image ImgEstrela2 { get { return imgEstrela2; } }
    public Image ImgEstrela3 { get { return imgEstrela3; } }
}
