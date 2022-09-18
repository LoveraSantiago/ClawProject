using UnityEngine;

public class PlayerPrefsScrollPosition 
{
    private static readonly string SCROLL_RECT_ARMARIO            = "scrollRectArmario";
    private static readonly string SCROLL_RECT_ARMARIO_PRATELEIRA = "scrollRectArmarioPrateleira";
    private static readonly string SCROLL_RECT_ARMARIO_ITEM       = "scrollRectArmarioItem";

    public static void salvarPosScrollRectArmario(IndiceArmarioSelecionadoDto indiceArmarioSelecionado)
    {
        salvarPosScrollRectArmario(indiceArmarioSelecionado.posScrollArmario, indiceArmarioSelecionado.indicePrateleira, indiceArmarioSelecionado.indiceItem);
    }

    public static void salvarPosScrollRectArmario(float posicao, int indicePrateleira, int indiceItem)
    {
        PlayerPrefs.SetFloat(SCROLL_RECT_ARMARIO, posicao);
        PlayerPrefs.SetInt  (SCROLL_RECT_ARMARIO_PRATELEIRA, indicePrateleira);
        PlayerPrefs.SetInt  (SCROLL_RECT_ARMARIO_ITEM, indiceItem);
    }

    public static IndiceArmarioSelecionadoDto recuperarELimparPosScrollRectColetaveis()
    {
        float posicao        = PlayerPrefs.GetFloat(SCROLL_RECT_ARMARIO);
        int indicePrateleira = PlayerPrefs.GetInt(SCROLL_RECT_ARMARIO_PRATELEIRA);
        int indiceItem       = PlayerPrefs.GetInt(SCROLL_RECT_ARMARIO_ITEM);

        PlayerPrefs.DeleteKey(SCROLL_RECT_ARMARIO);
        PlayerPrefs.DeleteKey(SCROLL_RECT_ARMARIO_PRATELEIRA);
        PlayerPrefs.DeleteKey(SCROLL_RECT_ARMARIO_ITEM);
        return new IndiceArmarioSelecionadoDto(indicePrateleira, indiceItem, posicao);
    }
}
