using UnityEngine;

public class MovimentacaoParaCima : MovimentacaoDaGarra
{
    private Vector2 posicaoInicial;    

    public MovimentacaoParaCima()
    {        
    }

    public override void preInicio()
    {
        parandoMovimentacaoDaGarra();
    }

    public override void update()
    {        
        if(compDaGarra.RigidBody.transform.localPosition.y > posicaoInicial.y)
        {

            parandoMovimentacaoDaGarra();
            compDaGarra.RigidBody.transform.localPosition = new Vector2(
                compDaGarra.RigidBody.position.x, posicaoInicial.y);
            
            communicatorComGarra.trocarParaAcaoNormal();
        }
    }

    public override void fixedUpdate()
    {
        compDaGarra.RigidBody.velocity = new Vector2(0,
           1 * compDaGarra.VelocMovCima * Time.fixedDeltaTime);
    }

    public void setPosicalInicialDeReferencia(Vector2 posicaoInicial)
    {
        this.posicaoInicial = posicaoInicial;
    }

    private void parandoMovimentacaoDaGarra()
    {
        compDaGarra.RigidBody.velocity = Vector3.zero;
        compDaGarra.RigidBody.angularVelocity = 0;
    }
}
