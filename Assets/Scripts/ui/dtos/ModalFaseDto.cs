using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class ModalFaseDto 
{    
    [SerializeField] private Animator animator;
    [Space(3)]
    [SerializeField] private Image imgMiniMaquina;
    [SerializeField] private Image[] imgsColetaveis = new Image[3];
    [Space(3)]
    [SerializeField] private Text lblNivel;
    [SerializeField] private Text lblTipoGame;
    [SerializeField] private Text lblObjetivo;
    [Space(3)]
    [SerializeField] private Button btnFechar;
    [SerializeField] private Button btnLevel;
    [SerializeField] private Button btnFree;
    [Space(3)]
    [SerializeField] private LinhasChallengeDto linhasChallenge;
        
    public Animator Animator { get { return animator; } }

    public Image ImgMiniMaquina { get { return imgMiniMaquina; } }
    public Image[] ImgsColetaveis { get { return imgsColetaveis; } }

    public Text LblNivel { get { return lblNivel; } }
    public Text LblTipoGame { get { return lblTipoGame; } }
    public Text LblObjetivo { get { return lblObjetivo; } }

    public Button BtnFechar { get { return btnFechar; } }
    public Button BtnLevel { get { return btnLevel; } }
    public Button BtnFree { get { return btnFree; } }
        
    public LinhasChallengeDto LinhasChallenges { get { return linhasChallenge; } }
}
