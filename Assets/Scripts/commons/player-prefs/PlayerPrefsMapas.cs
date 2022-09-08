using UnityEngine;

public class PlayerPrefsMapas 
{    
    private static readonly string LEVEL_LIBERADO = "level-liberado";
    private static readonly string MAPA_NAVEGACAO = "mapa-naveg";
    private static readonly string NEW_LEVEL_BTN_BALAO = "new-level-balao";

    private static int DESLIGADO = 0;
    private static int LIGADO = 1;

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
        //Debug.Log("Recuperando indice level " + indice);
        return indice;
    }

    public static void salvarIndiceLevelLiberado(int indiceLevel)
    {
        int indiceAtual = getIndiceLevelLiberado();
        if(indiceLevel > indiceAtual)
        {
            //Debug.Log("Salvando indice level " + indiceLevel);
            PlayerPrefs.SetInt(NEW_LEVEL_BTN_BALAO, LIGADO);
            PlayerPrefs.SetInt(LEVEL_LIBERADO, indiceLevel);
        }
    }

    public static void salvarIndiceNavegacaoMapa(MapaEntidade mapaEntidade)
    {
        PlayerPrefs.SetInt(MAPA_NAVEGACAO, mapaEntidade.id);        
    }

    public static bool isNovaLiberacaoLevelBalao()
    {
        int result = PlayerPrefs.GetInt(NEW_LEVEL_BTN_BALAO);
        return result == LIGADO;
    }

    public static void consumidoNovaLiberacaoLevelBalao()
    {
        PlayerPrefs.SetInt(NEW_LEVEL_BTN_BALAO, DESLIGADO);
    }
}
