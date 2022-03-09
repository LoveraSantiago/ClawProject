using UnityEngine;

public class AnimacaoMola 
{
    private static readonly int IDLE = Animator.StringToHash("idle");
    private static readonly int JUMP = Animator.StringToHash("mola-jump");

    private Animator animator;

    public AnimacaoMola(Animator animator)
    {
        this.animator = animator;
    }

    public void parar()
    {
        animator.Play(IDLE);
    }

    public void pular()
    {
        animator.Play(JUMP);
    }
}
