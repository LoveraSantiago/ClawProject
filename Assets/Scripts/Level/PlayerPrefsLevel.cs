using UnityEngine;

public class PlayerPrefsLevel 
{
    private static readonly string LEVEL = "LEVEL";

    public static void salvarMecanica(LevelFlowManager.LEVEL level)
    {
        PlayerPrefs.SetInt(LEVEL, (int) level);
    }

    public static LevelFlowManager.LEVEL recuperarLevel(LevelFlowManager.LEVEL level)
    {
        int levelSalvo = PlayerPrefs.GetInt(LEVEL);
        PlayerPrefs.DeleteKey(LEVEL);

        if(levelSalvo == 0)
        {
            return level;
        }
        return (LevelFlowManager.LEVEL) levelSalvo;
    }
}
