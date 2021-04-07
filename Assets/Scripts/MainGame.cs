using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#pragma warning disable 0649
public class MainGame : MonoBehaviour{

    [SerializeField] private GarraManager.MECANICA_GARRA mecanicaAtual;
    [Space (5)]
    [SerializeField] private ComponentesDaGarraDto componentesDaGarra;
    [Space (5)]
    [SerializeField] private ColetaveisDto coletaveisDto;
    [Space(5)]
    [SerializeField] private MaquinaDto maquinaDto;

    //Componentes uis temporarios aqui...    
    [Space(15)]
    [SerializeField] private GameObject parentParticulas;
    [SerializeField] private GameObject destinoParticulas;
    [SerializeField] private Vector3 posDestinoParticulas;
    [SerializeField] private float velocidadeMovimentacao;
    [Space(5)]
    [SerializeField] private Button btnSair;

    private GarraManager.MECANICA_GARRA mecanicaSelecionada;

    private GarraManager garraManager;
    private ColetavelManager coletaveisManager;
    private MaquinaManager maquinaManager;        

    void OnEnable () {
        //for�ando escala Y pra ficar dentro da safe area
        //float escalaY = Screen.safeArea.height / Screen.height;
        //float escalaX = Screen.safeArea.width / Screen.width;
        //transform.localScale = new Vector3(escalaX, escalaY, transform.localScale.z);
    }

    void Start () {
        //Camera.main.aspect = Utils.RATIO_SCREEN;

        btnSair.onClick.AddListener (() => SceneManager.LoadScene ("TitleScene"));

        mecanicaSelecionada = PlayerPrefsGarraMecanica.recuperarMecanica (mecanicaAtual);
        garraManager = new GarraManager (componentesDaGarra, mecanicaSelecionada);
        coletaveisManager = new ColetavelManager (coletaveisDto);
        maquinaManager = new MaquinaManager(maquinaDto, componentesDaGarra.VelocMovHorizontal, this);

        EfeitoColetado efeitoColetado = new EfeitoColetado(parentParticulas, posDestinoParticulas, velocidadeMovimentacao, this);
        
        new AcaoEventoColetado()
            .configurarProdutor(coletaveisManager.getProdutorDeInfoColetado())
            .adicionarConsumidor(maquinaManager.getDisplayImagensConsumidorInfoColetado())
            .adicionarConsumidor(maquinaManager.getDisplayScoreConsumidorInfoColetado())
            .adicionarConsumidor(efeitoColetado.getEfeitoConsumidorInfoColetado());

        new AcaoSincroniaComDirecaoDaGarra ()
            .configurarProdutor (garraManager.getDisparadorDeEventoDeDirecao ())
            .adicionarConsumidor (maquinaManager.getJoystickHasteConsumidorDirecao ());

        garraManager.start ();
    }

    void Update () {
        garraManager.update ();
        //coletaveis.Update();     
    }

    private void FixedUpdate () {
        garraManager.fixedUpdate ();
        coletaveisManager.fixedUpdate ();
        maquinaManager.fixedUpdate();
    }    
}