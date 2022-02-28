using UnityEngine;

public class Coletavel : GO
{
    private static readonly int SPR_ORDER_COMUM    = 32;
    private static readonly int SPR_ORDER_DESTAQUE = 33;

    private static readonly int LAYER_ELEVADOR = 16;
    private static readonly int LAYER_NORMAL   = 7;

    private static CircleCollider2D referenciaColliderColetado;
    private static ColetavelContexto contexto;

    private bool miraSelecionada;
    private ColetavelAnimacao animacao;      

    public Coletavel()
        : base(contexto, contexto.nomeador.getName())
    {
        animacao = new ColetavelAnimacao(go);
    }

    public Coletavel(Transform transform)
        : base(transform)
    {
        animacao = new ColetavelAnimacao(go);
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
        addMaterial(contexto.mainMaterial);
    }

    public void colocarNoLayerElevador()
    {        
        setLayer(LAYER_ELEVADOR);
    }

    public void colocarNoLayerNormal()
    {
        setLayer(LAYER_NORMAL);        
    }

    public void colocarNoLayerDestaque()
    {
        colocarSpriteNoLayer(SPR_ORDER_DESTAQUE);
    }

    public void colocarNoLayerComum()
    {
        colocarSpriteNoLayer(SPR_ORDER_COMUM);
    }

    public void imantar()
    {        
        setLayer(LayerMask.NameToLayer("Atracao"));
    }

    public void desimantar()
    {
        setLayer(LayerMask.NameToLayer("Coletavel"));
    }

    public void naoInteracaoComOutrosColetaveis()
    {
        setLayer(LayerMask.NameToLayer("ColetavelNaoInteracao"));
    }

    public void interacaoComOutrosColetaveis()
    {
        desimantar();
    }

    public void receberSprite(Sprite sprite)
    {
        receberSprite(sprite, SPR_ORDER_COMUM);
    }

    public bool isTouchingCentroDaGarra()
    {
        LayerMask mask = LayerMask.GetMask("GarraCentro");
        Collider2D collider2d = Physics2D.OverlapCircle(rigidbody.position, 0.3f, mask);        
        return referenciaColliderColetado == collider2d && rigidbody.velocity.y > 0;
    }

    protected override GOContexto getGOContext()
    {
        return contexto;
    }

    public static void configurar(CircleCollider2D referenciaColliderColetadoArg, ColetaveisDto coletaveisDto)
    {
        contexto = new ColetavelContexto(coletaveisDto);        

        referenciaColliderColetado = referenciaColliderColetadoArg;
    }
}
