using UnityEngine;

public class MaterialOutline 
{
    private static readonly int ID_MAIN_TEXTURE = Shader.PropertyToID("_MaintText");
    private static Material matOutline;

    public static Material of(Sprite sprite)
    {
        Material material = new Material(matOutline);
        material.SetTexture(ID_MAIN_TEXTURE, sprite.texture);
        return material;
    }

    public static void configurar(Material matOutlineArg)
    {
        matOutline = matOutlineArg;
    }
}
