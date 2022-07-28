using UnityEngine;

public class PoolMaterialGrayscale : PoolList<Material>
{
    public Material getObjeto(Sprite sprite)
    {
        if (base.hasObjeto())
        {
            Material material = base.getObjeto();
            return MaterialGrayScale.changeSprite(material, sprite);
        }
        else
        {
            //Debug.Log("criando material");
            return MaterialGrayScale.of(sprite);
        }
    }
}
