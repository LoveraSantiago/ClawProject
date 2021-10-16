using UnityEngine;

public class PlayerPrefsColetaveis : MonoBehaviour
{
    public static bool isFamiliaNotLocked(string nomeFamilia)
    {
        return !isFamiliaLocked(nomeFamilia);
    }

    public static bool isFamiliaLocked(string nomeFamilia)
    {
        int resultado = PlayerPrefs.GetInt(nomeFamilia);
        if (resultado == 0) return true;
        return false;
    }

    public static bool isColetavelDisponivel(string nomeColetavel)
    {
        int resultado = PlayerPrefs.GetInt(nomeColetavel);
        if (resultado == 1) return true;
        return false;
    }

    public static void unlockFamilia(string nomeFamilia)
    {
        PlayerPrefs.SetInt(nomeFamilia, 1);
    }
}
