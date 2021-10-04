using UnityEngine;
using UnityEngine.EventSystems;

#pragma warning disable 0649
public class MainGameScene : MonoBehaviour, 
                        IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private LevelFlowManager.LEVEL level;
    [Space(5)]
    [SerializeField] private MainGameDto mainDto;

    private MainGameManagers managers;
    private LevelFlowManager.LEVEL levelEscolhido;    

    void OnEnable()
    {
        CameraManager.forceLocalEscala(transform);
    }

    void Start()
    {
        CameraManager.forceAspectCameraAsRatio();
        Utils.configMainMono(this);

        managers = new MainGameManagers(mainDto);
        
        configurandoLevel();
        managers.configurandoEventos();
        managers.startLaizy();
    }    

    private void configurandoLevel()
    {
        LevelFlowManager.LEVEL levelFlow = PlayerPrefsLevel.recuperarELimparLevel(level);
        AbstractLevel levelEscolhido     = LevelFlowManager.getLevelByEnum(levelFlow);
        levelEscolhido.validar();
        managers.configurandoLevel(mainDto, levelEscolhido);
    }       
    
    void Update()
    {
        managers.update();
    }

    private void FixedUpdate()
    {
        managers.fixedUpdate(mainDto);
    }

    //IMPLEMENTACAO FUNCIONALIDADE DRAG AND DROP INICIO
    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector3 posicaoToque = eventData.pointerCurrentRaycast.worldPosition;
        if (managers.inputGame.aconteceuDragNaAreaInferior(posicaoToque))
        {
            managers.maquinaManager.beginDragPowerUp(posicaoToque);
        }       
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        managers.maquinaManager.onEndDragPowerUp();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 posicaoToque = eventData.pointerCurrentRaycast.worldPosition;
        managers.maquinaManager.onDragPowerUp(posicaoToque);
    }
    //IMPLEMENTACAO FUNCIONALIDADE DRAG AND DROP FIM
}