using UnityEngine;

public class PowerUpHelper 
{
    public static Sprite[] getAllSpritesPowerUp()
    {
        PowerUpEntidade[] allPups = FactoryPowerUpEntidade.getAllPowerUps();
        Sprite[] sprites = new Sprite[allPups.Length];
        for (int contador = 0; contador < sprites.Length; contador++)
        {
            sprites[contador] = allPups[contador].sprIconPowerUp;
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
            result[contador] = getNomePupBySprite(allPups, sprites[contador]);
        }
        return result;
    }

    public static int getQtdPupsFromIndice(int indice)
    {
        PowerUpEntidade pupEntidade = FactoryPowerUpEntidade.getPowerUpFromIndice(indice);
        int qtdPup = recuperarQtdPup(pupEntidade);
        return qtdPup;
    }   

    public static PowerUpEntidade getTipoPupBySprite(Sprite sprite)
    {
        PowerUpEntidade[] allPups = FactoryPowerUpEntidade.getAllPowerUps();
        for (int contador = 0; contador < allPups.Length; contador++)
        {
            if (allPups[contador].sprIconPowerUp == sprite)
            {
                return allPups[contador];
            }
        }
        return null;
    }

    public static int recuperarQtdPup(PowerUpEntidade pupEntidade)
    {        
        if (LevelUtils.isTutorialLevel())
        {
            AbstractLevelTutorial levelTutorial = (AbstractLevelTutorial)ContextoEstaticoUtils.level;
            return levelTutorial.recuperarQtdPup(pupEntidade.tipo);
        }
        return PlayerPrefsPowerUp.recuperarQtdPup(pupEntidade.nome);
    }

    private static string getNomePupBySprite(PowerUpEntidade[] allPups, Sprite sprite)
    {
        for (int contador = 0; contador < allPups.Length; contador++)
        {
            if (allPups[contador].sprIconPowerUp == sprite)
            {
                return allPups[contador].nome;
            }
        }
        return null;
    }

}
