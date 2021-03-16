using UnityEngine;

public class MovimentacaoParaBaixo : MovimentacaoDaGarra
{
    private float gravidade;
    private Rigidbody2D rigidbody2D;

    public MovimentacaoParaBaixo(float gravidade, Rigidbody2D rigidbody2D)
    {
        this.gravidade = gravidade;
        this.rigidbody2D = rigidbody2D;
    }

    public void update()
    {        
    }

    public void fixedUpdate()
    {
        rigidbody2D.gravityScale = gravidade;        
    }
}
