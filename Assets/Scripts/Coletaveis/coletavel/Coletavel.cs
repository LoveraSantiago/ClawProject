using UnityEngine;

public class Coletavel : ComponenteAnimacaoDeColetavel
{    
    private static ColetavelContexto contexto;    
    public string nomeGaiolaAprisionadora { get; private set; }    

    public Coletavel()
        : base(contexto, new FinderDeSprRenderer1Nivel("imagem"), contexto.nomeador.getName()){}

    public Coletavel(GameObject goParent)
        : base(contexto, goParent, new FinderDeSprRenderer1Nivel("imagem"), contexto.nomeador.getName()) {}

    public Coletavel(Transform transform)
        : base(transform, new FinderDeSprRenderer1Nivel("imagem")) {}       

    public void clearMaterial()
    {
        addMaterial(MaterialSprUnlitDefault.getMaterial());
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

    public void colocarNoOrderDestaque()
    {
        colocarSpriteNoOrder(contexto.sprOrdemDestaque);
    }

    public void colocarNoOrderComum()
    {
        colocarSpriteNoOrder(contexto.sprOrderComum);
        desafixarVerticalmente();
    }

    public void colocarNoOrderEscondido()
    {
        colocarSpriteNoOrder(contexto.sprOrdemEscondido);
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

    public void restaurar()
    {
        base.ligar();
        ligarAnimacaoIdleOvo();
    }

    public void interacaoComOutrosColetaveis()
    {
        desimantar();
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
