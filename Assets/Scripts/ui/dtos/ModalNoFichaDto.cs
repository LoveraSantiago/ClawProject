using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class ModalNoFichaDto 
{
    [SerializeField] private GameObject modalNoFicha;
    [SerializeField] private Button btnOk;

    public GameObject ModalNoFicha { get { return modalNoFicha; } }
    public Button BtnOk { get { return btnOk; } }
}
