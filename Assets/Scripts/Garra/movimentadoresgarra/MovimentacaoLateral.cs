using UnityEngine;

public class MovimentacaoLateral : MovimentacaoDaGarra
{
    private readonly float VELOCIDADE_ROTACAO = 100f;

    private float movimentoLateral;    
    private float velocidadeMovimento;

    private Rigidbody2D rigidBody2d;

    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;

    private Transform pincaDireita;
    private Transform pincaEsquerda;

    private float incremento;

    private CommunicatorComGarra communicatorComGarra;

    public MovimentacaoLateral(float velocidadeMovimento, 
        Rigidbody2D rigidBody2d, 
        CommunicatorComGarra communicatorComGarra,
        Transform pincaDireita,
        Transform pincaEsquerda)
    {
        this.velocidadeMovimento = velocidadeMovimento;
        this.rigidBody2d = rigidBody2d;
        this.communicatorComGarra = communicatorComGarra;

        this.pincaDireita = pincaDireita;
        this.pincaEsquerda = pincaEsquerda;

        anguloDesejadoDireita = Quaternion.Euler(0, 0, 0);
        anguloDesejadoEsquerda = Quaternion.Euler(0, 0, 0);
    }

    public void update()
    {
        incremento = Time.deltaTime * VELOCIDADE_ROTACAO;
        pincaEsquerda.rotation = Quaternion.RotateTowards(pincaEsquerda.rotation, anguloDesejadoEsquerda, incremento);
        pincaDireita.rotation = Quaternion.RotateTowards(pincaDireita.rotation, anguloDesejadoDireita, incremento);

        if (Input.GetButtonDown("Jump"))
        {
            Vector2 posicaoInicial = rigidBody2d.transform.localPosition;
            Debug.Log("Posicao inicial: " + posicaoInicial);
            communicatorComGarra.trocarParaAcaoDescendo(posicaoInicial);
        }
    }

    public void fixedUpdate()
    {
        movimentoLateral = Input.GetAxis("Horizontal");
        rigidBody2d.velocity = new Vector2(movimentoLateral * velocidadeMovimento, rigidBody2d.velocity.y);
    }
}
