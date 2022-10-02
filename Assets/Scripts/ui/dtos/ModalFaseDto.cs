using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class ModalFaseDto 
{
    [SerializeField] private GameObject modalFase;
    [Space(5)]
    [SerializeField] private Image imgMiniMaquina;
    [Space(5)]
    [SerializeField] private Text lblNivel;
    [SerializeField] private Text lblObjetivo;
    [Space(5)]
    [SerializeField] private Button btnFechar;
    [SerializeField] private Button btnLevel;

    public GameObject ModalFase { get { return modalFase; } }

    public Image ImgMiniMaquina { get { return imgMiniMaquina; } }

    public Text LblNivel { get { return lblNivel; } }
    public Text LblObjetivo { get { return lblObjetivo; } }

    public Button BtnFechar { get { return btnFechar; } }
    public Button BtnLevel { get { return btnLevel; } }
}
