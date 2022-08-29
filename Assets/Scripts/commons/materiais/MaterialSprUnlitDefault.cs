using UnityEngine;


public class MaterialSprUnlitDefault
{
    private static Material matSprUnlitDefault;

    public static void configurar(Material matSprUnlitDefaultArg)
    {
        matSprUnlitDefault = matSprUnlitDefaultArg;
    }

    public static Material getMaterial()
    {
        return matSprUnlitDefault;
        //return new Material(matSprUnlitDefault);
    }   
}
