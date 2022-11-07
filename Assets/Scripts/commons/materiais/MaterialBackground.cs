using UnityEngine;

public class MaterialBackground 
{
    private static readonly int ID_TEMPO_SUBTRAIR = Shader.PropertyToID("_tempoSubtracao");

    public static void movimentarEntrada(Material material)
    {
        material.SetFloat(ID_TEMPO_SUBTRAIR, Time.time);
    }
}
