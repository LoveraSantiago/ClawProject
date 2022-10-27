using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class ModalFailGameDto 
{
    [SerializeField] private Sprite spriteOrderFail;
    [SerializeField] private Sprite spriteTimeOver;
    [SerializeField] private Sprite spriteElevadorFail;
    [Space(3)]
    [SerializeField] private GameObject goModal;
    [SerializeField] private Text txtTitle;
    [SerializeField] private Text txtMsg;
    [SerializeField] private Button btnAvancar;

    public Sprite SpriteOrderFail { get { return spriteOrderFail; } }
    public Sprite SpriteTimeOver { get { return spriteTimeOver; } }
    public Sprite SpriteElevadorFail { get { return spriteElevadorFail; } }

    public GameObject GoModal { get { return goModal; } }
    public Button BtnAvancar { get { return btnAvancar; } }

    public Text TxtTitle { get { return txtTitle; } }
    public Text TxtMsg { get { return txtMsg; } }
}
