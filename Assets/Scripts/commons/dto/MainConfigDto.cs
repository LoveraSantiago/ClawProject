using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class MainConfigDto 
{
    [SerializeField] private Button btnBack;
    [SerializeField] private Button btnReset;
    [SerializeField] private Button btnCreditos;
    [SerializeField] private Button btnFecharCreditos;
    [Space(5)]
    [SerializeField] private Animator animator;
    [Space(5)]
    [SerializeField] private TogglesGeneroDto togglesGeneroDto;    
    [Space(5)]
    [SerializeField] private Slider sliderVolume;
    [SerializeField] private AudioConfigDto audioConfigDto;
    [Space(5)]
    [SerializeField] private GameObject prefabLoading;
    [SerializeField] private GameObject[] gosDesligar;

    public Button BtnBack { get { return btnBack; } }
    public Button BtnReset { get { return btnReset; } }
    public Button BtnCreditos { get { return btnCreditos; } }
    public Button BtnFecharCreditos { get { return btnFecharCreditos; } }
    public Animator Animator { get { return animator; } }

    public TogglesGeneroDto TogglesGeneroDto { get { return togglesGeneroDto; } }   

    public Slider SliderVolume { get { return sliderVolume; } }
    public AudioConfigDto AudioConfigDto { get { return audioConfigDto; } }

    public GameObject PrefabLoading { get { return prefabLoading; } }
    public GameObject[] GosDesligar { get { return gosDesligar; } }
}
