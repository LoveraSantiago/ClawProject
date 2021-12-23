using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryPupMola : AbstractFactoryPup
{
    public override PowerUpEntidade factoryPupEntidade()
    {
        return null;
    }

    public override AbstractPowerUpGo fornecer()
    {
        return new MolaPowerUpGo();
    }
}
