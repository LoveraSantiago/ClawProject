using UnityEngine;

public class AnimacaoCardsPup : AcaoCardPupDetalheMovimentado.ConsumidorEvento,
                                AcaoBotaoPowerUpEscolhido.ConsumidorEvento
{
    private static readonly int FLIP_DOWN = Animator.StringToHash("flip-down");
    private static readonly int FLIP_UP_STOP = Animator.StringToHash("flip-up-stop");
    private static readonly int FLIP_UP = Animator.StringToHash("flip-up");
    private static readonly int DISMISS_BTN_1 = Animator.StringToHash("dismiss-btn1");
    private static readonly int DISMISS_BTN_2 = Animator.StringToHash("dismiss-btn2");
    private static readonly int DISMISS_BTN_3 = Animator.StringToHash("dismiss-btn3");

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

    public void playFlipUp()
    {
        animator.Play(FLIP_UP);
    }    

    void AcaoCardPupDetalheMovimentado.ConsumidorEvento.consumirEvento(bool evento)
    {
        if (evento)
        {
            playFlipDown();
        }
    }

    void AcaoBotaoPowerUpEscolhido.ConsumidorEvento.consumirEvento(int evento)
    {
        switch (evento)
        {
            case 0: animator.Play(DISMISS_BTN_1); break;
            case 1: animator.Play(DISMISS_BTN_2); break;
            case 2: animator.Play(DISMISS_BTN_3); break;
        }
    }
}
