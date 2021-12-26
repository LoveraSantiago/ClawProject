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
        if (LevelUtils.isLevelDeDestaque(level))
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
            coletavel.colocarNoLayerComum();
        }
    }
}
