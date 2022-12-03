using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class MainGameDto 
{
    [SerializeField] private float delayInicio;    
    [Space(5)]
    [SerializeField] private BoxCollider2D dragCollider;
    [Space(5)]
    [SerializeField] private GarraDto garraDto;
    [Space(5)]
    [SerializeField] private ColetaveisDto coletaveisDto;
    [Space(5)]
    [SerializeField] private MaquinaDto maquinaDto;    
    [Space(5)]
    [SerializeField] private CameraDto cameraDto;
    [Space(5)]
    [SerializeField] private PowerUpGameDto powerUpDto;
    [Space(5)]
    [SerializeField] private UIGameDto uiDto;
    [Space(5)]
    [SerializeField] private AudioGameDto audioGameDto;
    [SerializeField] private GameObject prefabLoading;
    [SerializeField] private GameObject[] gosDesligar;
    [Space(5)]
    [SerializeField] private GameObject prefabMateriais;
    [SerializeField] private GameObject prefabLevelsDto;
    [Space(5)]
    [SerializeField] private TutorialDto tutorialDto;

    public float DelayInicio { get { return delayInicio; } }
    public BoxCollider2D DragCollider { get { return dragCollider; } }
    public GarraDto GarraDto { get { return garraDto; } }
    public ColetaveisDto ColetaveisDto { get { return coletaveisDto; } }
    public MaquinaDto MaquinaDto { get { return maquinaDto; } }    
    public CameraDto CameraDto { get { return cameraDto;  } }
    public PowerUpGameDto PowerUpDto { get { return powerUpDto; } }
    public UIGameDto UiDto { get { return uiDto; } }    
    public GameObject PrefabMateriais { get { return prefabMateriais; } }
    public GameObject PrefabLevelsDto { get { return prefabLevelsDto; } }

    public AudioGameDto AudioGameDto { get { return audioGameDto; } }
    public GameObject PrefabLoading { get { return prefabLoading; } }
    public GameObject[] GosDesligar { get { return gosDesligar; } }

    public TutorialDto TutorialDto { get { return tutorialDto; } }
}
