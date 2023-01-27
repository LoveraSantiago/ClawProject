using UnityEngine;

public class PlayerPrefsVolume 
{
    private static readonly string VOLUME = "VOLUME";

    public static void salvarVolume(float volume)
    {
        PlayerPrefs.SetFloat(VOLUME, volume);
    }

    public static float recuperarVolume()
    {
        return PlayerPrefs.GetFloat(VOLUME, 1);
    }
}
