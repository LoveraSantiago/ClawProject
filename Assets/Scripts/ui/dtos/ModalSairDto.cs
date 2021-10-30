using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class ModalSairDto 
{
    [SerializeField] private GameObject modalSair;
    [SerializeField] private Button btnSair;
    [SerializeField] private Button btnCancelar;

    public GameObject ModalSair { get { return modalSair; } }
    public Button BtnSair { get { return btnSair; } }
    public Button BtnCancelar { get { return btnCancelar; } }

}
