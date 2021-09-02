using UnityEngine;
using UnityEngine.EventSystems;

#pragma warning disable 0649
public class MainGameScene : MonoBehaviour, 
                        IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private LevelFlowManager.LEVEL level;
    [Space(5)]
    [SerializeField] private MainDto mainDto;                
    [Space(5)]
    [SerializeField] private PowerUpDto powerUpDto;
    [Space(5)]
    [SerializeField] private ModalPontosDto modalPontosDto;
    [Space(5)]
    [SerializeField] private GameObject prefabBottomBar;

    private ModalPontos       modalPontos;
    private GarraManager      garraManager;
    private MaquinaManager    maquinaManager;
    private PowerUpManager    powerUpManager;
    private ColetaveisManager coletaveisManager;
    private CameraManager     cameraManager;
    private ScrollManager     scrollManager;
    private InputGame inputGame;    

    private LevelFlowManager.LEVEL levelEscolhido;    

    void OnEnable()
    {
        CameraManager.forceLocalEscala(transform);
    }

    void Start()
    {
        CameraManager.forceAspectCameraAsRatio();
        Utils.configMainMono(this);

        configurandoManagers();
        configurandoLevel();
        configurandoAcoes();        
        startLaizy();
    }

    private void configurandoManagers()
    {
        inputGame         = new InputGameImpl(mainDto.MaquinaDto.ReferenciaChao);
        garraManager      = new GarraManager(mainDto.GarraDto);
        coletaveisManager = new ColetaveisManager(mainDto.ColetaveisDto);
        maquinaManager    = new MaquinaManager(mainDto.MaquinaDto);        
        powerUpManager    = new PowerUpManager(powerUpDto, inputGame);
        modalPontos       = new ModalPontos(modalPontosDto);
        cameraManager     = new CameraManager(mainDto.CameraDto);
        scrollManager     = new ScrollManager(prefabBottomBar);        
    }

    private void configurandoLevel()
    {
        LevelFlowManager.LEVEL levelFlow = PlayerPrefsUtils.recuperarELimparLevel(level);
        AbstractLevel levelEscolhido     = LevelFlowManager.getLevelByEnum(levelFlow);

        garraManager     .configuradoPeloLevel(levelEscolhido);
        coletaveisManager.configuradoPeloLevel(levelEscolhido);
        maquinaManager   .configuradoPeloLevel(levelEscolhido);
        modalPontos      .configurarLevel(levelEscolhido.getLevelName());
        scrollManager    .configuradoPeloLevel(levelEscolhido);
    }

    private void configurandoAcoes()
    {
        new AcaoColetado()
            .configurarProdutor(coletaveisManager)
            .adicionarConsumidor(garraManager)
            .adicionarConsumidor(maquinaManager)            
            .adicionarConsumidor(modalPontos);

        new AcaoColetadoFim()
            .configurarProdutor(maquinaManager)
            .adicionarConsumidor(coletaveisManager)
            .adicionarConsumidor(garraManager);            

        new AcaoImantadoPelaGarra()
            .configurarProdutor(garraManager)
            .adicionarConsumidor(coletaveisManager);

        new AcaoSubidaDaGarra()
            .configurarProdutor(garraManager)
            .adicionarConsumidor(coletaveisManager);
        
        new AcaoSincroniaComDirecaoDaGarra()
            .configurarProdutor(garraManager)
            .adicionarConsumidor(maquinaManager);

        new AcaoPUpAcionado()
            .configurarProdutor(powerUpManager)
            .adicionarConsumidor(garraManager)
            .adicionarConsumidor(maquinaManager)
            .adicionarConsumidor(coletaveisManager);

        new AcaoBotaoPUpVazio()
            .configurarProdutor(maquinaManager)
            .adicionarConsumidor(cameraManager)
            .adicionarConsumidor(scrollManager);

        new AcaoBBarPupEscolhido<PowerUpBtnInfo>()
            .configurarProdutor(scrollManager)
            .adicionarConsumidor(maquinaManager)
            .adicionarConsumidor(cameraManager);

        new AcaoTempoEsgotado()
            .configurarProdutor(maquinaManager)
            .adicionarConsumidor(garraManager)            
            .adicionarConsumidor(modalPontos)
            .adicionarConsumidor(coletaveisManager);

        new AcaoBoardElevadoFim()
            .configurarProdutor(coletaveisManager)
            .adicionarConsumidor(maquinaManager)
            .adicionarConsumidor(garraManager)
            .adicionarConsumidor(modalPontos);

        new AcaoCacaNiquel()
            .configurarProdutor(maquinaManager)
            .adicionarConsumidor(cameraManager)
            .adicionarConsumidor(garraManager);
    }   

    private void startLaizy()
    {
        coletaveisManager.start();
        garraManager.start();
        maquinaManager.start();
        scrollManager.start();
    }
    
    void Update()
    {
        inputGame.update();
        garraManager.update(inputGame);
        maquinaManager.update(inputGame);        
    }

    private void FixedUpdate()
    {
        garraManager.fixedUpdate();        
        maquinaManager.fixedUpdate();
    }

    //IMPLEMENTACAO FUNCIONALIDADE DRAG AND DROP INICIO
    public void OnBeginDrag(PointerEventData eventData)
    {        
        if (inputGame.aconteceuDragNaAreaInferior(eventData.pointerCurrentRaycast.worldPosition))
        {
            maquinaManager.beginDragPowerUp(eventData.pointerCurrentRaycast.worldPosition);
        }       
    }

    public void OnEndDrag(PointerEventData eventData)
    {        
        maquinaManager.onEndDragPowerUp();
    }

    public void OnDrag(PointerEventData eventData)
    {        
        maquinaManager.onDragPowerUp(eventData.pointerCurrentRaycast.worldPosition);
    }
    //IMPLEMENTACAO FUNCIONALIDADE DRAG AND DROP FIM
}