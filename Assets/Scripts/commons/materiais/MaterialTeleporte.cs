using UnityEngine;

public class MaterialTeleporte 
{
    private static Material matEstaticoTeleporte;
    public Material materialTeleporte { get; private set; }

    public MaterialTeleporte()
    {
        materialTeleporte = new Material(matEstaticoTeleporte);
    }

    public void addTroca(Sprite sprIn, Sprite sprOut)
    {
        addTrocaIn(sprIn);
        addTrocaOut(sprOut);
    }

    public void addTrocaIn(Sprite sprite)
    {
        materialTeleporte.SetTexture("inSprite", sprite.texture);
    }

    public void addTrocaOut(Sprite sprite)
    {
        materialTeleporte.SetTexture("outSprite", sprite.texture);
    }

    public void addValorDeTroca(float troca)
    {
        materialTeleporte.SetFloat("valor", troca);
    }

    public static void configurar(Material materialTrocaArg)
    {
        matEstaticoTeleporte = materialTrocaArg;
    }
}
