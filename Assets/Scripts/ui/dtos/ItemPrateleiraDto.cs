using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class ItemPrateleiraDto 
{
    [SerializeField] private Image imgItem;
    [SerializeField] private Button btnItem;

    public Image ImgItem { get { return imgItem; } }
    public Button BtnItem { get { return btnItem; } }

    public GameObject GoItem { get { return imgItem.transform.gameObject; } }
}
