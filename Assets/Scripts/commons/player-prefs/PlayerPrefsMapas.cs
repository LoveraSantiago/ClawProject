using UnityEngine;

public class PlayerPrefsMapas 
{
    private static readonly string MAPA_LIBERADO = "mapa-liberado";
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

    public static void salvarIndiceNavegacaoMapa(MapaEntidade mapaEntidade)
    {
        int indiceAtual = getIndiceMapaLiberado();
        if(mapaEntidade.id > indiceAtual)
        {
            PlayerPrefs.SetInt(MAPA_NAVEGACAO, mapaEntidade.id);
        }
    }
}
