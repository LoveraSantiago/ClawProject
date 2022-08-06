using UnityEngine;
using TMPro;

#pragma warning disable 0649
[System.Serializable]
public class ItemLevelDto 
{
    [SerializeField] private RectTransform rItem;
    [SerializeField] private TextMeshProUGUI lblLevel;

    public RectTransform RItem { get { return rItem; } }
    public TextMeshProUGUI LblLevel { get { return lblLevel; } }
}
