using UnityEngine;

public class DestaqueGrayScale 
{
    private bool destaque;

    public DestaqueGrayScale()
    {
        destaque = true;
    }

    public DestaqueGrayScale(AbstractLevel level)
    {
        if (level.isColetavelLevel() || level.isOrdemLevel())
        {
            destaque = true;
        }
    }

    public void destacar(ColetavelTile coletavel)
    {
        if (destaque)
        {
            HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
            Material materialGray = helperInGame.getMaterialGrayscaleTo(coletavel);
            coletavel.addMaterial(materialGray);
        }
    }
}
