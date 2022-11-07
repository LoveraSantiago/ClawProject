using UnityEngine;

public class MaterialBackground 
{
    private static readonly int ID_TEMPO_SUBTRAIR = Shader.PropertyToID("_tempoSubtracao");
    private static readonly int ID_SUBIDA         = Shader.PropertyToID("_subida");

    public static void movimentarEntrada(Material material)
    {
        material.SetFloat(ID_TEMPO_SUBTRAIR, Time.time);
        material.SetFloat(ID_SUBIDA, 1);
    }

    public static void movimentarSaida(Material material)
    {
        material.SetFloat(ID_TEMPO_SUBTRAIR, Time.time);
        material.SetFloat(ID_SUBIDA, 0);
    }
}
