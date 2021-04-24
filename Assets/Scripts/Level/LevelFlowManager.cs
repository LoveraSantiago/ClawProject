using UnityEngine;

//TODO NOME BEM RUIM MUDAR PARA LEVELMANAGER
public class LevelFlowManager 
{
    public enum LEVEL { HUM, DOIS }

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
}

