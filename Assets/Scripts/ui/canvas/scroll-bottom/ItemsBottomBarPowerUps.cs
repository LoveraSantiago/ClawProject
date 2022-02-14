using UnityEngine;

public class ItemsBottomBarPowerUps : ItemsBottomBar
{
    private PowerUpEntidade[] allPups;
    private PowerUpEntidade pupAtual;

    public ItemsBottomBarPowerUps()
    {
        allPups = FactoryPowerUpEntidade.getAllPowerUps();
    }

    public void configurarIndicePesquisado(int indice)
    {
        pupAtual = allPups[indice];
    }

    public string getLabelQtdDoItem()
    {        
        return PlayerPrefsPowerUp.recuperarQtdPup(pupAtual.nome).ToString();
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
