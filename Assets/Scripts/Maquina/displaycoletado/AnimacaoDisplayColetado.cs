using UnityEngine;

public class AnimacaoDisplayColetado 
{
    private static readonly int IDLE           = Animator.StringToHash("idle");
    private static readonly int MIRAR_ON       = Animator.StringToHash("mira-on");
    private static readonly int MIRAR_SELECTED = Animator.StringToHash("mira-selected");

    private Animator animator;

    public AnimacaoDisplayColetado(Animator animator)
    {
        this.animator = animator;
    }

    public void ligarAnimacaoMira()
    {
        animator.Play(MIRAR_ON);     
    }

    public void ligarAnimacaoMiraSelecionado()
    {
        animator.Play(MIRAR_SELECTED);     
    }

    public void desligarAnimacao()
    {
        animator.Play(IDLE);     
    }
}
