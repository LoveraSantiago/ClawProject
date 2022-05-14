using UnityEngine;

public class SingleCompColorivel : ComponenteColorivel
{
    private float alpha;
    
    private SpriteRenderer sprRenderer;
    private GameObject go;

    public SingleCompColorivel(GameObject go)
        : this(go, 1)
    {        
    }

    public SingleCompColorivel(GameObject go, float alpha)
    {
        this.go = go;
        sprRenderer = go.GetComponent<SpriteRenderer>();        
        this.alpha = alpha;
    }

    public void resetCor()
    {
        sprRenderer.color = Color.white;
    }

    public void passarCor(Color cor)
    {
        cor.a = alpha;
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
