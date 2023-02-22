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
        setLayer(LayerUtils.LAYER_ELEVADOR_INDICE);
    }

    public void colocarNoLayerNormal()
    {
        setLayer(LayerUtils.LAYER_NORMAL_INDICE);        
    }

    public bool isLayerNormal()
    {
        return isLayer(LayerUtils.LAYER_NORMAL_INDICE);
    }

    public bool isLayerPreso()
    {
        return isLayer(LayerUtils.LAYER_COLETAVELGAIOLA_INDICE);
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
        setLayer(LayerUtils.LAYER_ATRACAO_INDICE);
    }

    public void desimantar()
    {
        setLayer(LayerUtils.LAYER_COLETAVEL_INDICE);
    }

    public bool isImantado()
    {
        return isLayer(LayerUtils.LAYER_ATRACAO_INDICE);
    }

    public void naoInteracaoComOutrosColetaveis()
    {
        setLayer(LayerUtils.LAYER_NAOINTERACAOCOLETAVEL_INDICE);
    }

    public void preso(string nomeGaiola)
    {
        setLayer(LayerUtils.LAYER_COLETAVELGAIOLA_INDICE);
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
        base.ligarComEstado();
        ligarAnimacaoIdleOvo();
    }

    public void interacaoComOutrosColetaveis()
    {
        desimantar();
    }   

    public bool isTouchingCentroDaGarra()
    {        
        Collider2D collider2d = Physics2D.OverlapCircle(getPosicao(), 0.3f, LayerUtils.LAYER_GARRACCENTRO_MASK);
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
