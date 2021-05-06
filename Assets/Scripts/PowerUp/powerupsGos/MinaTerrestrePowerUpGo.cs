using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinaTerrestrePowerUpGo : Coletavel,
                                     GarraInteracaoComPowerUp
{

    private static MonoBehaviour monoBehaviour;
    private static PowerUpFinalizacao powerUpFinalizacao;

    public MinaTerrestrePowerUpGo(GameObject tileMissil, PowerUpFinalizacao powerUpFinalizacaoArg, MonoBehaviour monoBehaviourArg)
    {

    }

    public bool garraPodeSegurar()
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
