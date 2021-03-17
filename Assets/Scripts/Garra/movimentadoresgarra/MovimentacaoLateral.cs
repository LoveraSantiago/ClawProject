using UnityEngine;

public class MovimentacaoLateral : MovimentacaoDaGarra
{
    private float movimentoLateral;    
    private float velocidadeMovimento;

    private Rigidbody2D rigidBody2d;

    private CommunicatorComGarra communicatorComGarra;

    public MovimentacaoLateral(float velocidadeMovimento, Rigidbody2D rigidBody2d, CommunicatorComGarra communicatorComGarra)
    {
        this.velocidadeMovimento = velocidadeMovimento;
        this.rigidBody2d = rigidBody2d;
        this.communicatorComGarra = communicatorComGarra;
    }

    public void update()
    {
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
