using UnityEngine;

public class ColetavelAnimacao 
{
    private static readonly int IDLE           = Animator.StringToHash("idle");
    private static readonly int MIRAR_ON       = Animator.StringToHash("mirar-on");
    private static readonly int MIRAR_ON_OVO   = Animator.StringToHash("mirar-on-ovo");
    private static readonly int MIRAR_SELECTED = Animator.StringToHash("mirar-selected");
    private static readonly int OVO_FECHAR     = Animator.StringToHash("ovo-fechar");
    private static readonly int OVO_ABRIR      = Animator.StringToHash("ovo-abrir");

    private Animator animator;

    public ColetavelAnimacao(Animator animator)
    {
        this.animator = animator;
    }

    public void ligarMira()
    {
        animator.Play(MIRAR_ON);
    }

    public void ligarMiraOnOvo()
    {
        animator.Play(MIRAR_ON_OVO);
    }

    public void ligarMiraSelecionada()
    {
        animator.Play(MIRAR_SELECTED);
    }

    public void fecharOvo()
    {
        animator.Play(OVO_FECHAR);
    }

    public void abrirOvo()
    {
        animator.Play(OVO_ABRIR);
    }

    public void desligar()
    {
        animator.Play(IDLE);
    }
}
