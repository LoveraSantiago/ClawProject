using UnityEngine;

public abstract class GerenciadorDeMovimentacao : AcaoSincroniaComDirecaoDaGarra.ProdutorEvento
{
    public abstract int  getContagemDeSubidas();
    public abstract void iniciarMovimentacoes();
    public abstract void update(InputGame inputGame);
    public abstract void fixedUpdate();

    public virtual void garraColidiuCom(Collider2D other){}

    public abstract void garraComemorar();

    public abstract ProdutorDeEvento<Direcao> getProdutorDeEvento();
}
