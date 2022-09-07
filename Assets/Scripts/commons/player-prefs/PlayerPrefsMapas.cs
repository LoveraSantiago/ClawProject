using UnityEngine;

public class PlayerPrefsMapas 
{
    private static readonly string MAPA_LIBERADO  = "mapa-liberado";
    private static readonly string LEVEL_LIBERADO = "level-liberado";
    private static readonly string MAPA_NAVEGACAO = "mapa-naveg";

    public static int getIndiceMapaLiberado()//TODO ADICIONAR CRIPTOGRAFIA SEGURANCA
    {
        return PlayerPrefs.GetInt(MAPA_LIBERADO, 1);
    }

    public static MapaEntidade getIndiceNavegacaoMapa()
    {
        int indice = PlayerPrefs.GetInt(MAPA_NAVEGACAO, 1);
        return HelperMapaEntidade.getMapaEntidadeByIndice(indice);
    }

    public static int getIndiceLevelLiberado()
    {
        return PlayerPrefs.GetInt(LEVEL_LIBERADO, 1);
    }

    public static void salvarIndiceLevelLiberado(int indiceLevel)
    {
        int indiceAtual = getIndiceLevelLiberado();
        if(indiceLevel > indiceAtual)
        {
            PlayerPrefs.SetInt(LEVEL_LIBERADO, indiceLevel);
        }
    }

    public static void salvarIndiceNavegacaoMapa(MapaEntidade mapaEntidade)
    {
        PlayerPrefs.SetInt(MAPA_NAVEGACAO, mapaEntidade.id);        
    }
}
