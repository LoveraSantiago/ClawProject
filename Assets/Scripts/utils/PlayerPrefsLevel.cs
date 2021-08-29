using UnityEngine;

public class PlayerPrefsUtils 
{
    private static readonly string LEVEL = "LEVEL";
    private static readonly string PUP = "PUP";

    public static void salvarLevel(LevelFlowManager.LEVEL level)
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

    public static void salvarIndicePup(int indicePup)
    {
        PlayerPrefs.SetInt(PUP, indicePup);
    }

    public static int recuperarIndicePup()
    {
        int indiceSalvo = PlayerPrefs.GetInt(PUP);
        PlayerPrefs.DeleteKey(PUP);
        return indiceSalvo;
    }
}
