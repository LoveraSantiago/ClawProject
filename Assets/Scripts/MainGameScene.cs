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
    [SerializeField] private ParticulasDto particulasDto;
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
    private ScrollBottomBarGameScene scrollBottomBar;

    private InputGame inputGame;
    private EfeitoColetado   efeitoColetado;

    private LevelFlowManager.LEVEL levelEscolhido;    

    void OnEnable()
    {
        //forcando escala Y pra ficar dentro da safe area
        float escalaY = Screen.safeArea.height / Screen.height;
        float escalaX = Screen.safeArea.width / Screen.width;
        transform.localScale = new Vector3(escalaX, escalaY, transform.localScale.z);
    }

    void Start()
    {
        CameraManager.forceAspectCameraAsRatio();

        configurandoManagers();
        configurandoLevel();
        configurandoAcoes();        
        startLaizy();
    }

    private void configurandoManagers()
    {
        inputGame         = new InputGameImpl(mainDto.MaquinaDto.ReferenciaChao);
        garraManager      = new GarraManager(mainDto.GarraDto);
        coletaveisManager = new ColetaveisManager(mainDto.ColetaveisDto, this);
        maquinaManager    = new MaquinaManager(mainDto.MaquinaDto, this);
        efeitoColetado    = new EfeitoColetado(particulasDto, this);
        powerUpManager    = new PowerUpManager(powerUpDto, this, inputGame);
        modalPontos       = new ModalPontos(modalPontosDto, this);
        cameraManager     = new CameraManager(mainDto.CameraDto);
        scrollBottomBar   = new ScrollBottomBarGameScene(prefabBottomBar, this);
    }

    private void configurandoLevel()
    {
        LevelFlowManager.LEVEL levelFlow = PlayerPrefsLevel.recuperarLevel(level);
        AbstractLevel levelEscolhido     = LevelFlowManager.getLevelByEnum(levelFlow);

        garraManager     .configuradoPeloLevel(levelEscolhido);
        coletaveisManager.configuradoPeloLevel(levelEscolhido);
        maquinaManager   .configuradoPeloLevel(levelEscolhido);
        modalPontos      .configurarLevel(levelEscolhido.getLevelName());
    }

    private void configurandoAcoes()
    {
        new AcaoColetado()
            .configurarProdutor(coletaveisManager)
            .adicionarConsumidor(garraManager)
            .adicionarConsumidor(maquinaManager)
            .adicionarConsumidor(efeitoColetado)
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

        new AcaoPUpInfo()
            .configurarProdutor(powerUpManager)
            .adicionarConsumidor(garraManager)
            .adicionarConsumidor(maquinaManager)
            .adicionarConsumidor(coletaveisManager);

        new AcaoPUpEscolha()
            .configurarProdutor(maquinaManager)
            .adicionarConsumidor(cameraManager)
            .adicionarConsumidor(scrollBottomBar);

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
    }   

    private void startLaizy()
    {
        coletaveisManager.start();
        garraManager.start();
        maquinaManager.start();
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
        maquinaManager.onEndDragPowerUp(this);
    }

    public void OnDrag(PointerEventData eventData)
    {        
        maquinaManager.onDragPowerUp(eventData.pointerCurrentRaycast.worldPosition);
    }
    //IMPLEMENTACAO FUNCIONALIDADE DRAG AND DROP FIM
}