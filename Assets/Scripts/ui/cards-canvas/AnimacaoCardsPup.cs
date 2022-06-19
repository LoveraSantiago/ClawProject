using UnityEngine;

public class AnimacaoCardsPup : AcaoCardPupDetalheMovimentado.ConsumidorEvento
{
    private static readonly int FLIP_DOWN = Animator.StringToHash("flip-down");
    private static readonly int FLIP_UP_STOP = Animator.StringToHash("flip-up-stop");

    private Animator animator;

    public AnimacaoCardsPup(Animator animator)
    {
        this.animator = animator;
    }

    public void playFlipDown()
    {
        animator.Play(FLIP_DOWN);
    }

    public void playFlipUpStop()
    {
        animator.Play(FLIP_UP_STOP);
    }

    public void consumirEvento(bool evento)
    {
        playFlipDown();
    }
}
