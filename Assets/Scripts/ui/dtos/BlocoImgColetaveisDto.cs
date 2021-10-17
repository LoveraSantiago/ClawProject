using UnityEngine;
using UnityEngine.UI;
using TMPro;

#pragma warning disable 0649
[System.Serializable]
public class BlocoImgColetaveisDto 
{
    [SerializeField] private TextMeshProUGUI lblNomeFamilia;
    [Space(5)]
    [SerializeField] private Button btnEsquerda;
    [SerializeField] private Button btnDireita;
    [Space(5)]   
    [SerializeField] private Image[] grupoImgsColetaveis = new Image[7];    

    public Button BtnEsquerda { get { return btnEsquerda; } }
    public Button BtnDireita { get { return btnDireita; } }
    
    public Image[] GrupoImgColetaveis { get { return grupoImgsColetaveis; } }
    public TextMeshProUGUI LblNomeFamilia { get { return lblNomeFamilia; } }
}
