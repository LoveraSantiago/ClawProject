using UnityEngine;

public abstract class AbstractGarraAnimacao 
{
    public abstract void irParaDireita(Animator animator);
    public abstract void irParaEsquerda(Animator animator);
    public abstract void irParaBaixo(Animator animator);
    public abstract void irParaCima(Animator animator);

    public abstract void comemorar(Animator animator);
    public abstract void piscar(Animator animator);
    public abstract void girando(Animator animator);
    public abstract bool isComemorando(Animator animator);

    private int animacaoAtual;    

    public void irParaLadoAnterior(int lado, Animator animator)
    {
        if(lado == -1)
        {
            irParaEsquerda(animator);
        }
        else
        {
            irParaDireita(animator);
        }
    }

    protected void play(int estado, Animator animator)
    {
        animator.Play(estado);
        animacaoAtual = estado;
    }

    protected bool isEstado(int estado)
    {
        return animacaoAtual == estado;
    }    
}
