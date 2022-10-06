using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class ModalNoFichaDto 
{    
    [SerializeField] private Animator animator;
    [Space(3)]
    [SerializeField] private Image imgFicha;
    [SerializeField] private Color corOuro;
    [SerializeField] private Color corPrata;
    [SerializeField] private Color corBronze;
    [Space(3)]
    [SerializeField] private Button btnOk; 

    public Animator Animator { get { return animator; } }
    public Image ImgFicha { get { return imgFicha; } }
    public Color CorOuro { get { return corOuro; } }
    public Color CorPrata { get { return corPrata; } }
    public Color CorBronze { get { return corBronze; } }
    public Button BtnOk { get { return btnOk; } }
}
