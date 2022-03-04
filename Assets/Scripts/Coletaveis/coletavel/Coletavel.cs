using UnityEngine;

public class Coletavel : GO
{    
    private static ColetavelContexto contexto;

    private bool miraSelecionada;
    private ColetavelAnimacao animacao;      

    public Coletavel()
        : base(contexto, contexto.nomeador.getName())
    {
        iniciarColetavelAnimacao();
    }

    public Coletavel(Transform transform)
        : base(transform)
    {
        iniciarColetavelAnimacao();
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

    public void preso()
    {
        setLayer(LayerMask.NameToLayer(TagUtils.LAYER_COLETAVELGAIOLA));
        fixarEixoXY();
    }

    public bool isPreso()
    {
        return isLayer(LayerMask.NameToLayer(TagUtils.LAYER_COLETAVELGAIOLA));
    }

    public void soltar()
    {
        desimantar();
    }

    public bool isLivre()
    {
        return !isPreso();
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

    private void iniciarColetavelAnimacao()
    {
        Animator animator = extrairAnimator("animacao");
        animacao = new ColetavelAnimacao(animator);
    }

    public static void configurar(CircleCollider2D referenciaColliderColetadoArg, ColetaveisDto coletaveisDto)
    {
        contexto = new ColetavelContexto(coletaveisDto, referenciaColliderColetadoArg);                
    }
}
