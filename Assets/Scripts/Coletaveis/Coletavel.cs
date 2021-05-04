using UnityEngine;
using System.Collections.Generic;

public class Coletavel 
{
    private static Nomeador nomeador;
    private static GameObject mainTile;
    private static Transform mainTileParent;
    private static Dictionary<string, Sprite> dicionarioDeSprites;

    public string nome { get; private set; }
    public string nomeSprite { get; private set; }

    protected GameObject goColetavel;
    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;    
    
    public Coletavel()
        :this(mainTile, nomeador.getName())
    {        
    }   

    public Coletavel(GameObject go, string nome)
    {
        goColetavel = GameObject.Instantiate(go, go.transform.position, Quaternion.Euler(Vector3.zero), mainTileParent);
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

    public void receberSprite(string nomeSprite)
    {
        receberSprite(dicionarioDeSprites[nomeSprite]);
    }

    public void parar()
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.angularVelocity = 0;
    }

    public void desligar()
    {
        goColetavel.SetActive(false);
    }

    public virtual void ligar()
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

    public void fixarVerticalmente()
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

    public static void configurar(GameObject mainTileArg, Transform mainTileParentArg, List<Sprite> characters)
    {
        mainTile = mainTileArg;
        mainTileParent = mainTileParentArg;

        nomeador = new Nomeador();

        dicionarioDeSprites = new Dictionary<string, Sprite>();
        for(int contador = 0; contador < characters.Count; contador++)
        {
            Sprite spriteIt = characters[contador];
            dicionarioDeSprites.Add(spriteIt.name, spriteIt);
        }
    }
}
