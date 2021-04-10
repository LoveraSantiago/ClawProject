using UnityEngine;

public class Coletavel 
{
    private static Nomeador nomeador = new Nomeador();
    private static GameObject mainTile;

    public string nome { get; private set; }
    public string nomeSprite { get; private set; }

    private GameObject goColetavel;
    private SpriteRenderer spriteRenderer;
    
    public Coletavel()
    {
        goColetavel = GameObject.Instantiate(mainTile, mainTile.transform.position, mainTile.transform.rotation);
        nome = nomeador.getName();
        goColetavel.name = nome;
        spriteRenderer = goColetavel.GetComponent<SpriteRenderer>();
    }

    public void colocarNaPosicao(Vector3 posicao) {
        goColetavel.transform.position = posicao;
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

    public static void configurarMainTile(GameObject mainTileArg)
    {
        mainTile = mainTileArg;
    }
}
