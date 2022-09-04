using UnityEngine;

public class PlayerPrefsMapas 
{
    private static readonly string MAPA_MAX = "mapa-max";
    private static readonly string MAPA_NAVEGACAO = "mapa-naveg";

    public static int getMapaMaxLevelIndice()//TODO ADICIONAR CRIPTOGRAFIA SEGURANCA
    {
        return PlayerPrefs.GetInt(MAPA_MAX, 1);
    }

    public static MapaEntidade getIndiceNavegacaoMapa()
    {
        int indice = PlayerPrefs.GetInt(MAPA_NAVEGACAO, 1);
        return HelperMapaEntidade.getMapaEntidadeByIndice(indice);
    }

    public static void salvarIndiceNavegacaoMapa(MapaEntidade mapaEntidade)
    {
        PlayerPrefs.SetInt(MAPA_NAVEGACAO, mapaEntidade.id);
    }
}
