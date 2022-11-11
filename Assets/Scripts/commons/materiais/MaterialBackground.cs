using UnityEngine;

public class MaterialBackground 
{
    private static readonly int ID_TEMPO_SUBTRAIR = Shader.PropertyToID("_tempoSubtracao");
    private static readonly int ID_SUBIDA         = Shader.PropertyToID("_subida");
    private static readonly int ID_COR_BACKGROUND = Shader.PropertyToID("_cor_background");
    private static readonly int ID_COR_CONTORNO   = Shader.PropertyToID("_cor_contorno");
    private static readonly int ID_COR_1          = Shader.PropertyToID("_cor_g1");
    private static readonly int ID_COR_2          = Shader.PropertyToID("_cor_g2");
    private static readonly int ID_COR_3          = Shader.PropertyToID("_cor_g3");
    private static readonly int ID_COR_4          = Shader.PropertyToID("_cor_g4");
    private static readonly int ID_CLAREAMENTO    = Shader.PropertyToID("_valor_clareamento");

    public static void movimentarEntrada(Material material)
    {
        material.SetFloat(ID_TEMPO_SUBTRAIR, Time.time);
        material.SetFloat(ID_SUBIDA, 1);
    }

    public static void movimentarSaida(Material material, LevelCorBackgroundDto levelCorBackgrounds)
    {
        material.SetFloat(ID_TEMPO_SUBTRAIR, Time.time);
        material.SetFloat(ID_SUBIDA, 0);

        material.SetColor(ID_COR_BACKGROUND, levelCorBackgrounds.CorBackground);
        material.SetColor(ID_COR_CONTORNO  , levelCorBackgrounds.CorContorno);
        material.SetColor(ID_COR_1         , levelCorBackgrounds.Cor1);
        material.SetColor(ID_COR_2         , levelCorBackgrounds.Cor2);
        material.SetColor(ID_COR_3         , levelCorBackgrounds.Cor3);
        material.SetColor(ID_COR_4         , levelCorBackgrounds.Cor4);
        material.SetFloat(ID_CLAREAMENTO   , levelCorBackgrounds.Clareamento);
    }
}
