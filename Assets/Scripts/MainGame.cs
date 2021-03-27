using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainGame : MonoBehaviour
{    
    [Space(5)]
    [SerializeField] private Garra.MECANICA_GARRA mecanicaAtual;
    [SerializeField] private ComponentesDaGarraDto componentesDaGarra;
    [Space(5)]
    [SerializeField] private ColetaveisDto coletaveisDto;
    [Space(5)]
    //Componentes uis temporarios aqui...    
    [SerializeField] private Button btnSair;

    private Garra.MECANICA_GARRA mecanicaSelecionada;
    private Garra garra;
    private ColetavelManager coletaveis;    

    void OnEnable()
    {
        //forçando escala Y pra ficar dentro da safe area
        float escalaY = Screen.safeArea.height / Screen.height;
        float escalaX = Screen.safeArea.width / Screen.width;
        transform.localScale = new Vector3(escalaX, escalaY, transform.localScale.z);
    }

    void Start()
    {
        Camera.main.aspect = 0.625f;        

        mecanicaSelecionada = PlayerPrefsGarraMecanica.recuperarMecanica(mecanicaAtual);

        garra = new Garra(componentesDaGarra, mecanicaSelecionada);
        coletaveis = new ColetavelManager(coletaveisDto);
        
        btnSair.onClick.AddListener(() => SceneManager.LoadScene("TitleScene"));        
        //GARRA NAO PRODUZ MAIS EVENTOS DE TER ACERTADO COLETADO
        //QUEM DEVE EMITIR ESSE EVENTO SERIA O SENSOR DE CIMA DA TELA
        //DEAD CODE AQUI PARA REFERENCIA DE USO (REMOVER)
        //new ProdutorConsumidoresDeEvento<GameObject>()
        //    .configurarProdutor(garra.getProdutorDeEventoColisaoComColetavel())
        //    .adicionarConsumidorDeEvento(coletaveis.getConsumidorDeColetavelAtingito());
    }
    
    void Update()
    {     
        garra.update();
        //coletaveis.Update();     
    }

    private void FixedUpdate()
    {        
        garra.fixedUpdate();
        coletaveis.FixedUpdate();        
    }     
}
