using UnityEngine;

public class PlayerPrefsGarraMecanica 
{
    private static readonly string MECANICA = "MECANICA";

    public static void salvarMecanica(GarraManager.MECANICA_GARRA mecanica)
    {
        PlayerPrefs.SetInt(MECANICA, (int) mecanica);
    }

    public static GarraManager.MECANICA_GARRA recuperarMecanica(GarraManager.MECANICA_GARRA defaultMecanica)
    {
        int mecanicaSalva = PlayerPrefs.GetInt(MECANICA);
        PlayerPrefs.DeleteKey(MECANICA);

        if(mecanicaSalva == 0)
        {
            return defaultMecanica;
        }
        return (GarraManager.MECANICA_GARRA) mecanicaSalva;
    }
}
