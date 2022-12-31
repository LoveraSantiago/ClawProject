using UnityEngine;

public class AnimacaoTutorial 
{
    private static readonly int ANIM_PARTE_COLETAR  = Animator.StringToHash("clique-coletar");
    private static readonly int ANIM_PARTE_POWERUP  = Animator.StringToHash("clique-powerup");
    private static readonly int ANIM_PARTE_DRAGPUP  = Animator.StringToHash("drag-powerup");
    private static readonly int ANIM_PARTE_TEXTO    = Animator.StringToHash("so-texto");
    private static readonly int ANIM_PARTE_DRAGAREA = Animator.StringToHash("drag-area-powerup");

    private Animator animator;

    public AnimacaoTutorial(Animator animator)
    {
        this.animator = animator;
    }

    public void playColetar()
    {
        animator.Play(ANIM_PARTE_COLETAR);
    }

    public void playPowerUp()
    {
        animator.Play(ANIM_PARTE_POWERUP);
    }

    public void playDragPowerUp()
    {
        animator.Play(ANIM_PARTE_DRAGPUP);
    }

    public void playDragAreaPowerUp()
    {
        animator.Play(ANIM_PARTE_DRAGAREA);
    }

    public void playParteTexto()
    {
        animator.Play(ANIM_PARTE_TEXTO);
    }
}
