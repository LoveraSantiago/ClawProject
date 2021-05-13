using UnityEngine;
using UnityEngine.EventSystems;

#pragma warning disable 0649
public class MainGameScene : MonoBehaviour, 
                        IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private LevelFlowManager.LEVEL level;    
    [Space(5)]
    [SerializeField] private GarraDto componentesDaGarra;
    [Space(5)]
    [SerializeField] private ColetaveisDto coletaveisDto;
    [Space(5)]
    [SerializeField] private MaquinaDto maquinaDto;
    [Space(5)]
    [SerializeField] private CameraShakeDto camShakeDto;
    [Space(5)]
    [SerializeField] private ParticulasDto particulasDto;
    [Space(5)]
    [SerializeField] private PowerUpDto powerUpDto;
    [Space(5)]
    [SerializeField] private ModalPontosDto modalPontosDto;

    private GarraManager     garraManager;
    private ColetavelManager coletaveisManager;
    private MaquinaManager   maquinaManager;
    private PowerUpManager   powerUpManager;
    private ModalPontos      modalPontos;

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
        Camera.main.aspect = Utils.RATIO_SCREEN;        

        configurandoManagers();
        configurandoLevel();
        configurandoAcoes();
        configurandoEventos();
        startLaizy();
    }

    private void configurandoManagers()
    {
        inputGame         = new InputGameImpl(maquinaDto.ReferenciaChao);
        garraManager      = new GarraManager(componentesDaGarra, inputGame);
        coletaveisManager = new ColetavelManager(coletaveisDto, this);
        maquinaManager    = new MaquinaManager(maquinaDto, componentesDaGarra.VelocMovHorizontal, inputGame, this);
        efeitoColetado    = new EfeitoColetado(particulasDto, this);
        powerUpManager    = new PowerUpManager(powerUpDto, this);
        modalPontos       = new ModalPontos(modalPontosDto, this);
    }

    private void configurandoLevel()
    {
        LevelFlowManager.LEVEL levelFlow = PlayerPrefsLevel.recuperarLevel(level);
        AbstractLevel levelEscolhido = LevelFlowManager.getLevelByEnum(levelFlow);

        garraManager     .configuradoPeloLevel(levelEscolhido.getMecanicaDaGarra());
        coletaveisManager.configuradoPeloLevel(levelEscolhido);
        maquinaManager   .configuradoPeloLevel(levelEscolhido);
        modalPontos      .configurarLevel(levelEscolhido.getLevelName());
    }
    
    private void configurandoAcoes()
    {
        new AcaoEventoColetado()
            .configurarProdutor(coletaveisManager.produtorDeInformacoesDoColetado)            
            .adicionarConsumidor(maquinaManager.getConsumidorInfoColetado())
            .adicionarConsumidor(efeitoColetado.getEfeitoConsumidorInfoColetado())
            .adicionarConsumidor(modalPontos.getConsumidorDeInformacoesColetado());//TODO ver mudanca de ordem

        new AcaoImantadoPelaGarra()
            .configurarProdutor(garraManager.getProdutorDeEventoTocadoPelaGarra())
            .adicionarConsumidor(coletaveisManager.getConsumidorDeColetavelParaImantar());

        new AcaoSubidaDaGarra()
            .configurarProdutor(garraManager.getProdutorDeEventoSubidaDaGarra())
            .adicionarConsumidor(coletaveisManager.getConsumidorDeContagemSubidaDaGarra());
        
        new AcaoSincroniaComDirecaoDaGarra()
            .configurarProdutor(garraManager.getDisparadorDeEventoDeDirecao())
            .adicionarConsumidor(maquinaManager.getJoystickHasteConsumidorDirecao());

        new AcaoPowerUpInicio()
            .configurarProdutor(powerUpManager.produtorDeEventoPowerUp)
            .adicionarConsumidor(garraManager.getConsumidorDePowerUpInfo())
            .adicionarConsumidor(maquinaManager.getConsumidorDePowerUpInfo())
            .adicionarConsumidor(coletaveisManager.getConsumidorDePowerUpInfo());

        new AcaoPowerUpFim()
            .configurarProdutor(powerUpManager.produtorDeEventoFinalizacao)
            .adicionarConsumidor(garraManager.getConsumidorDePowerUpFim())
            .adicionarConsumidor(maquinaManager.getConsumidorDePowerUpFim())
            .adicionarConsumidor(coletaveisManager.getConsumidorDePowerUpFim());

        new AcaoTempoEsgotado()
            .configurarProdutor(maquinaManager.produtorDeTempoAcabado())
            .adicionarConsumidor(modalPontos.getConsumidorDeTempoEsgotado());
    }

    private void configurandoEventos()
    {
        AbstractShake.configurar(camShakeDto);
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
        garraManager.update();
        maquinaManager.update();        
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