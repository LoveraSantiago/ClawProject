using UnityEngine;

public class ComponenteColorivel 
{
    public string nome { get; private set; }

    private GameObject go;
    private SpriteRenderer sprRenderer;
    private Color corOriginal;

    public ComponenteColorivel(string nome, GameObject go)
    {
        this.nome = nome;
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
}
