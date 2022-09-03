using UnityEngine;

public class PlayerPrefsMapas 
{
    private static readonly string MAPA_MAX = "mapa-max";

    public static int getMapaMaxLevel()
    {
        return PlayerPrefs.GetInt(MAPA_MAX, 1);
    }
}
