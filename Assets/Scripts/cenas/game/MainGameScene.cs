using UnityEngine;
using UnityEngine.EventSystems;

#pragma warning disable 0649
public class MainGameScene : MonoBehaviour, 
                        IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Level level;
    [Space(5)]
    [SerializeField] private MainGameDto mainDto;

    private UpdaterMainGameManagers updaterManagers;

    void OnEnable()
    {
        CameraManager.forceLocalEscala(transform);
    }

    void Start()
    {
        CameraManager.forceAspectCameraAsRatio();
        Utils.configMainMono(this);
        MateriaisUtils.configurar(mainDto.PrefabMateriais);
        FactoryPowerUpEntidade.resetContextoEstatico();

        AbstractLevel levelEscolhido = LevelUtils.loadLevelEscolhido(level);
        MainGameManagers managers = new MainGameManagers(mainDto, levelEscolhido);
        updaterManagers = managers.getUpdatables();
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
    //IMPLEMENTACAO FUNCIONALIDADE DRAG AND DROP FIM
}