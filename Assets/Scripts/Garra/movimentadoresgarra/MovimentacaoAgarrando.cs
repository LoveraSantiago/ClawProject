using UnityEngine;

public class MovimentacaoAgarrando : MovimentacaoDaGarra
{
    private readonly float ANGULO_ROTACAO_ABERTO = 18f;
    private readonly float VELOCIDADE_ROTACAO = 50f;

    private float incremento;    

    private Transform pincaDireita;
    private Transform pincaEsquerda;

    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;

    private CommunicatorComGarra communicatorComGarra;

    public MovimentacaoAgarrando(
        Transform pincaDireita, Transform pincaEsquerda,
        CommunicatorComGarra communicatorComGarra)
    {
        this.pincaDireita = pincaDireita;
        this.pincaEsquerda = pincaEsquerda;

        anguloDesejadoDireita = Quaternion.Euler(0, 0,   ANGULO_ROTACAO_ABERTO);
        anguloDesejadoEsquerda = Quaternion.Euler(0, 0, -ANGULO_ROTACAO_ABERTO);

        this.communicatorComGarra = communicatorComGarra;
    }

    public override void update()
    {
        //rigidBody2d.gravityScale = 0;
        if (Input.GetButtonDown("Jump"))
        {
            Vector2 posicaoInicial = compDaGarra.RigidBody.transform.localPosition;
            Debug.Log("Posicao inicial: " + posicaoInicial);
            communicatorComGarra.trocarParaAcaoSubindo();
        }


    }

    public override void fixedUpdate()
    {
        incremento = Time.deltaTime * VELOCIDADE_ROTACAO;
        pincaEsquerda.rotation = Quaternion.RotateTowards(pincaEsquerda.rotation, anguloDesejadoEsquerda, incremento);
        pincaDireita.rotation = Quaternion.RotateTowards(pincaDireita.rotation, anguloDesejadoDireita, incremento);
    }
}
