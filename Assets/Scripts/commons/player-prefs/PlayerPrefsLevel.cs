using UnityEngine;

public class PlayerPrefsLevel : MonoBehaviour
{
    private static readonly string LEVEL = "LEVEL";

    public static void salvarLevel(LevelFlowManager.LEVEL level)
    {
        PlayerPrefs.SetInt(LEVEL, (int)level);
    }

    public static LevelFlowManager.LEVEL recuperarELimparLevel(LevelFlowManager.LEVEL level)
    {
        int levelSalvo = PlayerPrefs.GetInt(LEVEL);
        PlayerPrefs.DeleteKey(LEVEL);

        if (levelSalvo == 0)
        {
            return level;
        }
        return (LevelFlowManager.LEVEL)levelSalvo;
    }

}
