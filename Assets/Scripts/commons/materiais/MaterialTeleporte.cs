using UnityEngine;

public class MaterialTeleporte 
{
    private static readonly int ID_SPRITE_IN  = Shader.PropertyToID("inSprite");
    private static readonly int ID_SPRITE_OUT = Shader.PropertyToID("outSprite");
    private static readonly int ID_VALOR      = Shader.PropertyToID("valor");

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
        materialTeleporte.SetTexture(ID_SPRITE_IN, sprite.texture);
    }

    public void addTrocaOut(Sprite sprite)
    {
        materialTeleporte.SetTexture(ID_SPRITE_OUT, sprite.texture);
    }

    public void addValorDeTroca(float troca)
    {
        materialTeleporte.SetFloat(ID_VALOR, troca);
    }

    public static void configurar(Material materialTrocaArg)
    {
        matEstaticoTeleporte = materialTrocaArg;
    }
}
