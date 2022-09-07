using UnityEngine;

public class PlayerPrefsMapas 
{    
    private static readonly string LEVEL_LIBERADO = "level-liberado";
    private static readonly string MAPA_NAVEGACAO = "mapa-naveg";

    public static int getIndiceMapaLiberado()//TODO ADICIONAR CRIPTOGRAFIA SEGURANCA
    {
        return (getIndiceLevelLiberado() / 10) + 1;        
    }

    public static MapaEntidade getIndiceNavegacaoMapa()
    {
        int indice = PlayerPrefs.GetInt(MAPA_NAVEGACAO, 1);
        return HelperMapaEntidade.getMapaEntidadeByIndice(indice);
    }

    public static int getIndiceLevelLiberado()
    {
        int indice = PlayerPrefs.GetInt(LEVEL_LIBERADO, 1);
        Debug.Log("Recuperando indice level " + indice);
        return indice;
    }

    public static void salvarIndiceLevelLiberado(int indiceLevel)
    {
        int indiceAtual = getIndiceLevelLiberado();
        if(indiceLevel > indiceAtual)
        {
            Debug.Log("Salvando indice level " + indiceLevel);
            PlayerPrefs.SetInt(LEVEL_LIBERADO, indiceLevel);
        }
    }

    public static void salvarIndiceNavegacaoMapa(MapaEntidade mapaEntidade)
    {
        PlayerPrefs.SetInt(MAPA_NAVEGACAO, mapaEntidade.id);        
    }
}
