using UnityEngine;

public class MaterialOutline 
{
    private static Material matOutline;

    public static Material of(Sprite sprite)
    {
        Material material = new Material(matOutline);
        material.SetTexture("_MaintText", sprite.texture);
        return material;
    }

    public static void configurar(Material matOutlineArg)
    {
        matOutline = matOutlineArg;
    }
}
