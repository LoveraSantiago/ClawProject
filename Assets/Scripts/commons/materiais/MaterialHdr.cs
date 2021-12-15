using UnityEngine;

public class MaterialHdr 
{
    private static Material materialHdr;
    private static Material materialHdrLed;

    public static Material ofLed()
    {
        return new Material(materialHdrLed);
    }

    public static Material of(Sprite sprite)
    {
        Material material = new Material(materialHdr);
        material.SetTexture("MainTexture", sprite.texture);
        return material;
    }

    public static void configurar(Material materialHdrArg, Material materialHdrLedArg)
    {
        materialHdr = materialHdrArg;
        materialHdrLed = materialHdrLedArg;
    }
}
