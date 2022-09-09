using UnityEngine;

public class PlayerPrefsMapas 
{    
    private static readonly string LEVEL_LIBERADO      = "level-liberado";
    private static readonly string MAPA_NAVEGACAO      = "mapa-naveg";
    private static readonly string NEW_LEVEL_BTN_BALAO = "new-level-balao";
    private static readonly string NEW_LEVEL_LEVEL     = "new-level-level";
    private static readonly string NEW_MAPA            = "new-mapa-naveg";

    private static int DESLIGADO = 0;
    private static int LIGADO = 1;

    public static int getIndiceMapaLiberado()//TODO ADICIONAR CRIPTOGRAFIA SEGURANCA
    {
        int indiceLevelLiberado = getIndiceLevelLiberado();
        int resultado = (indiceLevelLiberado + 9) / 10;
        //Debug.Log("Resultado indice mapa liberado " + resultado);
        return resultado;
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
            PlayerPrefs.SetInt(NEW_LEVEL_LEVEL, LIGADO);
            PlayerPrefs.SetInt(LEVEL_LIBERADO, indiceLevel);

            if(indiceLevel % 10 == 1 && indiceLevel > 10)
            {
                PlayerPrefs.SetInt(NEW_MAPA, LIGADO);
            }
        }
    }

    public static void salvarIndiceNavegacaoMapa(MapaEntidade mapaEntidade)
    {
        PlayerPrefs.SetInt(MAPA_NAVEGACAO, mapaEntidade.id);        
    }

    public static bool isNovaLiberacaoLevelBalao()
    {
        int result = PlayerPrefs.GetInt(NEW_LEVEL_BTN_BALAO, LIGADO);
        return result == LIGADO;
    }

    public static void consumidoNovaLiberacaoLevelBalao()
    {
        PlayerPrefs.SetInt(NEW_LEVEL_BTN_BALAO, DESLIGADO);
    }

    public static bool isNovaLiberacaoMapa()
    {
        int result = PlayerPrefs.GetInt(NEW_MAPA);
        return result == LIGADO;
    }

    public static void consumidoNovaLiberacaoMapa()
    {
        PlayerPrefs.SetInt(NEW_MAPA, DESLIGADO);
    }

    public static bool isNovaLiberacaoLevel()
    {
        int result = PlayerPrefs.GetInt(NEW_LEVEL_LEVEL, LIGADO);
        return result == LIGADO; 
    }

    public static void consumidoNovaLiberacaoLevel()
    {
        PlayerPrefs.SetInt(NEW_LEVEL_LEVEL, DESLIGADO);
    }
}
