using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainGame : MonoBehaviour
{    
    [Space(5)]
    [SerializeField] private Garra.MECANICA_GARRA mecanicaAtual;
    [SerializeField] private ComponentesDaGarraDto componentesDaGarra;
    [Space(5)]
    [SerializeField] private ColetaveisDto coletaveisDto;
    [Space(5)]
    [SerializeField] private Button btnSair;

    private Garra garra;
    private ColetavelManager coletaveis;

    void Start()
    {
        Garra.MECANICA_GARRA mecanicaSelecionada = PlayerPrefsGarraMecanica.recuperarMecanica(mecanicaAtual);

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
