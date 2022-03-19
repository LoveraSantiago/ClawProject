using UnityEngine;

public abstract class AbstractGarraAnimacao 
{
    public abstract void irParaDireita();
    public abstract void irParaEsquerda();
    public abstract void irParaBaixo();
    public abstract void irParaCima();

    public abstract void comemorar();
    public abstract void piscar();
    public abstract void girando();
    public abstract bool isComemorando();

    private int animacaoAtual;
    private Animator animator;

    public AbstractGarraAnimacao(Animator animator)
    {
        this.animator = animator;
    }

    public void irParaLadoAnterior(int lado)
    {
        if(lado == -1)
        {
            irParaEsquerda();
        }
        else
        {
            irParaDireita();
        }
    }

    protected void play(int estado)
    {
        animator.Play(estado);
        animacaoAtual = estado;
    }

    protected bool isEstado(int estado)
    {
        return animacaoAtual == estado;
    }    
}
