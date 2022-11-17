using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class MainPupDto 
{
    [SerializeField] private TimerFichaDto timerFichaDto;
    [Space(5)]
    [SerializeField] private Button btnBack;
    [Space(5)]
    [SerializeField] private CardPupDetalheDto cardDetalheDto;
    [Space(5)]
    [SerializeField] private CanvasDetalheCardPupDto canvasDetalheDto;
    [Space(5)]
    [SerializeField] private CardsPupsDto[] cardsPupsDto;
    [Space(5)]
    [SerializeField] private FichaAnimadaDto fichaAnimadaDto;
    [Space(5)]
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private Animator animator;
    [Space(5)]
    [SerializeField] private AudioPupDto audioPupDto;
    [SerializeField] private GameObject prefabLoading;
    [SerializeField] private GameObject[] gosDesligar;
    [Space(5)]
    [SerializeField] private GameObject prefabPowerUpDto;
    [SerializeField] private GameObject prefabLevesDto;
    [Space(5)]
    [SerializeField] private ModalNoFichaDto modalNoFichaDto;

    public TimerFichaDto TimerFichaDto { get { return timerFichaDto; } }
    public Button BtnBack { get { return btnBack; } }
    public CardPupDetalheDto CardDetalheDto { get { return cardDetalheDto; } }
    public CanvasDetalheCardPupDto CanvasDetalheDto { get { return canvasDetalheDto; } }
    public CardsPupsDto[] CardsPupsDto { get { return cardsPupsDto; } }
    public FichaAnimadaDto FichaAnimadaDto { get { return fichaAnimadaDto; } }
    public ScrollRect ScrollRect { get { return scrollRect; } }
    public Animator Animator { get { return animator; } }

    public AudioPupDto AudioPupDto { get { return audioPupDto; } }
    public GameObject PrefabLoading { get { return prefabLoading; } }
    public GameObject[] GosDesligar { get { return gosDesligar; } }

    public GameObject PrefabPowerUpDto { get { return prefabPowerUpDto; } }
    public GameObject PrefabLevesDto { get { return prefabLevesDto; } }
    public ModalNoFichaDto ModalNoFichaDto { get { return modalNoFichaDto; } }
}
