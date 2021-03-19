using UnityEngine;

public class MovimentacaoLateral : MovimentacaoDaGarra
{
    private readonly float VELOCIDADE_ROTACAO = 100f;

    private float movimentoLateral;        

    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;

    private Transform pincaDireita;
    private Transform pincaEsquerda;

    private float incremento;

    private CommunicatorComGarra communicatorComGarra;

    public MovimentacaoLateral(
        CommunicatorComGarra communicatorComGarra,
        Transform pincaDireita,
        Transform pincaEsquerda)
    {        
        this.communicatorComGarra = communicatorComGarra;

        this.pincaDireita = pincaDireita;
        this.pincaEsquerda = pincaEsquerda;

        anguloDesejadoDireita = Quaternion.Euler(0, 0, 0);
        anguloDesejadoEsquerda = Quaternion.Euler(0, 0, 0);
    }

    public override void update()
    {
        //incremento = Time.deltaTime * VELOCIDADE_ROTACAO;
        //pincaEsquerda.rotation = Quaternion.RotateTowards(pincaEsquerda.rotation, anguloDesejadoEsquerda, incremento);
        //pincaDireita.rotation = Quaternion.RotateTowards(pincaDireita.rotation, anguloDesejadoDireita, incremento);

        if (Input.GetButtonDown("Jump"))
        {
            Vector2 posicaoInicial = compDaGarra.RigidBody.transform.localPosition;
            Debug.Log("Posicao inicial: " + posicaoInicial);
            communicatorComGarra.trocarParaAcaoDescendo(posicaoInicial);
        }
    }

    public override void fixedUpdate()
    {
        movimentoLateral = Input.GetAxis("Horizontal");

        compDaGarra.RigidBody.velocity = new Vector2(
            movimentoLateral * compDaGarra.VelocidadeMovimento,
            compDaGarra.RigidBody.velocity.y);
    }
}
