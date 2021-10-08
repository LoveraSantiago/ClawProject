using UnityEngine;
using UnityEngine.EventSystems;

#pragma warning disable 0649
public class MainGameScene : MonoBehaviour, 
                        IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private LevelFlowManager.LEVEL level;
    [Space(5)]
    [SerializeField] private MainGameDto mainDto;

    private UpdateMainGameManagers updatableManagers;

    void OnEnable()
    {
        CameraManager.forceLocalEscala(transform);
    }

    void Start()
    {
        CameraManager.forceAspectCameraAsRatio();
        Utils.configMainMono(this);

        AbstractLevel levelEscolhido = carregandoLevelEscolhido();
        MainGameManagers managers = new MainGameManagers(mainDto, levelEscolhido);
        updatableManagers = managers.getUpdatables();
    }    

    private AbstractLevel carregandoLevelEscolhido()
    {
        LevelFlowManager.LEVEL levelFlow = PlayerPrefsLevel.recuperarELimparLevel(level);
        AbstractLevel levelEscolhido     = LevelFlowManager.getLevelByEnum(levelFlow);
        levelEscolhido.validar();
        return levelEscolhido;
    }       
    
    void Update()
    {
        updatableManagers.update(mainDto);
    }

    private void FixedUpdate()
    {
        updatableManagers.fixedUpdate(mainDto);
    }

    //IMPLEMENTACAO FUNCIONALIDADE DRAG AND DROP INICIO
    public void OnBeginDrag(PointerEventData eventData)
    {
        updatableManagers.onBeginDrag(eventData, mainDto);        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        updatableManagers.onEndDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        updatableManagers.onDrag(eventData);        
    }
    //IMPLEMENTACAO FUNCIONALIDADE DRAG AND DROP FIM
}