using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class MainGameDto 
{
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
    [SerializeField] private GameObject prefabMateriais;

    public BoxCollider2D DragCollider { get { return dragCollider; } }
    public GarraDto GarraDto { get { return garraDto; } }
    public ColetaveisDto ColetaveisDto { get { return coletaveisDto; } }
    public MaquinaDto MaquinaDto { get { return maquinaDto; } }    
    public CameraDto CameraDto { get { return cameraDto;  } }
    public PowerUpGameDto PowerUpDto { get { return powerUpDto; } }
    public UIGameDto UiDto { get { return uiDto; } }    
    public GameObject PrefabMateriais { get { return prefabMateriais; } }
}
