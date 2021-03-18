using UnityEngine;

public class Garra : MonoBehaviour, 
                     CommunicatorComGarra
{
    [SerializeField] private float speed;
    [SerializeField] private float gravity;

    private Vector2 posicaoInicial;

    private GameObject[] coletados = new GameObject[3];
    private Vector2[] coletadosBackPosition = new Vector2[3];

    private MovimentacaoDaGarra movimentacaoAtual;    
    private MovimentacaoDaGarra movimentacaoParaBaixo;
    private MovimentacaoDaGarra movimentacaoAgarrando;
    private MovimentacaoParaCima movimentacaoParaCima;
    private MovimentacaoDaGarra movimentacaoLateral;

    private Transform pincaEsquerda;
    private Transform pincaDireita;

    void Start()
    {
        Rigidbody2D rigidBody2d = GetComponent<Rigidbody2D>();
        pincaDireita = transform.Find("centroPinca/pincaDireita");
        pincaEsquerda = transform.Find("centroPinca/pincaEsquerda");       

        movimentacaoLateral   = new MovimentacaoLateral(speed, rigidBody2d, this, pincaDireita, pincaEsquerda);
        movimentacaoParaCima  = new MovimentacaoParaCima(gravity, rigidBody2d, this, pincaDireita, pincaEsquerda);
        movimentacaoParaBaixo = new MovimentacaoParaBaixo(gravity, rigidBody2d, pincaDireita, pincaEsquerda);
        movimentacaoAgarrando = new MovimentacaoAgarrando(rigidBody2d, pincaDireita, pincaEsquerda, this);
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
