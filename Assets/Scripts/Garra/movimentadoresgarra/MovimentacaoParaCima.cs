using UnityEngine;

public class MovimentacaoParaCima : MovimentacaoDaGarra
{
    private Vector2 posicaoInicial;    

    public MovimentacaoParaCima()
    {        
    }

    public override void preInicio()
    {
        negativandoGravidadeDaGarra();
        dobrandoMassaDaGarra();
    }

    public override void update()
    {        
        if(compDaGarra.RigidBody.transform.localPosition.y > posicaoInicial.y)
        {
            compDaGarra.RigidBody.transform.localPosition = new Vector2(
                compDaGarra.RigidBody.position.x, posicaoInicial.y);

            parandoMovimentacaoDaGarra();
            zerandoGravidadeDaGarra();
            normalizandoMassaDaGarra();
            communicatorComGarra.trocarParaAcaoNormal();
        }
    }

    public override void fixedUpdate()
    {        
    }

    public void setPosicalInicialDeReferencia(Vector2 posicaoInicial)
    {
        this.posicaoInicial = posicaoInicial;
    }

    private void dobrandoMassaDaGarra()
    {
        compDaGarra.RigidBody.mass = compDaGarra.RigidBody.mass * 2;
    }

    private void normalizandoMassaDaGarra()
    {
        compDaGarra.RigidBody.mass = compDaGarra.RigidBody.mass / 2;
    }

    private void negativandoGravidadeDaGarra()
    {
        compDaGarra.RigidBody.gravityScale = compDaGarra.GravidadeNeg;
    }

    private void zerandoGravidadeDaGarra()
    {
        compDaGarra.RigidBody.gravityScale = 0;
    }

    private void parandoMovimentacaoDaGarra()
    {
        compDaGarra.RigidBody.velocity = Vector3.zero;
    }
}
