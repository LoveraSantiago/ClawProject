using UnityEngine;

public class MainGame : MonoBehaviour
{
    public enum MECANICA_GARRA { ZIG_ZAG, TELEGUIADA, ZIG_ZAGTELEGUIADO };

    [Space(5)]
    [SerializeField] private MECANICA_GARRA mecanicaAtual;
    [SerializeField] private ComponentesDaGarraDto componentesDaGarra;
    [Space(5)]
    [SerializeField] private ColetaveisDto coletaveisDto;

    private Garra garra;
    private Coletaveis coletaveis;

    void Start()
    {
        garra = new Garra(componentesDaGarra);
        coletaveis = new Coletaveis(coletaveisDto);

        new ProdutorConsumidoresDeEvento<GameObject>()
            .configurarProdutor(garra.getProdutorDeEventoColisaoComColetavel())
            .adicionarConsumidorDeEvento(coletaveis.getConsumidorDeColetavelAtingito());
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
