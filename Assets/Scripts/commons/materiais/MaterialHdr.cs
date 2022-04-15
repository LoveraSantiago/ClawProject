using UnityEngine;

public class MaterialHdr //REMOVER ESSA CLASSE ASSIM Q POSSIVEL
{
    private static Material materialHdr;    

    public static Material of(Sprite sprite)
    {
        Material material = new Material(materialHdr);
        material.SetTexture("MainTexture", sprite.texture);
        return material;
    }

    public static void configurar(Material materialHdrArg)
    {
        materialHdr = materialHdrArg;        
    }
}
