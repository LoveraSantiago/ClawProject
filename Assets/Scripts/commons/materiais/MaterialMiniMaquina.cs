using UnityEngine;
using System.Collections.Generic;

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

    public static void addCores(Material material, Dictionary<string, string> cores)
    {
        material.SetColor("_corExterno", Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.PLACA_FRENTE]));
        material.SetColor("_corFundo", Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.BASE_CHAO]));
        material.SetColor("_corJoystick", Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.JOYSTICK_MESA_CIMA]));
    }
}
