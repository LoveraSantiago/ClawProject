using UnityEngine;

public class MovimentacaoParaCima : MovimentacaoDaGarra
{
    private Vector2 posicaoInicial;

    private float gravidade;
    private float incremento;    

    private CommunicatorComGarra communicatorComGarra;

    public MovimentacaoParaCima(float gravidade, 
        CommunicatorComGarra communicatorComGarra)
    {
        this.gravidade = -gravidade;
        
        this.communicatorComGarra = communicatorComGarra;
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
    }

    public void setPosicalInicialDeReferencia(Vector2 posicaoInicial)
    {
        this.posicaoInicial = posicaoInicial;
    }
}
