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

    private Animator animator;

    public AnimacaoGarra(Animator animator)
    {
        this.animator = animator;
    }

    public void irParaDireita()
    {
        animator.Play(ANIM_DIREITA);
    }

    public void irParaEsquerda()
    {
        animator.Play(ANIM_ESQUERDA);
    }
}
