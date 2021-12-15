using UnityEngine;

public class MaterialGrayScale 
{
    private static Material matGrayScale;

    public static Material of(Sprite sprite)
    {
        Material material = new Material(matGrayScale);
        material.SetTexture("main_text", sprite.texture);
        return material;
    }

    public static void configurar(Material matGrayScaleArg)
    {
        matGrayScale = matGrayScaleArg;
    }
}
