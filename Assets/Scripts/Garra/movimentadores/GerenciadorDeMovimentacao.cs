using UnityEngine;

public abstract class GerenciadorDeMovimentacao 
{
    public abstract void iniciarMovimentacoes();
    public abstract void update(InputGame inputGame);
    public abstract void fixedUpdate();

    public virtual void garraColidiuCom(Collider2D other){}

    public abstract void garraComemorar();
}
