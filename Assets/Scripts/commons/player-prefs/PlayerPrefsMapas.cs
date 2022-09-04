using UnityEngine;

public class PlayerPrefsMapas 
{
    private static readonly string MAPA_MAX = "mapa-max";
    private static readonly string MAPA_NAVEGACAO = "mapa-naveg";

    public static int getMapaMaxLevel()//TODO ADICIONAR CRIPTOGRAFIA SEGURANCA
    {
        return PlayerPrefs.GetInt(MAPA_MAX, 1);
    }

    public static int getIndiceNavegacaoMapa()
    {
        return PlayerPrefs.GetInt(MAPA_NAVEGACAO, 1) - 1;
    }

    public static void salvarIndiceNavegacaoMapa(int indice)
    {
        PlayerPrefs.SetInt(MAPA_NAVEGACAO, indice);
    }
}
