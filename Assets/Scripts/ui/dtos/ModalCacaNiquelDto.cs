using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class ModalCacaNiquelDto
{
    [SerializeField] private GameObject modal;
    [Space(3)]
    [SerializeField] private Image imgHeadPup;
    [SerializeField] private Text lblNomePup;
    [Space(3)]
    [SerializeField] private SlotModalCacaNiquelDto[] slotsCacaNiquel = new SlotModalCacaNiquelDto[3];
    [Space(3)]
    [SerializeField] private LinhaModalCacaNiquelDto[] linhaResult = new LinhaModalCacaNiquelDto[3];

    public GameObject Modal { get { return modal; } }
    public Image ImgHeadPup { get { return imgHeadPup; } }
    public Text LblNomePup { get { return lblNomePup; } }

    public SlotModalCacaNiquelDto[] SlotsCacaNiquel { get { return slotsCacaNiquel; } }
    public LinhaModalCacaNiquelDto[] LinhaResult { get { return linhaResult; } }
}
