using UnityEngine;

public class ColetavelTile : Coletavel
{
    private Animator animator;
    private bool miraSelecionada;

    public ColetavelTile()
        : base()
    {
        animator = goColetavel.transform.Find("animacao").GetComponent<Animator>();
    }

    public void ligarAnimacaoMira()
    {
        animator.Play(context.MIRAR_ON);
        miraSelecionada = false;
    }

    public void ligarAnimacaoMiraSelecionado()
    {
        animator.Play(context.MIRAR_SELECTED);
        miraSelecionada = true;
    }

    public void desligarAnimacao()
    {
        animator.Play(context.IDLE);
        miraSelecionada = false;
    }

    public bool isMiraSelecionada()
    {
        return miraSelecionada;
    }
}
