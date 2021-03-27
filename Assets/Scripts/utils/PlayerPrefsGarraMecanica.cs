using UnityEngine;

public class PlayerPrefsGarraMecanica 
{
    private static readonly string MECANICA = "MECANICA";

    public static void salvarMecanica(Garra.MECANICA_GARRA mecanica)
    {
        PlayerPrefs.SetInt(MECANICA, (int) mecanica);
    }

    public static Garra.MECANICA_GARRA recuperarMecanica(Garra.MECANICA_GARRA defaultMecanica)
    {
        int mecanicaSalva = PlayerPrefs.GetInt(MECANICA);
        PlayerPrefs.DeleteKey(MECANICA);

        if(mecanicaSalva == 0)
        {
            return defaultMecanica;
        }
        return (Garra.MECANICA_GARRA) mecanicaSalva;
    }
}
