using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class ItemPrateleiraDto 
{
    [SerializeField] private Image imgItem;
    [SerializeField] private Button btnItem;
    [SerializeField] private GameObject imgExclamacao;

    public Image ImgItem { get { return imgItem; } }
    public Button BtnItem { get { return btnItem; } }
    public GameObject ImgExclamacao { get { return imgExclamacao; } }

    public GameObject GoItem { get { return imgItem.transform.gameObject; } }
}
