using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class LinhaModalCacaNiquelDto 
{
    [SerializeField] private Image imgLinha;
    [SerializeField] private Text lblLinha;

    public Image ImgLinha { get { return imgLinha; } }
    public Text LblLinha { get { return lblLinha; } }


}
