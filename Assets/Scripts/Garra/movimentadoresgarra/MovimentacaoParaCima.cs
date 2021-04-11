using UnityEngine;

public class MovimentacaoParaCima : MovimentacaoDaGarra
{
    private Vector2 posicaoInicial;    

    public MovimentacaoParaCima()
    {        
    }

    public override void preInicio()
    {
        compDaGarra.RigidBody.mass = 3;
        parandoMovimentacaoDaGarra();
    }

    public override void update()
    {        
        if(compDaGarra.RigidBody.transform.localPosition.y > posicaoInicial.y)
        {
            parandoMovimentacaoDaGarra();
            comunicadorComGerMovimentacao.trocarParaAcaoNormal();
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
        diminuirInerciaDaGarra();
    }
}
