using UnityEngine;
using TMPro;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class ItemLevelDto 
{
    [SerializeField] private RectTransform rItem;
    [Space(3)]
    [SerializeField] private Image imgMaquina;
    [Space(3)]
    [SerializeField] private TextMeshProUGUI lblLevel;
    [SerializeField] private TextMeshProUGUI lblMap;
    [SerializeField] private TextMeshProUGUI lblMaquina;

    public RectTransform RItem { get { return rItem; } }
    public Image ImgMaquina { get { return imgMaquina; } }
    public TextMeshProUGUI LblLevel { get { return lblLevel; } }
    public TextMeshProUGUI LblMap { get { return lblMap; } }
    public TextMeshProUGUI LblMaquina { get { return lblMaquina; } }
}
