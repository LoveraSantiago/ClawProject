using UnityEngine;

public class ColetavelTile : GO
{
    private static CircleCollider2D referenciaColliderColetado;

    private bool miraSelecionada;
    private ColetavelAnimacao animacao;      

    public ColetavelTile()
        : base()
    {
        animacao = new ColetavelAnimacao(goColetavel);
    }

    public void ligarAnimacaoMira()
    {
        animacao.ligarMira();
        miraSelecionada = false;
    }

    public void ligarAnimacaoMiraSelecionado()
    {
        animacao.ligarMiraSelecionada();
        miraSelecionada = true;
    }

    public void desligarAnimacao()
    {
        animacao.desligar();
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
