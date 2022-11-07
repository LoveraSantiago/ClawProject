using UnityEngine;

public class MaterialGrayScale 
{
    private static readonly int ID_MAIN_TEXTURE = Shader.PropertyToID("main_text");
    private static Material matGrayScale;

    public static Material of()
    {
        return new Material(matGrayScale);
    }

    public static Material of(Sprite sprite)
    {
        Material material = of();
        return changeSprite(material, sprite);
    }

    public static Material changeSprite(Material material, Sprite sprite)
    {
        material.SetTexture(ID_MAIN_TEXTURE, sprite.texture);
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
