using UnityEngine;

public class AnimacaoTimerFicha
{
    private static int ANIMACAO_GANHAR_FICHA = Animator.StringToHash("ganhar-ficha");
    private static int ANIMACAO_GASTAR_FICHA = Animator.StringToHash("gastar-ficha");

    private Animator animator;

    public AnimacaoTimerFicha(Animator animator)
    {
        this.animator = animator;
    }

    public void playGanharFicha()
    {
        animator.Play(ANIMACAO_GANHAR_FICHA);
    }

    public void playGastarFicha()
    {
        animator.Play(ANIMACAO_GASTAR_FICHA);
    }
}
