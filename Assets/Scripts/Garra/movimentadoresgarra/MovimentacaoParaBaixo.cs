using UnityEngine;

public class MovimentacaoParaBaixo : MovimentacaoDaGarra
{
    private readonly float ANGULO_ROTACAO_ABERTO = 50f;
    private readonly float VELOCIDADE_ROTACAO = 75f;

    private float gravidade;
    private float incremento;

    private Rigidbody2D rigidbody2D;

    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;

    private Transform pincaDireita;
    private Transform pincaEsquerda;

    public MovimentacaoParaBaixo(float gravidade, Rigidbody2D rigidbody2D,
        Transform pincaDireita, 
        Transform pincaEsquerda)
    {
        this.gravidade = gravidade;
        this.rigidbody2D = rigidbody2D;

        anguloDesejadoDireita  = Quaternion.Euler(0, 0, -ANGULO_ROTACAO_ABERTO);
        anguloDesejadoEsquerda = Quaternion.Euler(0, 0,  ANGULO_ROTACAO_ABERTO);

        this.pincaDireita  = pincaDireita;
        this.pincaEsquerda = pincaEsquerda;
    }

    public void update()
    {
        incremento = Time.deltaTime * VELOCIDADE_ROTACAO;
        pincaEsquerda.rotation = Quaternion.RotateTowards(pincaEsquerda.rotation, anguloDesejadoEsquerda, incremento);
        pincaDireita.rotation =  Quaternion.RotateTowards(pincaDireita.rotation,  anguloDesejadoDireita , incremento);
    }

    public void fixedUpdate()
    {
        rigidbody2D.gravityScale = gravidade;        
    }
}
