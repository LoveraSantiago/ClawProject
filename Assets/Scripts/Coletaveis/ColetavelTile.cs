using UnityEngine;

public class ColetavelTile : Coletavel
{
    private Animator animator;

    public ColetavelTile()
        : base()
    {
        animator = goColetavel.transform.Find("animacao").GetComponent<Animator>();
    }

    public void ligarAnimacaoMira()
    {
        animator.Play(context.MIRAR_ON);
    }

    public void ligarAnimacaoMiraSelecionado()
    {
        animator.Play(context.MIRAR_SELECTED);
    }

    public void desligarAnimacao()
    {
        animator.Play(context.IDLE);
    }
}
