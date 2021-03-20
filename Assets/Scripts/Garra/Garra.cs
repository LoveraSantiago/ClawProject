using UnityEngine;

public class Garra : CommunicatorComGarra
{
    private Vector2 posicaoInicial;

    private MovimentacaoDaGarra movimentacaoAtual;    
    private MovimentacaoDaGarra movimentacaoParaBaixo;
    private MovimentacaoDaGarra movimentacaoAgarrando;
    private MovimentacaoParaCima movimentacaoParaCima;
    private MovimentacaoDaGarra movimentacaoLateral;

    private ProdutorDeEvento<GameObject> produtorDeEventoAtingiuColetavel;

    public Garra(ComponentesDaGarraDto componentesDaGarraDto)
    {
        MovimentacaoDaGarra.configurarComponentesDaGarraDto(componentesDaGarraDto);
        MovimentacaoAgarrando.configurarCommunicatorComGarra(this);

        produtorDeEventoAtingiuColetavel = new ProdutorDeEvento<GameObject>();

        movimentacaoLateral   = new MovimentacaoLateral();
        movimentacaoParaCima  = new MovimentacaoParaCima();
        movimentacaoParaBaixo = new MovimentacaoParaBaixo(produtorDeEventoAtingiuColetavel);
        movimentacaoAgarrando = new MovimentacaoAgarrando();
        movimentacaoAtual = movimentacaoLateral;
        
        configurarColisorCentroDaPinca(componentesDaGarraDto.Colisor);

    }    

    public void Update()
    {
        movimentacaoAtual.update();
    }

    public void FixedUpdate()
    {
        movimentacaoAtual.fixedUpdate();       
    }   

    private void garraColidiuCom(Collider2D other)
    {
        movimentacaoAtual.garraColidiuCom(other.gameObject);        
    }    

    private void configurarColisorCentroDaPinca(GameObject goColisor)
    {
        DetectorDeTriggers detectorDeColisoes = goColisor.GetComponent<DetectorDeTriggers>();        
        detectorDeColisoes.registrarConsumidorDeTrigger((colisao) =>garraColidiuCom(colisao));
    }

    public ProdutorDeEvento<GameObject> getProdutorDeEventoColisaoComColetavel()
    {
        return produtorDeEventoAtingiuColetavel;
    }

    //IMPLEMENTACAO INTERFACE COMMUNICATORCOMGARRA INICIO
    public void trocarParaAcaoDescendo(Vector2 posicaoInicial)
    {
        this.posicaoInicial = posicaoInicial;
        movimentacaoParaBaixo.preInicio();
        movimentacaoAtual   = movimentacaoParaBaixo;
    }

    public void trocarParaAcaoSubindo()
    {
        movimentacaoParaCima.setPosicalInicialDeReferencia(posicaoInicial);
        movimentacaoParaCima.preInicio();
        movimentacaoAtual = movimentacaoParaCima;
    }

    public void trocarParaAcaoNormal()
    {
        movimentacaoLateral.preInicio();
        movimentacaoAtual = movimentacaoLateral;
    }

    public void trocarParaAgarrada()
    {
        movimentacaoAgarrando.preInicio();
        movimentacaoAtual = movimentacaoAgarrando;
    }
    //IMPLEMENTACAO INTERFACE COMMUNICATORCOMGARRA FIM
}
