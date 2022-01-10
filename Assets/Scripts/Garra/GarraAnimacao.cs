using UnityEngine;

public class GarraAnimacao 
{
    private readonly int ANIM_IDLE     = Animator.StringToHash("idle");
    private readonly int ANIM_CIMA     = Animator.StringToHash("indocima");
    private readonly int ANIM_BAIXO    = Animator.StringToHash("indobaixo");
    private readonly int ANIM_DIREITA  = Animator.StringToHash("indodireita");
    private readonly int ANIM_ESQUERDA = Animator.StringToHash("indoesquerda");
    private readonly int ANIM_PISCANDO = Animator.StringToHash("piscando");
    private readonly int ANIM_FELIZ    = Animator.StringToHash("feliz");
    private readonly int ANIM_RODANDO  = Animator.StringToHash("girandov2");

    private int animacaoAtual;
    private Animator animator;   

    public GarraAnimacao(Animator animator)
    {
        this.animator = animator;
    }

    public void irParaDireita()
    {
        play(ANIM_DIREITA);
    }

    public void irParaEsquerda()
    {
        play(ANIM_ESQUERDA);
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
        play(ANIM_BAIXO);
    }

    public void irParaCima()
    {
        play(ANIM_CIMA);
    }

    public void comemorar()
    {
        play(ANIM_FELIZ);
    }

    public void piscar()
    {
        play(ANIM_PISCANDO);
    }

    public void girando()
    {   
        play(ANIM_RODANDO);
    }

    private void play(int estado)
    {
        animator.Play(estado);
        animacaoAtual = estado;
    }

    public bool isComemorando()
    {
        return animacaoAtual == ANIM_FELIZ;
    }
}
