using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class ModalFailOrdemDto 
{
    [SerializeField] private GameObject goModal;
    [SerializeField] private Button btnAvancar;

    public GameObject GoModal { get { return goModal; } }
    public Button BtnAvancar { get { return btnAvancar; } }
}
