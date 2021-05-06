using System;
using UnityEngine;

public class PoolDePowerUpGos 
{
    private PowerUpDto powerUpDto;
    private PoolGenerico<AbstractPowerUpGo> poolDePowerUpsDaGarra;

    private PowerUpFinalizacao powerupFinalizacao;

    public PoolDePowerUpGos(PowerUpDto powerUpDto)
    {
        this.powerUpDto = powerUpDto;
        poolDePowerUpsDaGarra = new PoolGenerico<AbstractPowerUpGo>();
    }

    public AbstractPowerUpGo getPowerUpGo(PowerUpEntidade.NAME powerUpName)
    {
        if (!poolDePowerUpsDaGarra.contemNome(powerUpName.ToString()))
        {
            criarPowerUpGo(powerUpName);
        }
        return poolDePowerUpsDaGarra.getObjetoPeloNome(powerUpName.ToString());
    }

    private void criarPowerUpGo(PowerUpEntidade.NAME powerUpName)
    {
        switch (powerUpName)
        {
            case PowerUpEntidade.NAME.BOMBA_DA_GARRA:                
                criarPowerUpGoBomba();
                break;

            case PowerUpEntidade.NAME.MISSIL_DA_GARRA:
                criarPowerUpGoMissil();
                break;

            case PowerUpEntidade.NAME.MINA_TERRESTRE:
                criarPowerUpGoMinaTerrestre();
                break;               
        }
    }

    private void criarPowerUpGoMinaTerrestre()
    {
        MinaTerrestrePowerUpGo mina = new MinaTerrestrePowerUpGo(powerUpDto.TileMinaTerrestre);
        poolDePowerUpsDaGarra.addObjetoAoDicionario(PowerUpEntidade.NAME.MINA_TERRESTRE.ToString(), mina);
    }

    private void criarPowerUpGoBomba()
    {
        BombaPowerUpGo bomba = new BombaPowerUpGo(powerUpDto.TileBomb);
        poolDePowerUpsDaGarra.addObjetoAoDicionario(PowerUpEntidade.NAME.BOMBA_DA_GARRA.ToString(), bomba);        
    }

    private void criarPowerUpGoMissil()
    {        
        MissilPowerUpGo missil = new MissilPowerUpGo(powerUpDto.TileMissil);
        poolDePowerUpsDaGarra.addObjetoAoDicionario(PowerUpEntidade.NAME.MISSIL_DA_GARRA.ToString(), missil);        
    }
}
