using UnityEngine;

//TODO NOME BEM RUIM MUDAR PARA LEVELMANAGER
public class LevelFlowManager 
{
    public enum LEVEL
    {
        HUM  = 1,
        DOIS = 2,
        TRES = 3,
        PUP  = 999999999,
    }

    public static AbstractLevel getLevelByEnum(LEVEL level)
    {
        switch (level)
        {
            case LEVEL.HUM : return new Level1();
            case LEVEL.DOIS: return new Level2();
            case LEVEL.TRES: return new Level3();
            case LEVEL.PUP: return new LevelPup();
        }
        Debug.LogError("NAO FOI CRIADO LEVEL PARA ESSE ENUM");
        return null;
    }

    public static AbstractLevel getLevelByString(string level)
    {
        switch (level)
        {
            case "1": return getLevelByEnum(LEVEL.HUM);
            case "2": return getLevelByEnum(LEVEL.DOIS);
            case "3": return getLevelByEnum(LEVEL.TRES);
            case "999999999": return getLevelByEnum(LEVEL.PUP);
        }
        return null;
    }
}

