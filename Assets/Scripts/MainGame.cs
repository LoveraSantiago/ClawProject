using UnityEngine;

public class MainGame : MonoBehaviour
{
    [SerializeField] ComponentesDaGarraDto componentesDaGarra;
    [Space(5)]
    [SerializeField] ColetaveisDto coletaveisDto;

    private Garra garra;
    private ColetavelManager coletaveis;

    void Start()
    {
        garra = new Garra(componentesDaGarra);
        coletaveis = new ColetavelManager(coletaveisDto);

        new ProdutorConsumidoresDeEvento<GameObject>()
            .configurarProdutor(garra.getProdutorDeEventoColisaoComColetavel())
            .adicionarConsumidorDeEvento(coletaveis.getConsumidorDeColetavelAtingito());
    }
    
    void Update()
    {
        garra.Update();
        //coletaveis.Update();
    }

    private void FixedUpdate()
    {
        garra.FixedUpdate();
        coletaveis.FixedUpdate();
    }
}
