using UnityEngine;

public class ItemsBottomBarPups : ItemsBottomBar
{
    private PowerUpEntidade[] allPups;
    private PowerUpEntidade pupAtual;

    public ItemsBottomBarPups()
    {
        allPups = FactoryPowerUpEntidade.getAllPowerUps();
    }

    public void configurarIndicePesquisado(int indice)
    {
        pupAtual = allPups[indice];
    }

    public string getLabelQtdDoItem()
    {        
        return PlayerPrefsPup.recuperarQtdPup(pupAtual.nome).ToString();
    }

    public Sprite getSprDoItem()
    {
        return pupAtual.sprPowerUp;
    }

    public Color getCorImgDoItem()
    {
        return Color.white;
    }

    public Material getMaterialDoItem()
    {
        return null;
    }

    public int getQtdItems()
    {
        return allPups.Length;
    }
}
