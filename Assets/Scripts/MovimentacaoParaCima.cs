using UnityEngine;

public class MovimentacaoParaCima : MovimentacaoDaGarra
{
    private Vector2 posicaoInicial;

    private float gravidade;
    private Rigidbody2D rigidbody2D;

    private CommunicatorComGarra communicatorComGarra;

    public MovimentacaoParaCima(float gravidade, Rigidbody2D rigidbody2D, CommunicatorComGarra communicatorComGarra)
    {
        this.gravidade = -gravidade;
        this.rigidbody2D = rigidbody2D;
        this.communicatorComGarra = communicatorComGarra;
    }

    public void update()
    {        
        if(rigidbody2D.transform.localPosition.y > posicaoInicial.y)
        {
            rigidbody2D.transform.localPosition = new Vector2(rigidbody2D.position.x, posicaoInicial.y);

            rigidbody2D.gravityScale = 0;
            rigidbody2D.velocity = Vector3.zero;
            communicatorComGarra.trocarParaAcaoNormal();
        }
    }

    public void fixedUpdate()
    {
        rigidbody2D.gravityScale = gravidade;
    }

    public void setPosicalInicialDeReferencia(Vector2 posicaoInicial)
    {
        this.posicaoInicial = posicaoInicial;
    }
}
