using UnityEngine;

public class Coletavel : ComponenteAnimacaoDeColetavel
{    
    private static ColetavelContexto contexto;    
    public string nomeGaiolaAprisionadora { get; private set; }    

    public Coletavel()
        : base(contexto, new ProcuradorDeSpriteRenderer("imagem"), contexto.nomeador.getName()){}

    public Coletavel(Transform transform)
        : base(transform, new ProcuradorDeSpriteRenderer("imagem")) {}       

    public void clearMaterial()
    {
        addMaterial(contexto.mainMaterial);
    }

    public void colocarNoLayerElevador()
    {        
        setLayer(contexto.LAYER_ELEVADOR);
    }

    public void colocarNoLayerNormal()
    {
        setLayer(contexto.LAYER_NORMAL);        
    }

    public bool isLayerNormal()
    {
        return isLayer(contexto.LAYER_NORMAL);
    }

    public void colocarNoLayerDestaque()
    {
        colocarSpriteNoLayer(contexto.SPR_ORDER_DESTAQUE);
    }

    public void colocarNoLayerComum()
    {
        colocarSpriteNoLayer(contexto.SPR_ORDER_COMUM);
        desafixarVerticalmente();
    }

    public void imantar()
    {        
        setLayer(LayerMask.NameToLayer("Atracao"));
    }

    public void desimantar()
    {
        setLayer(LayerMask.NameToLayer(TagUtils.TAG_LAYER_COLETAVEL));
    }

    public void naoInteracaoComOutrosColetaveis()
    {
        setLayer(LayerMask.NameToLayer("ColetavelNaoInteracao"));
    }

    public void preso(string nomeGaiola)
    {
        setLayer(LayerMask.NameToLayer(TagUtils.LAYER_COLETAVELGAIOLA));
        nomeGaiolaAprisionadora = nomeGaiola;
        fixarEixoXY();
    }

    public bool isPreso()
    {
        return nomeGaiolaAprisionadora != null;
    }

    public void soltar()
    {
        nomeGaiolaAprisionadora = null;
        desimantar();
    }

    public bool isLivre()
    {
        return !isPreso();
    }

    public override void ligar()
    {
        base.ligar();
        ligarAnimacaoIdle();
    }

    public void interacaoComOutrosColetaveis()
    {
        desimantar();
    }

    public void receberSprite(Sprite sprite)
    {
        receberSprite(sprite, contexto.SPR_ORDER_COMUM);
    }

    public bool isTouchingCentroDaGarra()
    {
        LayerMask mask = LayerMask.GetMask("GarraCentro");
        Collider2D collider2d = Physics2D.OverlapCircle(getPosicao(), 0.3f, mask);
        return contexto.referenciaColliderColetado == collider2d && isVelocidadeYPositiva();
    }

    public GameObject getGOColetavel()
    {
        return getGo();
    }

    protected override GOContexto getGOContext()
    {
        return contexto;
    }   

    public static void configurar(CircleCollider2D referenciaColliderColetadoArg, ColetaveisDto coletaveisDto)
    {
        contexto = new ColetavelContexto(coletaveisDto, referenciaColliderColetadoArg);                
    }
}
