using UnityEngine;

public class Coletavel : GO
{    
    private static ColetavelContexto contexto;

    public bool isMiraSelecionada { get; private set; }
    public string nomeGaiolaAprisionadora { get; private set; }

    private ColetavelAnimacao animacao;      

    public Coletavel()
        : base(contexto, new ProcuradorDeSpriteRenderer("imagem"), contexto.nomeador.getName())
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
        isMiraSelecionada = false;
    }

    public void ligarAnimacaoMiraSelecionado()
    {
        animacao.ligarMiraSelecionada();
        isMiraSelecionada = true;
    }

    public void desligarAnimacao()
    {
        animacao.desligar();
        isMiraSelecionada = false;
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
        Animator animator = extrairComponente<Animator>();
        animacao = new ColetavelAnimacao(animator);
    }

    public static void configurar(CircleCollider2D referenciaColliderColetadoArg, ColetaveisDto coletaveisDto)
    {
        contexto = new ColetavelContexto(coletaveisDto, referenciaColliderColetadoArg);                
    }
}
