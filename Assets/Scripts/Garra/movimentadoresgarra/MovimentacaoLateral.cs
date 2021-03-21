using UnityEngine;

public class MovimentacaoLateral : MovimentacaoDaGarra
{
    private float movimentoLateral;        

    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;    

    private float incremento;

    public MovimentacaoLateral()
    {        
        anguloDesejadoDireita = Quaternion.Euler(0, 0, 0);
        anguloDesejadoEsquerda = Quaternion.Euler(0, 0, 0);        
    }

    public override void preInicio()
    {
        desligarAtracaoNoObjeto();
    }

    public override void update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Vector2 posicaoInicial = compDaGarra.RigidBody.transform.localPosition;
            //Debug.Log("Posicao inicial: " + posicaoInicial);
            communicatorComGarra.trocarParaAcaoDescendo(posicaoInicial);
        }
    }
    //2.17
    int direcao = 1;
    public override void fixedUpdate()
    {
        //movimentoLateral = Input.GetAxis("Horizontal");
        if(compDaGarra.RigidBody.transform.localPosition.x > 2.16)
        {
            Debug.Log("1");
            direcao = -1;
            compDaGarra.RigidBody.velocity = Vector2.zero;
            compDaGarra.RigidBody.angularVelocity = 0;
        }
        else if(compDaGarra.RigidBody.transform.localPosition.x < -2.16)
        {
            Debug.Log("2");
            direcao = 1;
            compDaGarra.RigidBody.velocity = Vector2.zero;
            compDaGarra.RigidBody.angularVelocity = 0;
        }
        
        
        compDaGarra.RigidBody.velocity = new Vector2(
            direcao * compDaGarra.VelocMovHorizontal * Time.fixedDeltaTime,
            compDaGarra.RigidBody.velocity.y);
        
    }
}
