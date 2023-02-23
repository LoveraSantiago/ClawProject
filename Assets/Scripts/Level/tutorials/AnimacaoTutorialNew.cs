using UnityEngine;

public class AnimacaoTutorialNew : AnimacaoTutorial
{
    private static readonly int IDLE = Animator.StringToHash("idle");
    private static readonly int ANIM_PARTE_COLETAR = Animator.StringToHash("clique-coletar");
    private static readonly int ANIM_PARTE_POWERUP = Animator.StringToHash("clique-powerup");
    private static readonly int ANIM_PARTE_DRAGPUP = Animator.StringToHash("drag-powerup");
    private static readonly int ANIM_PARTE_TEXTO = Animator.StringToHash("so-texto");
    private static readonly int ANIM_PARTE_TEXTOBAIXO = Animator.StringToHash("so-texto-baixo");
    private static readonly int ANIM_PARTE_DRAGAREA = Animator.StringToHash("drag-area-powerup");
    private static readonly int ANIM_PARTE_ALVO = Animator.StringToHash("clique-alvo");
    private static readonly int ANIM_PARTE_ALVO_COLETADO = Animator.StringToHash("clique-alvo-coletado");

    //PRIVADO PARA NAO ESPALHAR DETALHES INTERNOS PARA FUNCIONAMENTO DA CLASSE
    private static readonly int TUTORIAL_IDLE = Animator.StringToHash("tutorial-idle");
    private static readonly int TUTORIAL_GARRA_COLETAR = Animator.StringToHash("garra-toque");
    private static readonly int TUTORIAL_POWER_UP = Animator.StringToHash("power-up-toque");
    private static readonly int TUTORIAL_POWER_UP_ARRASTA = Animator.StringToHash("power-up-arrasta");

    private Animator animator;

    public AnimacaoTutorialNew(TutorialDto tutorialDto)
    {
        this.animator = tutorialDto.AnimatorNew;
    }

    public void playIdle()
    {
        animator.Play(IDLE);
    }

    public void playColetar()
    {
        animator.Play(TUTORIAL_GARRA_COLETAR);
    }

    public void playPowerUp()
    {
        animator.Play(TUTORIAL_POWER_UP);
    }

    public void playDragPowerUp()
    {
        animator.Play(ANIM_PARTE_DRAGPUP);
    }

    public void playDragAreaPowerUp()
    {
        animator.Play(TUTORIAL_POWER_UP_ARRASTA);
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
