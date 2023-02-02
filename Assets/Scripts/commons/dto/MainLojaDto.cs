using TMPro;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class MainLojaDto 
{
    [SerializeField] private TimerFichaDto[] timerFichaDto = new TimerFichaDto[3];
    [Space(5)]
    [SerializeField] private Button btnVoltar;    
    [Space(5)]
    [SerializeField] private Button btnOuro;
    [SerializeField] private Button btnPrata;
    [SerializeField] private Button btnBronze;
    [Space(5)]
    [SerializeField] private Button btnAssinatura;
    [Space(5)]
    [SerializeField] private AudioLojaDto audioLojaDto;
    [SerializeField] private GameObject prefabLoading;
    [SerializeField] private GameObject[] gosDesligar;

    public TimerFichaDto[] TimerFichaDto { get { return timerFichaDto; } }
    public Button BtnVoltar { get { return btnVoltar; } }    
    public Button BtnOuro { get { return btnOuro; } }
    public Button BtnPrata { get { return btnPrata; } }
    public Button BtnBronze { get { return btnBronze; } }
    public Button BtnAssinatura { get { return btnAssinatura; } }

    public AudioLojaDto AudioLojaDto { get { return audioLojaDto; } }
    public GameObject PrefabLoading { get { return prefabLoading; } }
    public GameObject[] GosDesligar { get { return gosDesligar; } }

}
