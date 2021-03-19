using UnityEngine;

public class Garra : MonoBehaviour, 
                     CommunicatorComGarra
{
    [SerializeField] ComponentesDaGarraDto componentesDaGarra;    
    [SerializeField] private float gravity;

    private Vector2 posicaoInicial;

    private GameObject[] coletados = new GameObject[3];
    private Vector2[] coletadosBackPosition = new Vector2[3];

    private MovimentacaoDaGarra movimentacaoAtual;    
    private MovimentacaoDaGarra movimentacaoParaBaixo;
    private MovimentacaoDaGarra movimentacaoAgarrando;
    private MovimentacaoParaCima movimentacaoParaCima;
    private MovimentacaoDaGarra movimentacaoLateral;    

    void Start()
    {
        Rigidbody2D rigidBody2d = GetComponent<Rigidbody2D>();        

        MovimentacaoDaGarra.configurarComponentesDaGarraDto(componentesDaGarra);
        MovimentacaoAgarrando.configurarCommunicatorComGarra(this);

        movimentacaoLateral   = new MovimentacaoLateral();
        movimentacaoParaCima  = new MovimentacaoParaCima(gravity);
        movimentacaoParaBaixo = new MovimentacaoParaBaixo(gravity);
        movimentacaoAgarrando = new MovimentacaoAgarrando();
        movimentacaoAtual = movimentacaoLateral;
    }

    void Update()
    {
        movimentacaoAtual.update();
    }

    private void FixedUpdate()
    {
        movimentacaoAtual.fixedUpdate();       
    }   

    private void OnCollisionEnter2D(Collision2D other)
    {
        trocarParaAgarrada();
        other.transform.GetComponent<Rigidbody2D>().mass = 0;
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
