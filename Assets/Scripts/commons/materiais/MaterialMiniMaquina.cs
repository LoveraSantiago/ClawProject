using UnityEngine;

public class MaterialMiniMaquina 
{
    private static Material matMiniMaquina;

    public static void configurar(Material matSprMininiMaquina)
    {
        matMiniMaquina = matSprMininiMaquina;
    }

    public static Material getNewMaterial()
    {
        return new Material(matMiniMaquina);
    }
}
