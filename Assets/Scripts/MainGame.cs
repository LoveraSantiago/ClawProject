using UnityEngine;

public class MainGame : MonoBehaviour
{    
    [Space(5)]
    [SerializeField] private GerenciadorDeMovimentacao.MECANICA_GARRA mecanicaAtual;
    [SerializeField] private ComponentesDaGarraDto componentesDaGarra;
    [Space(5)]
    [SerializeField] private ColetaveisDto coletaveisDto;

    private Garra garra;
    private Coletaveis coletaveis;

    void Start()
    {
        garra = new Garra(componentesDaGarra, mecanicaAtual);
        coletaveis = new Coletaveis(coletaveisDto);

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
