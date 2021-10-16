using UnityEngine;
using UnityEngine.UI;

public class BlocoImgColetaveisDto 
{
    [SerializeField] private Button btnEsquerda;
    [SerializeField] private Button btnDireita;
    [Space(5)]
    [SerializeField] private Image[] grupoColetaveis = new Image[7];

    public Button BtnEsquerda { get { return btnEsquerda; } }
    public Button BtnDireita { get { return btnDireita; } }

    public Image[] GrupoColetaveis { get { return grupoColetaveis; } }
}
