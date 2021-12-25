using UnityEngine;

public class ColetavelTile : GO
{
    private static CircleCollider2D referenciaColliderColetado;

    private bool miraSelecionada;

    private Animator animator;        

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

    public void addMaterial(Material material)
    {
        spriteRenderer.material = material;
    }   

    public void clearMaterial()
    {
        addMaterial(context.mainMaterial);
    }

    public void colocarNoLayerElevador()
    {
        goColetavel.layer = 16;
    }

    public void colocarNoLayerNormal()
    {
        goColetavel.layer = 7;
    }

    public bool isTouchingCentroDaGarra()
    {
        LayerMask mask = LayerMask.GetMask("GarraCentro");
        Collider2D collider2d = Physics2D.OverlapCircle(rigidbody.position, 0.3f, mask);        
        return referenciaColliderColetado == collider2d && rigidbody.velocity.y > 0;
    }

    public static void configurar(CircleCollider2D referenciaColliderColetadoArg)
    {
        referenciaColliderColetado = referenciaColliderColetadoArg;
    }
}
