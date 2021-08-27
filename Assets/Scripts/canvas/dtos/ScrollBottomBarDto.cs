using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class ScrollBottomBarDto 
{
    [SerializeField] private GameObject boxPup;
    [SerializeField] private RectTransform rectTransfHorizontal;
    [SerializeField] private HorizontalLayoutGroup horizontalGroup;

    public GameObject BoxPup { get { return boxPup; } }
    public RectTransform RectTransfHorizontal { get { return rectTransfHorizontal; } }
    public HorizontalLayoutGroup HorizontalGroup { get { return horizontalGroup; } }
}
