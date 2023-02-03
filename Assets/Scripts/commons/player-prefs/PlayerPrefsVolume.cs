using UnityEngine;

public class PlayerPrefsVolume 
{
    private static readonly string VOLUME = "VOLUME";
    private static readonly string ESTADO_BACKGROUND = "ESTADOSOMBACKGROUND";

    public static void salvarVolume(float volume)
    {
        PlayerPrefs.SetFloat(VOLUME, volume);
    }

    public static float recuperarVolume()
    {
        return PlayerPrefs.GetFloat(VOLUME, 1);
    }

    public static void salvarEstadoSomBackground(bool estado)
    {
        int valorEstado = 0;
        if (estado)
        {
            valorEstado = 1;
        }
        PlayerPrefs.SetInt(ESTADO_BACKGROUND, valorEstado);
    }

    public static bool recuperarEstadoSomBackground()
    {
        int valorEstado = PlayerPrefs.GetInt(ESTADO_BACKGROUND, 1);
        if(valorEstado == 1)
        {
            return true;
        }
        return false;
    }
}
