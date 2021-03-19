using UnityEngine;

public class MovimentacaoParaCima : MovimentacaoDaGarra
{
    private readonly float ANGULO_ROTACAO_ABERTO = 18f;
    private readonly float VELOCIDADE_ROTACAO = 50f;

    private Vector2 posicaoInicial;

    private float gravidade;    

    private float incremento;

    private Transform pincaDireita;
    private Transform pincaEsquerda;

    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;

    private CommunicatorComGarra communicatorComGarra;

    public MovimentacaoParaCima(float gravidade, 
        CommunicatorComGarra communicatorComGarra,
        Transform pincaDireita, Transform pincaEsquerda )
    {
        this.gravidade = -gravidade;
        
        this.communicatorComGarra = communicatorComGarra;

        anguloDesejadoDireita = Quaternion.Euler(0, 0,   ANGULO_ROTACAO_ABERTO);
        anguloDesejadoEsquerda = Quaternion.Euler(0, 0, -ANGULO_ROTACAO_ABERTO);

        this.pincaDireita = pincaDireita;
        this.pincaEsquerda = pincaEsquerda;
    }

    public override void update()
    {        
        if(compDaGarra.RigidBody.transform.localPosition.y > posicaoInicial.y)
        {
            compDaGarra.RigidBody.transform.localPosition = new Vector2(compDaGarra.RigidBody.position.x, posicaoInicial.y);

            compDaGarra.RigidBody.gravityScale = 0;
            compDaGarra.RigidBody.velocity = Vector3.zero;
            communicatorComGarra.trocarParaAcaoNormal();
        }
    }

    public override void fixedUpdate()
    {
        compDaGarra.RigidBody.gravityScale = gravidade;

        //incremento = Time.deltaTime * VELOCIDADE_ROTACAO;
        //pincaEsquerda.rotation = Quaternion.RotateTowards(pincaEsquerda.rotation, anguloDesejadoEsquerda, incremento);
        //pincaDireita.rotation = Quaternion.RotateTowards(pincaDireita.rotation, anguloDesejadoDireita, incremento);
    }

    public void setPosicalInicialDeReferencia(Vector2 posicaoInicial)
    {
        this.posicaoInicial = posicaoInicial;
    }
}
