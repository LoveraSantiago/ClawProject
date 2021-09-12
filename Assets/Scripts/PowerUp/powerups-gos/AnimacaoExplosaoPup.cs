using UnityEngine;

public class AnimacaoExplosaoPup 
{
    private static int IDLE = Animator.StringToHash("idle");
    private static int PRE_EXPLOSAO = Animator.StringToHash("pre-explosao");

    private Animator animator;

    public AnimacaoExplosaoPup(Animator animator)
    {
        this.animator = animator;
    }

    public void playIdle()
    {
        animator.Play(IDLE);
    }

    public void playPreExplodir()
    {
        animator.Play(PRE_EXPLOSAO);
    }
}
