using UnityEngine;

public class PlayerPrefsLevel : MonoBehaviour
{
    private static readonly string LEVEL = "LEVEL";

    public static void salvarLevel(Level level)
    {
        PlayerPrefs.SetInt(LEVEL, (int)level);
    }

    public static Level recuperarELimparLevel(Level level)
    {
        int levelSalvo = PlayerPrefs.GetInt(LEVEL);
        PlayerPrefs.DeleteKey(LEVEL);

        if (levelSalvo == 0)
        {
            return level;
        }
        return (Level)levelSalvo;
    }

}
