using UnityEngine;

public abstract class Coletavel 
{
    protected static ColetavelContextoEstatico context;

    public string nome { get; private set; }
    public string nomeSprite { get; private set; }

    private bool ativo;
    protected GameObject goColetavel;
    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;    
    
    public Coletavel()
        :this(context.mainTile, context.nomeador.getName())
    {        
    }   

    public Coletavel(GameObject go, string nome)
    {
        goColetavel = GameObject.Instantiate(go, go.transform.position, Quaternion.Euler(Vector3.zero), context.mainTileParent);
        this.nome = nome;
        goColetavel.name = nome;
        spriteRenderer = goColetavel.GetComponent<SpriteRenderer>();
        rigidbody = goColetavel.GetComponent<Rigidbody2D>();        
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

    public Vector3 getPosicao()
    {
        return goColetavel.transform.position;
    }

    public Vector2 getPosicaoRigidBody()
    {
        return rigidbody.transform.position;
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

    public void imantar()
    {
        goColetavel.layer = LayerMask.NameToLayer("Atracao");
    }

    public void desimantar()
    {
        goColetavel.layer = LayerMask.NameToLayer("Coletavel");
    }

    public void addParent(Transform parent)
    {
        goColetavel.transform.SetParent(parent);
    }

    public void receberSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
        nomeSprite = sprite.name;
        spriteRenderer.sortingOrder = 31;
    }

    public void receberSprite(string nomeSprite)
    {
        receberSprite(context.dicionarioDeSprites[nomeSprite]);
    }

    public void addVelocidadeAngular(float velocidadeAngular)
    {
        rigidbody.angularVelocity = velocidadeAngular;
    }

    public void addVelocidade(Vector2 velocidade)
    {
        rigidbody.velocity = velocidade;
    }

    public virtual void parar()
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.angularVelocity = 0;
    }

    public void desligar()
    {
        ativo = false;
        goColetavel.SetActive(false);
    }

    public virtual void ligar()
    {
        ativo = true;
        goColetavel.SetActive(true);
    }

    public bool isAtivo()
    {
        return ativo;
    }

    public virtual void desligarGravidade()
    {
        rigidbody.gravityScale = 0;
    }

    public virtual void ligarGravidade()
    {
        rigidbody.gravityScale = 1;
    }

    public virtual void fixarVerticalmente()
    {
        rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }

    public void desafixarVerticalmente()
    {
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public Sprite getSprite()
    {
        return spriteRenderer.sprite;
    }

    public bool hasEqualsSprite(Coletavel coletavelOutro)
    {
        return nomeSprite.Equals(coletavelOutro.nomeSprite);
    }   

    public static void configurar(GameObject mainTile, Transform mainTileParent, Sprite[] characters)
    {
        context = new ColetavelContextoEstatico();
        context.configurar(mainTile, mainTileParent, characters);
    }
}
