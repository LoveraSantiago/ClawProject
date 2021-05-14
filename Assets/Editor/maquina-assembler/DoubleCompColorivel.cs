using UnityEngine;

public class DoubleCompColorivel : ComponenteColorivel
{
    private string nome1;
    private string nome2;

    private SpriteRenderer sprRender1;
    private SpriteRenderer sprRender2;

    private Color corOriginal1;
    private Color corOriginal2;

    public DoubleCompColorivel(string nome1, string nome2, GameObject go1, GameObject go2)
    {
        this.nome1 = nome1;
        this.nome2 = nome2;

        sprRender1 = go1.GetComponent<SpriteRenderer>();
        sprRender2 = go2.GetComponent<SpriteRenderer>();

        corOriginal1 = sprRender1.color;
        corOriginal2 = sprRender2.color;
    }

    public void passarCor(Color cor)
    {
        sprRender1.color = cor;
        sprRender2.color = cor;
    }

    public void resetCor()
    {
        sprRender1.color = corOriginal1;
        sprRender2.color = corOriginal2;
    }
}
