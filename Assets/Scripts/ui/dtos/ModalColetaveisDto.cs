using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class ModalColetaveisDto 
{
    [SerializeField] private GameObject modal;
    [Space(3)]
    [SerializeField] private Text lblLevelTitle;
    [SerializeField] private Text lblMsg;
    [Space(3)]
    [SerializeField] private Image imgColetavel;
    [Space(3)]
    [SerializeField] private Button btnAvancar;

    public GameObject Modal { get { return modal; } }

    public Text LblLevelTitle { get { return lblLevelTitle; } }
    public Text LblMsg { get { return lblMsg; } }

    public Image ImgColetavel { get { return imgColetavel; } }
    public Button BtnAvancar { get { return btnAvancar; } }
}
