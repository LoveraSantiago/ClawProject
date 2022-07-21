using UnityEngine;

public class MaterialGrayScale 
{
    private static Material matGrayScale;

    public static Material of(Sprite sprite)
    {
        Material material = new Material(matGrayScale);
        return changeSprite(material, sprite);
    }

    public static Material changeSprite(Material material, Sprite sprite)
    {
        material.SetTexture("main_text", sprite.texture);
        return material;
    }

    public static void configurar(Material matGrayScaleArg)
    {
        matGrayScale = matGrayScaleArg;
    }

    public static bool isMaterialGrayScale(Material material)
    {
        if (material == null) return false;
        return "mat-grayscale".Equals(material.name);
    }
}
