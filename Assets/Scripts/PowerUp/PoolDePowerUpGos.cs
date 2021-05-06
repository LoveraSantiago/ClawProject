using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolDePowerUpGos 
{
    private PoolGenerico<Coletavel> poolDePowerUpsDaGarra;

    private GarraInteracaoComPowerUp getPowerUpBomba()
    {
        if (!poolDePowerUpsDaGarra.contemNome(BombaPowerUpGo.STATIC_NOME))
        {
            BombaPowerUpGo bomba = new BombaPowerUpGo(powerUpDto.TileBomb, this, monoBehaviour);
            poolDePowerUpsDaGarra.addObjetoAoDicionario(bomba.nome, bomba);
        }
        return poolDePowerUpsDaGarra.getObjetoPeloNome(BombaPowerUpGo.STATIC_NOME);
    }

    private GarraInteracaoComPowerUp getPowerUpMissil()
    {
        if (!poolDePowerUpsDaGarra.contemNome(MissilPowerUpGo.STATIC_NOME))
        {
            MissilPowerUpGo missil = new MissilPowerUpGo(powerUpDto.TileMissil, this, monoBehaviour);
            poolDePowerUpsDaGarra.addObjetoAoDicionario(missil.nome, missil);
        }
        return poolDePowerUpsDaGarra.getObjetoPeloNome(MissilPowerUpGo.STATIC_NOME);
    }
}
