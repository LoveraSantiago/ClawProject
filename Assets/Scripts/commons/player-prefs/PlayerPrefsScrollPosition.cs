using UnityEngine;

public class PlayerPrefsScrollPosition 
{
    private static readonly string SCROLL_RECT_COLETAVEIS = "scRectColetaveisPos";

    public static void salvarPosScrollRectColetaveis(float posicao)
    {
        PlayerPrefs.SetFloat(SCROLL_RECT_COLETAVEIS, posicao);
    }

    public static float recuperarELimparPosScrollRectColetaveis()
    {
        float posicao = PlayerPrefs.GetFloat(SCROLL_RECT_COLETAVEIS);
        PlayerPrefs.DeleteKey(SCROLL_RECT_COLETAVEIS);
        return posicao;
    }
}
