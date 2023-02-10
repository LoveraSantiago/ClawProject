using TMPro;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class TimerFichaDto 
{   
    [SerializeField] private Button btnMais;
    [Space(3)]
    [SerializeField] private TextMeshProUGUI lblQdtFichasOld;    
    [SerializeField] private TextMeshProUGUI lblQdtFichasAtual;    
    [SerializeField] private TextMeshProUGUI lblQdtAcrescimo;
    [SerializeField] private Animator animator;
    [Space(3)]
    [SerializeField] private RelogioDto relogioDto;    
    
    public Button BtnMais { get { return btnMais; } }

    public TextMeshProUGUI LblQdtFichasOld { get { return lblQdtFichasOld; } }
    public TextMeshProUGUI LblQdtFichasAtual { get { return lblQdtFichasAtual; } }
    public TextMeshProUGUI LblQdtAcrescimo { get { return lblQdtAcrescimo; } }
    public Animator Animator { get { return animator; } }
    public RelogioDto RelogioDto { get { return relogioDto; } }    
}
