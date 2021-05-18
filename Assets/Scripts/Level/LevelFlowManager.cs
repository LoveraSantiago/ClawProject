using UnityEngine;

//TODO NOME BEM RUIM MUDAR PARA LEVELMANAGER
public class LevelFlowManager 
{
    public enum LEVEL
    {
        HUM = 1,
        DOIS = 2
    }

    public static AbstractLevel getLevelByEnum(LEVEL level)
    {
        switch (level)
        {
            case LEVEL.HUM: return new Level1();
            case LEVEL.DOIS: return new Level2();
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
        }
        return null;
    }
}

