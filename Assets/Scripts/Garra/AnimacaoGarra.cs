using System;
using UnityEngine;

public class AnimacaoGarra 
{
    private readonly int ANIM_IDLE     = Animator.StringToHash("idle");
    private readonly int ANIM_CIMA     = Animator.StringToHash("indocima");
    private readonly int ANIM_BAIXO    = Animator.StringToHash("indobaixo");
    private readonly int ANIM_DIREITA  = Animator.StringToHash("indodireita");
    private readonly int ANIM_ESQUERDA = Animator.StringToHash("indoesquerda");
    private readonly int ANIM_PISCANDO = Animator.StringToHash("piscando");
    private readonly int ANIM_FELIZ    = Animator.StringToHash("feliz");

    private int animacaoAtual;

    private Animator animator;   

    public AnimacaoGarra(Animator animator)
    {
        this.animator = animator;
    }

    public void irParaDireita()
    {
        animator.Play(ANIM_DIREITA);
        animacaoAtual = ANIM_DIREITA;
    }

    public void irParaEsquerda()
    {
        animator.Play(ANIM_ESQUERDA);
        animacaoAtual = ANIM_ESQUERDA;
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

    public void irParaBaixo()
    {
        animator.Play(ANIM_BAIXO);
        animacaoAtual = ANIM_BAIXO;
    }

    public void irParaCima()
    {
        animator.Play(ANIM_CIMA);
        animacaoAtual = ANIM_CIMA;
    }

    public void comemorar()
    {
        animator.Play(ANIM_FELIZ);
        animacaoAtual = ANIM_FELIZ;
    }

    public void piscar()
    {
        animator.Play(ANIM_PISCANDO);
        animacaoAtual = ANIM_PISCANDO;
    }

    public bool isComemorando()
    {
        return animacaoAtual == ANIM_FELIZ;
    }
}
