using UnityEngine;

public class MovimentacaoAgarrando : MovimentacaoDaGarra
{
    private readonly float ANGULO_ROTACAO_ABERTO = 18f;
    private readonly float VELOCIDADE_ROTACAO = 50f;

    private float incremento;
    private Rigidbody2D rigidBody2d;

    private Transform pincaDireita;
    private Transform pincaEsquerda;

    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;

    public MovimentacaoAgarrando(Rigidbody2D rigidBody2d, Transform pincaDireita, Transform pincaEsquerda)
    {
        this.rigidBody2d = rigidBody2d;
        this.pincaDireita = pincaDireita;
        this.pincaEsquerda = pincaEsquerda;

        anguloDesejadoDireita = Quaternion.Euler(0, 0, -ANGULO_ROTACAO_ABERTO);
        anguloDesejadoEsquerda = Quaternion.Euler(0, 0, ANGULO_ROTACAO_ABERTO);
    }

    public void update()
    {
        //rigidBody2d.gravityScale = 0;

        incremento = Time.deltaTime * VELOCIDADE_ROTACAO;
        pincaEsquerda.rotation = Quaternion.RotateTowards(pincaEsquerda.rotation, anguloDesejadoEsquerda, incremento);
        pincaDireita.rotation = Quaternion.RotateTowards(pincaDireita.rotation, anguloDesejadoDireita, incremento);


    }

    public void fixedUpdate()
    {
    }
}
