using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class SlotModalCacaNiquelDto 
{
    [SerializeField] private Image imgBackground;
    [SerializeField] private Image imgResultado;

    public Image ImgBackground { get { return imgBackground; } }
    public Image ImgResultado { get { return imgResultado; } }
}
