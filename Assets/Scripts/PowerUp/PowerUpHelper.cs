using UnityEngine;

public class PowerUpHelper 
{
    public static Sprite[] getAllSpritesPowerUp()
    {
        PowerUpEntidade[] allPups = FactoryPowerUpEntidade.getAllPowerUps();
        Sprite[] sprites = new Sprite[allPups.Length];
        for (int contador = 0; contador < sprites.Length; contador++)
        {
            sprites[contador] = allPups[contador].sprPowerUp;
        }
        return sprites;
    }

    public static string getNomePupByTipo(PowerUpEnums.TIPO tipo)
    {
        PowerUpEntidade[] allPups = FactoryPowerUpEntidade.getAllPowerUps();
        for (int contador = 0; contador < allPups.Length; contador++)
        {
            if (allPups[contador].tipo == tipo)
            {
                return allPups[contador].nome;
            }
        }
        return null;
    }

    public static string[] getNomesPupsBySprites(Sprite[] sprites)
    {
        PowerUpEntidade[] allPups = FactoryPowerUpEntidade.getAllPowerUps();
        string[] result = new string[sprites.Length];
        for (int contador = 0; contador < sprites.Length; contador++)
        {
            result[contador] = getPupNomeBySprite(allPups, sprites[contador]);
        }
        return result;
    }

    private static string getPupNomeBySprite(PowerUpEntidade[] allPups, Sprite sprite)
    {
        for (int contador = 0; contador < allPups.Length; contador++)
        {
            if (allPups[contador].sprPowerUp == sprite)
            {
                return allPups[contador].nome;
            }
        }
        return null;
    }

}
