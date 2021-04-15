using UnityEngine;

public class Coletavel 
{
    private static Nomeador nomeador = new Nomeador();
    private static GameObject mainTile;
    private static Transform mainTileParent;

    public string nome { get; private set; }
    public string nomeSprite { get; private set; }

    private GameObject goColetavel;
    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;    
    
    public Coletavel()
        :this(mainTile, nomeador.getName())
    {        
    }

    public Coletavel(GameObject go, string nome)
    {
        goColetavel = GameObject.Instantiate(go, go.transform.position, go.transform.rotation, mainTileParent);
        this.nome = nome;
        goColetavel.name = nome;
        spriteRenderer = goColetavel.GetComponent<SpriteRenderer>();
        rigidbody = goColetavel.GetComponent<Rigidbody2D>();
    }   

    public void colocarNaPosicao(Vector3 posicao) {
        goColetavel.transform.position = posicao;
    }

    public void colocarNaPosicao(Vector3 posicao, Quaternion rotacao) {
        colocarNaPosicao(posicao);
        rigidbody.transform.rotation = rotacao;
    }   

    public void disparar(Vector3 posicao, float angulo, float velocidade)
    {
        Quaternion quatAngulo = Quaternion.Euler(0, 0, angulo);
        mainTile.transform.rotation = quatAngulo;
        colocarNaPosicao(posicao, quatAngulo);
        rigidbody.AddForce(mainTile.transform.up * velocidade, ForceMode2D.Impulse);
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

    public void desligar()
    {
        goColetavel.SetActive(false);
    }

    public void ligar()
    {
        goColetavel.SetActive(true);
    }

    public void desligarGravidade()
    {
        rigidbody.gravityScale = 0;
    }

    public void ligarGravidade()
    {
        rigidbody.gravityScale = 1;
    }

    public Sprite getSprite()
    {
        return spriteRenderer.sprite;
    }

    public bool hasEqualsSprite(Coletavel coletavelOutro)
    {
        return nomeSprite.Equals(coletavelOutro.nomeSprite);
    }

    public static void configurarMainTile(GameObject mainTileArg, Transform mainTileParentArg)
    {
        mainTile = mainTileArg;
        mainTileParent = mainTileParentArg;
    }
}
