using UnityEngine;

public class ItemsBottomBarPups : ItemsBottomBar
{
    private PowerUpEntidade[] allPups;

    public ItemsBottomBarPups()
    {
        allPups = FactoryPowerUpEntidade.getAllPowerUps();
    }

    public string getLabelQtdDoItemIndice(int indice)
    {
        PowerUpEntidade pupEntidade = allPups[indice];
        return PlayerPrefsPup.recuperarQtdPup(pupEntidade.nome).ToString();
    }

    public int getQtdItems()
    {
        return allPups.Length;
    }

    public Sprite getSprDoItemIndice(int indice)
    {
        return allPups[indice].sprPowerUp;
    }

    public Color getCorImgDoItemIndice(int indice)
    {
        return Color.white;
    }

    public Material getMaterialDoItemIndice(int indice)
    {
        return null;
    }
}
