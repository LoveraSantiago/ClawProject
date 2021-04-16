using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

#pragma warning disable 0649
public class MainGame : MonoBehaviour, 
                        IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private GarraManager.MECANICA_GARRA mecanicaAtual;
    [Space(5)]
    [SerializeField] private GarraDto componentesDaGarra;
    [Space(5)]
    [SerializeField] private ColetaveisDto coletaveisDto;
    [Space(5)]
    [SerializeField] private MaquinaDto maquinaDto;
    [Space(5)]
    [SerializeField] private ParticulasDto particulasDto;

    //Componentes uis temporarios aqui...    
    [Space(15)]
    [SerializeField] private Button btnSair;

    private GarraManager.MECANICA_GARRA mecanicaSelecionada;

    private GarraManager     garraManager;
    private ColetavelManager coletaveisManager;
    private MaquinaManager   maquinaManager;
    private PowerUpManager   powerUpManager;

    private InputGame inputGame;
    private EfeitoColetado   efeitoColetado;

    void OnEnable()
    {
        //for�ando escala Y pra ficar dentro da safe area
        //float escalaY = Screen.safeArea.height / Screen.height;
        //float escalaX = Screen.safeArea.width / Screen.width;
        //transform.localScale = new Vector3(escalaX, escalaY, transform.localScale.z);
    }

    void Start()
    {
        //Camera.main.aspect = Utils.RATIO_SCREEN;

        btnSair.onClick.AddListener(() => SceneManager.LoadScene("TitleScene"));

        mecanicaSelecionada = PlayerPrefsGarraMecanica.recuperarMecanica(mecanicaAtual);

        inputGame         = new InputGameImpl(maquinaDto.ReferenciaChao);
        garraManager      = new GarraManager(componentesDaGarra, mecanicaSelecionada, inputGame);
        coletaveisManager = new ColetavelManager(coletaveisDto, this);
        maquinaManager    = new MaquinaManager(maquinaDto, componentesDaGarra.VelocMovHorizontal, inputGame, this);
        efeitoColetado    = new EfeitoColetado(particulasDto, this);
        powerUpManager    = new PowerUpManager();

        configurandoAcoes();
        startLaizy();
    }
    
    private void configurandoAcoes()
    {
        new AcaoEventoColetado()
            .configurarProdutor(coletaveisManager.produtorDeInformacoesDoColetado)
            .adicionarConsumidor(maquinaManager.getDisplayImagensConsumidorInfoColetado())
            .adicionarConsumidor(maquinaManager.getDisplayScoreConsumidorInfoColetado())
            .adicionarConsumidor(efeitoColetado.getEfeitoConsumidorInfoColetado());//TODO ver mudanca de ordem

        new AcaoImantadoPelaGarra()
            .configurarProdutor(garraManager.getProdutorDeEventoTocadoPelaGarra())
            .adicionarConsumidor(coletaveisManager.getConsumidorDeColetavelParaImantar());

        new AcaoSubidaDaGarra()
            .configurarProdutor(garraManager.getProdutorDeEventoSubidaDaGarra())
            .adicionarConsumidor(coletaveisManager.getConsumidorDeContagemSubidaDaGarra());

        new AcaoGarraCentralizadaPUp()//TODO TIRAR
            .configurarProdutor(garraManager.getProdutorDeEventoGarraCentralizadaPup())
            .adicionarConsumidor(coletaveisManager.getConsumidorDePosicaoDeGarraCentralizada());

        new AcaoSincroniaComDirecaoDaGarra()
            .configurarProdutor(garraManager.getDisparadorDeEventoDeDirecao())
            .adicionarConsumidor(maquinaManager.getJoystickHasteConsumidorDirecao());

        new AcaoPowerUp()
            .configurarProdutor(powerUpManager.produtorDeEventoPowerUp);
    }

    private void startLaizy()
    {
        coletaveisManager.start();
        garraManager.start();
        maquinaManager.recebendoPowerUp(powerUpManager.distribuirPowerUpParaMaquina());
    }

    void Update()
    {
        inputGame.update();
        garraManager.update();
        maquinaManager.update();
        //coletaveis.Update();     
    }

    private void FixedUpdate()
    {
        garraManager.fixedUpdate();
        coletaveisManager.fixedUpdate();
        maquinaManager.fixedUpdate();
    }

    //IMPLEMENTACAO FUNCIONALIDADE DRAG AND DROP INICIO
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag: " + eventData.pointerCurrentRaycast.worldPosition);
        if (inputGame.aconteceuDragNaAreaInferior(eventData.pointerCurrentRaycast.worldPosition))
        {
            maquinaManager.beginDragPowerUp(eventData.pointerCurrentRaycast.worldPosition);
        }       
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        maquinaManager.onEndDragPowerUp();
    }

    public void OnDrag(PointerEventData eventData)
    {
        maquinaManager.onDragPowerUp(eventData.pointerCurrentRaycast.worldPosition);
    }
    //IMPLEMENTACAO FUNCIONALIDADE DRAG AND DROP FIM
}