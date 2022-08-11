using UnityEngine;
using TMPro;

#pragma warning disable 0649
[System.Serializable]
public class ItemLevelDto 
{
    [SerializeField] private RectTransform rItem;
    [SerializeField] private TextMeshProUGUI lblLevel;
    [SerializeField] private TextMeshProUGUI lblMap;
    [SerializeField] private TextMeshProUGUI lblMaquina;

    public RectTransform RItem { get { return rItem; } }
    public TextMeshProUGUI LblLevel { get { return lblLevel; } }
    public TextMeshProUGUI LblMap { get { return lblMap; } }
    public TextMeshProUGUI LblMaquina { get { return lblMaquina; } }
}
