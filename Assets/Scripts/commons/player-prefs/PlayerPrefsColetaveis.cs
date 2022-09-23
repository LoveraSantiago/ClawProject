using UnityEngine;

public class PlayerPrefsColetaveis 
{   
    private const string TAG_NAVEGACAO_COLETAVEL = "IndiceColetavel";    

    public static void salvarNavegacaoColetavel(int idColetavel)
    {
        PlayerPrefs.SetInt(TAG_NAVEGACAO_COLETAVEL, idColetavel);
    }

    public static int recuperarNavegacaoColetavel()
    {
        int id = PlayerPrefs.GetInt(TAG_NAVEGACAO_COLETAVEL, -1);
        return id;
    }

    public static int recuperarEApagarNavegacaoColetavel()
    {
        int id = recuperarNavegacaoColetavel();
        PlayerPrefs.DeleteKey(TAG_NAVEGACAO_COLETAVEL);
        return id;
    }
}
