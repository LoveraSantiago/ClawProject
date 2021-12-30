using UnityEngine;

public abstract class GO 
{
    protected static GOContexto context;

    public string nome { get; private set; }
    public string nomeSprite { get; private set; }

    private bool ativo;   
    
    protected GameObject goColetavel;
    protected Rigidbody2D rigidbody;
    protected SpriteRenderer spriteRenderer;    
    
    public GO() :this(context.mainTile, context.nomeador.getName()){}   

    public GO(GameObject go, string nome)
    {
        goColetavel = GameObject.Instantiate(go, go.transform.position, Quaternion.Euler(Vector3.zero), context.mainTileParent);
        this.nome = nome;
        goColetavel.name = nome;
        spriteRenderer = goColetavel.GetComponent<SpriteRenderer>();        
        rigidbody = goColetavel.GetComponent<Rigidbody2D>();        
    }   

    public GO(GameObject go, 
              Transformador<GameObject, GameObject> getGoComSprRenderer, 
              string nome)
        :this(go, nome)
    {
        GameObject goSprite = getGoComSprRenderer.transformar(goColetavel);
        spriteRenderer = goSprite.GetComponent<SpriteRenderer>();
    }

    public bool isVelocidadeYPositiva()
    {
        return rigidbody.velocity.y > 0;
    }

    public virtual void colocarNaPosicao(Vector3 posicao) {        
        goColetavel.transform.position = posicao;
    }

    public void colocarNaPosicao(Vector3 posicao, Quaternion rotacao) {
        colocarNaPosicao(posicao);
        rigidbody.transform.rotation = rotacao;
    } 
    
    public void colocarNoAngulo(Quaternion quaternion)
    {
        rigidbody.transform.rotation = quaternion;
    }

    public void colocarNoAngulo(float angulo)
    {
        rigidbody.transform.rotation = Quaternion.Euler(0, 0, angulo);
    }   

    public void disparar(Vector3 posicao, float angulo, float velocidade)
    {
        Quaternion quatAngulo = Quaternion.Euler(0, 0, angulo);
        context.mainTile.transform.rotation = quatAngulo;
        colocarNaPosicao(posicao, quatAngulo);
        rigidbody.AddForce(context.mainTile.transform.up * velocidade, ForceMode2D.Impulse);
        context.mainTile.transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    public void disparar(float angulo, float velocidade)
    {
        disparar(goColetavel.transform.position, angulo, velocidade);
    }   

    public virtual void parar()
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.angularVelocity = 0;
    }

    public void ligar()
    {
        ativo = true;
        goColetavel.SetActive(true);
    }

    public void desligar()
    {
        ativo = false;
        goColetavel.SetActive(false);
    }

    public Vector3 getPosicao()
    {
        return goColetavel.transform.position;
    }

    protected void setLayer(int layer)
    {
        goColetavel.layer = layer;
    }

    public GameObject getGo()
    {
        return goColetavel;
    }   

    public bool isAtivo()
    {
        return ativo;
    }

    public virtual void ligarGravidadeZero()
    {
        rigidbody.gravityScale = 0;
    }

    public virtual void ligarGravidadeHum()
    {
        rigidbody.gravityScale = 1;
    }

    public void setGravidade(float gravidade)
    {
        rigidbody.gravityScale = gravidade;
    }

    public virtual void fixarEixoX()
    {
        rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }

    public virtual void fixarEixoXY()
    {
        rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    public void desafixarVerticalmente()
    {
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }    

    public void receberSprite(Sprite sprite, int layer)
    {
        spriteRenderer.sprite = sprite;
        nomeSprite = sprite.name;
        colocarSpriteNoLayer(layer);
    }    

    protected void colocarSpriteNoLayer(int layer)
    {
        spriteRenderer.sortingOrder = layer;
    }    

    public Sprite getSprite()
    {
        return spriteRenderer.sprite;
    }   

    public bool hasEqualsSprite(GO coletavelOutro)
    {
        //Debug.Log("spr this " + nomeSprite + " spr other " + coletavelOutro.nomeSprite);
        return nomeSprite.Equals(coletavelOutro.nomeSprite);
    }       

    public static void configurar(ColetaveisDto coletaveisDto)
    {
        context = new GOContexto();
        context.configurar(coletaveisDto);
    }
}
