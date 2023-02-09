using UnityEngine;

public class AnimacaoTutorial 
{
    private static readonly int IDLE                     = Animator.StringToHash("idle");
    private static readonly int ANIM_PARTE_COLETAR       = Animator.StringToHash("clique-coletar");
    private static readonly int ANIM_PARTE_POWERUP       = Animator.StringToHash("clique-powerup");
    private static readonly int ANIM_PARTE_DRAGPUP       = Animator.StringToHash("drag-powerup");
    private static readonly int ANIM_PARTE_TEXTO         = Animator.StringToHash("so-texto");
    private static readonly int ANIM_PARTE_TEXTOBAIXO    = Animator.StringToHash("so-texto-baixo");
    private static readonly int ANIM_PARTE_DRAGAREA      = Animator.StringToHash("drag-area-powerup");
    private static readonly int ANIM_PARTE_ALVO          = Animator.StringToHash("clique-alvo");
    private static readonly int ANIM_PARTE_ALVO_COLETADO = Animator.StringToHash("clique-alvo-coletado");

    private Animator animator;

    public AnimacaoTutorial(Animator animator)
    {
        this.animator = animator;
    }

    public void playIdle()
    {
        animator.Play(IDLE);
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
    
    public void playParteTextoBaixo()
    {
        animator.Play(ANIM_PARTE_TEXTOBAIXO);
    }

    public void playAlvo()
    {
        animator.Play(ANIM_PARTE_ALVO);
    }
    
    public void playAlvoColetado()
    {
        animator.Play(ANIM_PARTE_ALVO_COLETADO);
    }
}
