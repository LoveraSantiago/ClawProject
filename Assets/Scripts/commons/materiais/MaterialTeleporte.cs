using UnityEngine;

public class MaterialTeleporte 
{
    private static readonly int ID_SPRITE_IN  = Shader.PropertyToID("inSprite");
    private static readonly int ID_SPRITE_OUT = Shader.PropertyToID("outSprite");
    private static readonly int ID_VALOR      = Shader.PropertyToID("valor");
    private static readonly int ID_COR        = Shader.PropertyToID("_cor");

    private static Material matEstaticoTeleporte;
    public Material materialTeleporte { get; private set; }

    public MaterialTeleporte()
    {
        materialTeleporte = new Material(matEstaticoTeleporte);
    }

    public void addTroca(Sprite sprIn, Sprite sprOut, Color corDivisoria)
    {
        addTrocaIn(sprIn);
        addTrocaOut(sprOut);
        setCor(corDivisoria);
    }

    private void addTrocaIn(Sprite sprite)
    {
        materialTeleporte.SetTexture(ID_SPRITE_IN, sprite.texture);
    }
    
    public void addTrocaIn(Sprite sprite, Color corDivisoria)
    {
        addTrocaIn(sprite);
        setCor(corDivisoria);
    }

    public void addTrocaOut(Sprite sprite)
    {
        materialTeleporte.SetTexture(ID_SPRITE_OUT, sprite.texture);
    }

    public void addValorDeTroca(float troca)
    {
        materialTeleporte.SetFloat(ID_VALOR, troca);        
    }

    private void setCor(Color corDivisoria)
    {
        materialTeleporte.SetColor(ID_COR, corDivisoria);
    }

    public static void configurar(Material materialTrocaArg)
    {
        matEstaticoTeleporte = materialTrocaArg;
    }
}
