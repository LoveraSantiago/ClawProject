using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinaTerrestrePowerUpGo : AbstractPowerUpGo
{
    

    public MinaTerrestrePowerUpGo(GameObject tileMinaTerrestre)
        :base(tileMinaTerrestre, "mina-terrestre")
    {

    }

    public override bool garraPodeSegurar()
    {
        return false;
    }

    public override void ligar()
    {

    }

    public override void parar() { }
    public override void colocarNaPosicao(Vector3 posicao) { }
    public override void desligarGravidade() { }
    public override void ligarGravidade() { }
    public override void fixarVerticalmente() { }

}
