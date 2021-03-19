using UnityEngine;

public class MovimentacaoLateral : MovimentacaoDaGarra
{
    private float movimentoLateral;        

    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;    

    private float incremento;

    private CommunicatorComGarra communicatorComGarra;

    public MovimentacaoLateral(CommunicatorComGarra communicatorComGarra)
    {        
        this.communicatorComGarra = communicatorComGarra;

        anguloDesejadoDireita = Quaternion.Euler(0, 0, 0);
        anguloDesejadoEsquerda = Quaternion.Euler(0, 0, 0);
    }

    public override void update()
    {
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
