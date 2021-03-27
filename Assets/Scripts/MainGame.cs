using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainGame : MonoBehaviour
{    
    [Space(5)]
    [SerializeField] private Garra.MECANICA_GARRA mecanicaAtual;
    [SerializeField] private ComponentesDaGarraDto componentesDaGarra;
    [Space(5)]
    [SerializeField] private ColetaveisDto coletaveisDto;
    [Space(5)]
    //Componentes uis temporarios aqui...
    [SerializeField] private Button btnDuvida;
    [SerializeField] private Button btnSair;
    [SerializeField] private Canvas canvasInformacao;
    [SerializeField] private TextMeshProUGUI lblMecanica;
    [SerializeField] private TextMeshProUGUI lblExplicacao;
    [SerializeField] private Button btnOk;

    private Garra.MECANICA_GARRA mecanicaSelecionada;
    private Garra garra;
    private ColetavelManager coletaveis;

    private bool mostrandoCanvas;

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

        btnDuvida.onClick.AddListener(() => ligarCanvasDuvida());
        btnSair.onClick.AddListener(() => SceneManager.LoadScene("TitleScene"));
        btnOk.onClick.AddListener(() => desligarCanvasDuvida());
        //GARRA NAO PRODUZ MAIS EVENTOS DE TER ACERTADO COLETADO
        //QUEM DEVE EMITIR ESSE EVENTO SERIA O SENSOR DE CIMA DA TELA
        //DEAD CODE AQUI PARA REFERENCIA DE USO (REMOVER)
        //new ProdutorConsumidoresDeEvento<GameObject>()
        //    .configurarProdutor(garra.getProdutorDeEventoColisaoComColetavel())
        //    .adicionarConsumidorDeEvento(coletaveis.getConsumidorDeColetavelAtingito());
    }
    
    void Update()
    {
        if (mostrandoCanvas)
        {

        }
        else
        {
            garra.update();
            //coletaveis.Update();
        }
    }

    private void FixedUpdate()
    {
        if (mostrandoCanvas)
        {

        }
        else
        {
            garra.fixedUpdate();
            coletaveis.FixedUpdate();
        }
    }

    private void ligarCanvasDuvida()
    {
        mostrandoCanvas = true;
        canvasInformacao.gameObject.SetActive(true);
        switch (mecanicaSelecionada)
        {
            case (Garra.MECANICA_GARRA.ZIG_ZAG):
                lblMecanica.text = "ZIG-ZAG";
                lblExplicacao.text = "A garra fica se movimentando para direita e esquerda continuamente.\nToque na tela para faze-la descer até os coletaveis.";
                break;

            case (Garra.MECANICA_GARRA.TELEGUIADA):
                lblMecanica.text = "TELEGUIADA";
                lblExplicacao.text = "A garra fica parada.\nToque nos coletaveis da tela para fazer a garra descer.";
                break;

            case (Garra.MECANICA_GARRA.ZIG_ZAGTELEGUIADO):
                lblMecanica.text = "ZIG-ZAG-TELEGUIADA";
                lblExplicacao.text = "A garra fica se movimentando para direita e esquerda continuamente.\nToque nos coletaveis da tela para fazer a garra descer.";
                break;
        }
    }

    private void desligarCanvasDuvida()
    {
        mostrandoCanvas = false;
        canvasInformacao.gameObject.SetActive(false);
    }
}
