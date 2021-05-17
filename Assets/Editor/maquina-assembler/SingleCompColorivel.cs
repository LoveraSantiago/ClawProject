using UnityEngine;

public class SingleCompColorivel : ComponenteColorivel
{
    private GameObject go;
    
    private SpriteRenderer sprRenderer;
    private Color corOriginal;

    public SingleCompColorivel(GameObject go)
    {
        this.go = go;        
        sprRenderer = go.GetComponent<SpriteRenderer>();
        corOriginal = sprRenderer.color;
    }

    public void resetCor()
    {
        sprRenderer.color = corOriginal;
    }

    public void passarCor(Color cor)
    {
        sprRenderer.color = cor;
    }

    public GameObject getGo()
    {
        return go;
    }

    public Color getCor()
    {
        return sprRenderer.color;
    }
}
