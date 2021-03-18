using UnityEngine;

public class MovimentacaoParaCima : MovimentacaoDaGarra
{
    private readonly float ANGULO_ROTACAO_ABERTO = 18f;
    private readonly float VELOCIDADE_ROTACAO = 50f;

    private Vector2 posicaoInicial;

    private float gravidade;
    private Rigidbody2D rigidbody2D;

    private float incremento;

    private Transform pincaDireita;
    private Transform pincaEsquerda;

    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;

    private CommunicatorComGarra communicatorComGarra;

    public MovimentacaoParaCima(float gravidade, 
        Rigidbody2D rigidbody2D, CommunicatorComGarra communicatorComGarra,
        Transform pincaDireita, Transform pincaEsquerda )
    {
        this.gravidade = -gravidade;
        this.rigidbody2D = rigidbody2D;
        this.communicatorComGarra = communicatorComGarra;

        anguloDesejadoDireita = Quaternion.Euler(0, 0,   ANGULO_ROTACAO_ABERTO);
        anguloDesejadoEsquerda = Quaternion.Euler(0, 0, -ANGULO_ROTACAO_ABERTO);

        this.pincaDireita = pincaDireita;
        this.pincaEsquerda = pincaEsquerda;
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

        //incremento = Time.deltaTime * VELOCIDADE_ROTACAO;
        //pincaEsquerda.rotation = Quaternion.RotateTowards(pincaEsquerda.rotation, anguloDesejadoEsquerda, incremento);
        //pincaDireita.rotation = Quaternion.RotateTowards(pincaDireita.rotation, anguloDesejadoDireita, incremento);
    }

    public void setPosicalInicialDeReferencia(Vector2 posicaoInicial)
    {
        this.posicaoInicial = posicaoInicial;
    }
}
