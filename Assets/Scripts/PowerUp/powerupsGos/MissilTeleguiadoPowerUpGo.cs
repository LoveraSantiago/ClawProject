using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilTeleguiadoPowerUpGo : AbstractPowerUpGo
{
    public MissilTeleguiadoPowerUpGo(GameObject tileMissil) : 
        base(tileMissil, "missil-teleguiado")
    {
    }

    public override PowerUpEntidade.INTERACAOGARRA getInteracaoComGarra()
    {
        return PowerUpEntidade.INTERACAOGARRA.PARADO;
    }

    public override float getAnguloGarraSegurar()
    {
        return 16f;
    }

    public override void colocarNaPosicao(Vector3 posicao)
    {
        base.colocarNaPosicao(posicao + new Vector3(0, -0.4f, 0));
    }
}
