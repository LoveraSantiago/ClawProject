using UnityEngine;

public class DestaqueGrayScale 
{
    private bool destaque;

    public DestaqueGrayScale()
    {
        if (LevelUtils.isLevelDeDestaque())
        {
            destaque = true;
        }        
    }    

    public void destacar(Coletavel coletavel)
    {
        if (destaque)
        {            
            Material materialGray = HelperColetaveisInGame.getMaterialGrayscaleTo(coletavel);
            coletavel.addMaterial(materialGray);
            coletavel.colocarNoOrderComum();
        }
    }
}
