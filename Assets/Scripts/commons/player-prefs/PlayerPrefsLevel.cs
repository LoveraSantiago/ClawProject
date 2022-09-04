using UnityEngine;

public class PlayerPrefsLevel
{
    private static readonly string LEVEL = "LEVEL";

    public static void salvarLevel(Level level)
    {
        PlayerPrefs.SetInt(LEVEL, (int)level);
    }
}
