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

        movimentacaoLateral   = new MovimentacaoLateral();
        movimentacaoParaCima  = new MovimentacaoParaCima();
        movimentacaoParaBaixo = new MovimentacaoParaBaixo();
        movimentacaoAgarrando = new MovimentacaoAgarrando();
        movimentacaoAtual = movimentacaoLateral;
        
        configurarDetector(componentesDaGarraDto.RigidBody.gameObject);

        produtorDeEventoAtingiuColetavel = new ProdutorDeEvento<GameObject>();
    }    

    public void Update()
    {
        movimentacaoAtual.update();
    }

    public void FixedUpdate()
    {
        movimentacaoAtual.fixedUpdate();       
    }   

    private void garraColidiuCom(Collision2D other)
    {
        if (Utils.isColetavel(other))
        {
            trocarParaAgarrada();
            produtorDeEventoAtingiuColetavel.produziuEvento(other.gameObject);        
        }
    }    

    private void configurarDetector(GameObject goGarra)
    {
        DetectorDeColisoes detectorDeColisoes =  goGarra.GetComponent<DetectorDeColisoes>();
        detectorDeColisoes.registrarConsumidorCollision2dOnEnter(
            (colisao) => garraColidiuCom(colisao));
    }

    public ProdutorDeEvento<GameObject> getProdutorDeEventoColisaoComColetavel()
    {
        return produtorDeEventoAtingiuColetavel;
    }

    //IMPLEMENTACAO INTERFACE COMMUNICATORCOMGARRA INICIO
    public void trocarParaAcaoDescendo(Vector2 posicaoInicial)
    {
        this.posicaoInicial = posicaoInicial;
        movimentacaoAtual   = movimentacaoParaBaixo;
    }

    public void trocarParaAcaoSubindo()
    {
        movimentacaoParaCima.setPosicalInicialDeReferencia(posicaoInicial);
        movimentacaoAtual = movimentacaoParaCima;
    }

    public void trocarParaAcaoNormal()
    {
        movimentacaoAtual = movimentacaoLateral;
    }

    public void trocarParaAgarrada()
    {
        movimentacaoAtual = movimentacaoAgarrando;
    }
    //IMPLEMENTACAO INTERFACE COMMUNICATORCOMGARRA FIM
}
