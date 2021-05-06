using UnityEngine;

public class PoolDePowerUpGos 
{
    private PowerUpDto powerUpDto;
    private MonoBehaviour monoBehaviour;

    private PoolGenerico<GarraInteracaoComPowerUp> poolDePowerUpsDaGarra;

    private PowerUpFinalizacao powerupFinalizacao;

    public PoolDePowerUpGos(PowerUpDto powerUpDto, PowerUpFinalizacao powerupFinalizacao, MonoBehaviour monoBehaviour)
    {
        this.powerUpDto = powerUpDto;
        this.powerupFinalizacao = powerupFinalizacao;
        this.monoBehaviour = monoBehaviour;

        poolDePowerUpsDaGarra = new PoolGenerico<GarraInteracaoComPowerUp>();
    }

    public GarraInteracaoComPowerUp getPowerUpGo(PowerUpEntidade.NAME powerUpName)
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
                
        }
    }
    private void criarPowerUpGoBomba()
    {
        BombaPowerUpGo bomba = new BombaPowerUpGo(powerUpDto.TileBomb, powerupFinalizacao, monoBehaviour);
        poolDePowerUpsDaGarra.addObjetoAoDicionario(PowerUpEntidade.NAME.BOMBA_DA_GARRA.ToString(), bomba);        
    }

    private void criarPowerUpGoMissil()
    {        
        MissilPowerUpGo missil = new MissilPowerUpGo(powerUpDto.TileMissil, powerupFinalizacao, monoBehaviour);
        poolDePowerUpsDaGarra.addObjetoAoDicionario(PowerUpEntidade.NAME.MISSIL_DA_GARRA.ToString(), missil);        
    }
    

}
