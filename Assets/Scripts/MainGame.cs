using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#pragma warning disable 0649
public class MainGame : MonoBehaviour
{
    [SerializeField] private GarraManager.MECANICA_GARRA mecanicaAtual;
    [Space(5)]    
    [SerializeField] private ComponentesDaGarraDto componentesDaGarra;
    [Space(5)]
    [SerializeField] private ColetaveisDto coletaveisDto;
    [Space(5)]
    [SerializeField] private SensoresDto sensoresDto;
    //Componentes uis temporarios aqui...    
    [Space(5)]
    [SerializeField] private Button btnSair;

    private GarraManager.MECANICA_GARRA mecanicaSelecionada;

    private GarraManager garraManager;
    private ColetavelManager coletaveisManager;
    private SensoresManager sensoresManager;

    void OnEnable()
    {
        //forçando escala Y pra ficar dentro da safe area
        //float escalaY = Screen.safeArea.height / Screen.height;
        //float escalaX = Screen.safeArea.width / Screen.width;
        //transform.localScale = new Vector3(escalaX, escalaY, transform.localScale.z);
    }

    void Start()
    {
        //Camera.main.aspect = Utils.RATIO_SCREEN;

        btnSair.onClick.AddListener(() => SceneManager.LoadScene("TitleScene"));

        mecanicaSelecionada = PlayerPrefsGarraMecanica.recuperarMecanica(mecanicaAtual);

        garraManager      = new GarraManager(componentesDaGarra, mecanicaSelecionada);
        coletaveisManager = new ColetavelManager(coletaveisDto);
        sensoresManager   = new SensoresManager(sensoresDto);

        DisplayDeImagens displayDeImgs = new DisplayDeImagens(coletaveisDto.ColetadosPosicoes);

        new AcaoDeColetado()
            .configurarLancadorDeEventoColetado(sensoresManager.getProdutorDeEventoDeColetado())
            
            .adicionarConsumidor(coletaveisManager.getConsumidorDeColetado())
            .adicionarConsumidor(displayDeImgs.getConsumidorDeColetado());
        
        //GARRA NAO PRODUZ MAIS EVENTOS DE TER ACERTADO COLETADO
        //QUEM DEVE EMITIR ESSE EVENTO SERIA O SENSOR DE CIMA DA TELA
        //DEAD CODE AQUI PARA REFERENCIA DE USO (REMOVER)
        //new ProdutorConsumidoresDeEvento<GameObject>()
        //    .configurarProdutor(garra.getProdutorDeEventoColisaoComColetavel())
        //    .adicionarConsumidorDeEvento(coletaveis.getConsumidorDeColetavelAtingito());
    }

    void Update()
    {
        garraManager.update();
        //coletaveis.Update();     
    }

    private void FixedUpdate()
    {
        garraManager.fixedUpdate();
        coletaveisManager.FixedUpdate();
    }
}
