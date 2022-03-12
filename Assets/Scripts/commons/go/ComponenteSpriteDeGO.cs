using UnityEngine;

public class ComponenteSpriteDeGO : ComponenteEstadoDeGO
{
    public string nomeSprite { get; private set; }
    private SpriteRenderer spriteRenderer;

    public ComponenteSpriteDeGO(GameObject go) 
        : base(go){}

    protected void carregarSpriteRenderer()
    {
        carregarSpriteRenderer(getGo());
    }

    protected void carregarSpriteRenderer(GameObject gameObject)
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    protected void carregarSpriteRenderer(SpriteRenderer spriteRenderer)
    {
        this.spriteRenderer = spriteRenderer;
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

    public void addMaterial(Material material)
    {
        spriteRenderer.material = material;
    }
}
