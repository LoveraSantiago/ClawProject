using UnityEngine;

public class ColetavelTile : Coletavel
{
    private Animator animator;
    private bool miraSelecionada;
    private Material materialDefault;

    public ColetavelTile()
        : base()
    {
        animator = goColetavel.transform.Find("animacao").GetComponent<Animator>();
        materialDefault = spriteRenderer.material;
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

    public void addMaterial(Material material)
    {
        spriteRenderer.material = material;
    }

    public void clearMaterial()
    {
        addMaterial(materialDefault);
    }

    public void colocarNoLayerElevador()
    {
        goColetavel.layer = 16;
    }

    public void colocarNoLayerNormal()
    {
        goColetavel.layer = 7;
    }
}
