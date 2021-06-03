using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportePowerUpGo : AbstractPowerUpGo
{
    public TeleportePowerUpGo(GameObject goTile) 
        : base(goTile, "teleporte")
    {
    }

    public override PowerUpEntidade.INTERACAOGARRA getInteracaoComGarra()
    {
        return PowerUpEntidade.INTERACAOGARRA.NAO_INTERACAO;
    }
}
