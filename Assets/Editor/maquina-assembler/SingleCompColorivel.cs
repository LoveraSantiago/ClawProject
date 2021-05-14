using UnityEngine;

public class SingleCompColorivel : ComponenteColorivel
{
    private string nome;
    
    private SpriteRenderer sprRenderer;
    private Color corOriginal;

    public SingleCompColorivel(GameObject go)
    {
        this.nome = go.name;        
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
}
