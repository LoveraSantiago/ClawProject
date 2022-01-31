using TMPro;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class TimerFichaDto 
{   
    [SerializeField] private Image imgMoeda;
    [SerializeField] private Button btnMais;
    [SerializeField] private TextMeshProUGUI lblQdtFichas;
    [Space(5)]
    [SerializeField] private RelogioDto relogioDto;
    
    public Image ImgMoeda { get { return imgMoeda; } }
    public Button BtnMais { get { return btnMais; } }

    public TextMeshProUGUI LblQdtFichas { get { return lblQdtFichas; } }
    public RelogioDto RelogioDto { get { return relogioDto; } }    
}
