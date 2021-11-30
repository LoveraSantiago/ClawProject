using UnityEngine;

public class MaterialLed 
{
    private static Material materialLed;

    public static Material of()
    {
        return new Material(materialLed);
    }

    public static void configurar(Material materialLedArg)
    {
        materialLed = materialLedArg;
    }
}
