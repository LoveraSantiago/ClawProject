using UnityEngine;

public class ColetavelAnimacao 
{
    private static readonly int IDLE           = Animator.StringToHash("idle");
    private static readonly int MIRAR_ON       = Animator.StringToHash("mirar-on");
    private static readonly int MIRAR_SELECTED = Animator.StringToHash("mirar-selected");

    private Animator animator;

    public ColetavelAnimacao(GameObject gameObject)
    {
        animator = gameObject.transform.Find("animacao").GetComponent<Animator>();
    }

    public void ligarMira()
    {
        animator.Play(MIRAR_ON);
    }

    public void ligarMiraSelecionada()
    {
        animator.Play(MIRAR_SELECTED);
    }

    public void desligar()
    {
        animator.Play(IDLE);
    }
}
