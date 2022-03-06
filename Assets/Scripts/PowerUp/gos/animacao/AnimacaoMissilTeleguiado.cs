using UnityEngine;

public class AnimacaoMissilTeleguiado 
{
    private static readonly int MISSIL_IDLE = Animator.StringToHash("idle");
    private static readonly int MISSIL_ACIONADO = Animator.StringToHash("missil-acionado");
    private static readonly int MISSIL_EXPLODIDO = Animator.StringToHash("missil-explodido");

    private Animator animator;

    public AnimacaoMissilTeleguiado(Animator animator)
    {
        this.animator = animator;
    }

    public void parado()
    {
        animator.Play(MISSIL_IDLE);
    }

    public void acionado()
    {
        animator.Play(MISSIL_ACIONADO);
    }

    public void explodir()
    {
        animator.Play(MISSIL_EXPLODIDO);
    }
}
