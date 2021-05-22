using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilTeleguiadoPowerUpGo : AbstractPowerUpGo
{
    public MissilTeleguiadoPowerUpGo(GameObject goTile, string nome) : 
        base(goTile, nome)
    {
    }

    public override bool garraPodeSegurar()
    {
        return true;
    }
}
