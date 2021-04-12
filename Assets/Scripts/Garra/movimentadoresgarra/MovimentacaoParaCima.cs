using UnityEngine;

public class MovimentacaoParaCima : MovimentacaoDaGarra
{
    private int contadorDeSubidas;
    private Vector2 posicaoInicial;
    private ProdutorDeEvento<int> produtorDeEventoSubidaDaGarra;

    public MovimentacaoParaCima()
    {
        contadorDeSubidas = 0;
        produtorDeEventoSubidaDaGarra = new ProdutorDeEvento<int>();
    }

    public override void preInicio()
    {
        compDaGarra.RigidBody.mass = 3;
        parandoMovimentacaoDaGarra();

        contadorDeSubidas++;
        produtorDeEventoSubidaDaGarra.produziuEvento(contadorDeSubidas);
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

    public ProdutorDeEvento<int> getProdutorDeEventoSubidaDaGarra()
    {
        return produtorDeEventoSubidaDaGarra;
    }
}
