using UnityEngine;

public class MaterialHdr //REMOVER ESSA CLASSE ASSIM Q POSSIVEL
{
    private static readonly int ID_MAIN_TEXTURE = Shader.PropertyToID("MainTexture");

    private static Material materialHdrAditivo;    
    private static Material materialHdrAlpha;

    public static Material ofAditivo()
    {
        return new Material(materialHdrAditivo); ;
    }

    public static Material ofAditivo(Sprite sprite)
    {
        Material material = ofAditivo();
        return setTexture(material, sprite);
    }

    public static Material ofAlpha()
    {
        return new Material(materialHdrAlpha);
    }

    public static Material ofAlpha(Sprite sprite)
    {
        Material material = ofAlpha();
        return setTexture(material, sprite);
    }

    public static Material setTexture(Material material, Sprite sprite)
    {
        material.SetTexture(ID_MAIN_TEXTURE, sprite.texture);
        return material;
    }

    public static void configurar(Material materialHdrAditivoArg, Material materialHdrAlphaArg)
    {
        materialHdrAditivo = materialHdrAditivoArg;
        materialHdrAlpha = materialHdrAlphaArg;
    }
}
