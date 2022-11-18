using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class MainColetaveisDto 
{
    [SerializeField] private TimerFichaDto timerFichaDto;
    [Space(5)]
    [SerializeField] private Button btnBack;
    [Space(5)]
    [SerializeField] private ScrollRect scrollRect;
    [Space(5)]
    [SerializeField] private MovimentadorArmarioDto movimentadorDto;
    [Space(5)]
    [SerializeField] private PrateleirasDto prateleirasDto;
    [Space(5)]
    [SerializeField] private CanvasDetalheColetavelDto canvasDetalheColetavelDto;
    [Space(5)]
    [SerializeField] private GameObject prefabMateriais;
    [SerializeField] private GameObject prefabLevelsDto;
    [Space(5)]
    [SerializeField] private AudioColetaveisDto audioColetaveisDto;
    [SerializeField] private GameObject prefabLoading;
    [SerializeField] private GameObject[] gosDesligar;
    [Space(5)]
    [SerializeField] private ModalNoFichaDto modalNoFichaDto;

    public TimerFichaDto TimerFichaDto { get { return timerFichaDto; } }
    public Button BtnBack { get { return btnBack; } }
    public ScrollRect ScrollRect { get { return scrollRect; } }    
    public MovimentadorArmarioDto MovimentadorDto { get { return movimentadorDto; } }
    public PrateleirasDto PrateleirasDto { get { return prateleirasDto; } }
    public CanvasDetalheColetavelDto CanvasDetalheColetavelDto { get { return canvasDetalheColetavelDto; } }
    public GameObject PrefabMateriais { get { return prefabMateriais; } }
    public GameObject PrefabLevelsDto { get { return prefabLevelsDto; } }
    public AudioColetaveisDto AudioColetaveisDto { get { return audioColetaveisDto; } }
    public GameObject PrefabLoading { get { return prefabLoading; } }
    public GameObject[] GosDesligar { get { return gosDesligar; } }
    public ModalNoFichaDto ModalNoFichaDto { get { return modalNoFichaDto; } }
}
