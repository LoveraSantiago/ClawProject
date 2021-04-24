using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : AbstractLevel
{
    public override GarraManager.MECANICA_GARRA getMecanicaDaGarra()
    {
        return GarraManager.MECANICA_GARRA.ZIG_ZAG;
    }
}
