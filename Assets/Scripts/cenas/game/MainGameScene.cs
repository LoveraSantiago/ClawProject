using UnityEngine;
using UnityEngine.EventSystems;

#pragma warning disable 0649
public class MainGameScene : MonoBehaviour, 
                             Consumidor<UpdaterManagers>,
                             IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private int indiceMapa;
    [SerializeField] private int indiceLevel;
    [Space(5)]
    [SerializeField] private MainGameDto mainDto;

    private UpdaterManagers updaterManagers;

    void OnEnable()
    {
        CameraManager.forceLocalEscala(transform);
    }

    void Start()
    {
        CameraManager.forceAspectCameraAsRatio();
        ContextoEstaticoUtils.configMainMono(this);
        MateriaisUtils.configurar(mainDto.PrefabMateriais);
        FactoryPowerUpEntidade.resetContextoEstatico();

        PrefabLevelsDto prefabLevels = mainDto.PrefabLevelsDto.GetComponent<PrefabLevelsDto>();
        FactoryMapaEntidade.configurar(prefabLevels);

        AbstractLevel levelEscolhido = ContextoEstaticoUtils.loadLevelEstaticoAtualOrCreateLevel(indiceMapa, indiceLevel);
        MainGameManagers managers = new MainGameManagers(mainDto, levelEscolhido, this);        
    }        
    
    void Update()
    {
        updaterManagers.update(mainDto);
    }

    private void FixedUpdate()
    {
        updaterManagers.fixedUpdate(mainDto);
    }

    //IMPLEMENTACAO FUNCIONALIDADE DRAG AND DROP INICIO
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("original begin drag");
        updaterManagers.onBeginDrag(eventData, mainDto);        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        updaterManagers.onEndDrag(eventData, mainDto);
    }

    public void OnDrag(PointerEventData eventData)
    {
        updaterManagers.onDrag(eventData, mainDto);        
    }

    public void consumir(UpdaterManagers evento)
    {
        this.updaterManagers = evento;
    }
    //IMPLEMENTACAO FUNCIONALIDADE DRAG AND DROP FIM
}