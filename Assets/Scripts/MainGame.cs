using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#pragma warning disable 0649
public class MainGame : MonoBehaviour, ConsumidorDeEvento<InformacoesColetado> {
    [SerializeField] private GarraManager.MECANICA_GARRA mecanicaAtual;
    [Space (5)]
    [SerializeField] private ComponentesDaGarraDto componentesDaGarra;
    [Space (5)]
    [SerializeField] private ColetaveisDto coletaveisDto;
    [Space (5)]
    [SerializeField] private SensoresDto sensoresDto;
    //Componentes uis temporarios aqui...    
    [Space (5)]
    [SerializeField] private SpriteRenderer[] coletadosSprites = new SpriteRenderer[3]; //3
    [SerializeField] private GameObject displayScore1;
    [SerializeField] private GameObject displayScore2;
    [SerializeField] private GameObject displayScore3;
    [SerializeField] private Button btnSair;
    [SerializeField] private Transform hasteJoystick;
    [SerializeField] private GameObject parentParticulas;


    private GarraManager.MECANICA_GARRA mecanicaSelecionada;

    private GarraManager garraManager;
    private ColetavelManager coletaveisManager;
    private SensoresManager sensoresManager;
    private JoystickHaste joystickHaste;

    private ParticleSystem particleSystem;

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
        sensoresManager = new SensoresManager (sensoresDto);

        particleSystem = parentParticulas.GetComponent<ParticleSystem>();
        particleSystem.Stop();
        particleSystem.gameObject.SetActive(true);

        //TEMPORARIO AQUI.... TALVEZ DEVESSEM ESTAR DENTROS DE UM OUTRO OBJETO AINDA NAO SEI               
        DisplayDeImagens displayDeImgs = new DisplayDeImagens (coletadosSprites, 0.5f, this);
        DisplayDeScores displayDeScores = new DisplayDeScores (displayScore1, displayScore2, displayScore3);
        joystickHaste = new JoystickHaste (hasteJoystick, componentesDaGarra.VelocMovHorizontal);

        new PipelineDeEventoColetado ()
            .configStep1LancadorDeEventoColetado (sensoresManager.getProdutorDeEventoDeColetado ())
            .configStep2ProcessadorDeColetado (coletaveisManager.getProcessadorDeColetado ())
            .configStep3DisplayImgConsumidor (displayDeImgs.getDisplayImgConsumidor ())
            .configStep4displayScoreConsumidor (displayDeScores.getDisplayScoreConsumidor ())
            .configStep5displayScoreConsumidor(this);

        new AcaoSincroniaComDirecaoDaGarra ()
            .configurarProdutor (garraManager.getDisparadorDeEventoDeDirecao ())
            .adicionarConsumidor (joystickHaste.getConsumidorDeEventoDeDirecao ());

        garraManager.start ();
    }

    void Update () {
        garraManager.update ();
        //coletaveis.Update();     
    }

    private void FixedUpdate () {
        garraManager.fixedUpdate ();
        coletaveisManager.FixedUpdate ();
        joystickHaste.fixedUpdate ();
    }

    public void consumirEvento(InformacoesColetado evento)
    {
        Debug.Log("Disparar particulas");
        particleSystem.Play();
    }
}