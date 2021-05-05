using UnityEngine;
using System.Collections.Generic;

public class PowerUpManager : PowerUpAcionamento,
                              PowerUpFinalizacao
{
    private PowerUpDto powerUpDto;
    private PoolGenerico<GarraInteracaoComPowerUp> poolDePowerUpsDaGarra;
    private MonoBehaviour monoBehaviour;

    public ProdutorDeEvento<PowerUpInfo> produtorDeEventoPowerUp { get; private set; }
    public ProdutorDeEvento<PowerUpInfoFim> produtorDeEventoFinalizacao { get; private set; }

    public PowerUpManager(PowerUpDto powerUpDto, MonoBehaviour monoBehaviour)
    {
        this.powerUpDto = powerUpDto;
        this.monoBehaviour = monoBehaviour;

        PowerUpParaMaquina.configAcionadorDePowerUp(this);
        produtorDeEventoPowerUp = new ProdutorDeEvento<PowerUpInfo>();
        produtorDeEventoFinalizacao = new ProdutorDeEvento<PowerUpInfoFim>();

        poolDePowerUpsDaGarra = new PoolGenerico<GarraInteracaoComPowerUp>();
    }    

    public void acionado(PowerUp powerUp)
    {    
        PowerUpInfo powerUpInfo = new PowerUpInfo();
        powerUpInfo.configurarDuracaoTempo(powerUp.duracao);

        if(powerUp.name == PowerUp.NAME.BOMBA_DA_GARRA)
        {
            powerUpInfo.configurarObjetoInteracaoComGarra(getPowerUpBomba());
        }
        else if(powerUp.name == PowerUp.NAME.MISSIL_DA_GARRA)
        {
            powerUpInfo.configurarObjetoInteracaoComGarra(getPowerUpMissil());
        }

        produtorDeEventoPowerUp.produziuEvento(powerUpInfo);
    }

    public void finalizado()
    {
        PowerUpInfoFim powerUpInfoFim = new PowerUpInfoFim(false, true);
        produtorDeEventoFinalizacao.produziuEvento(powerUpInfoFim);
    }

    public void preFinalizar()
    {
        PowerUpInfoFim powerUpInfoFim = new PowerUpInfoFim(true, false);
        produtorDeEventoFinalizacao.produziuEvento(powerUpInfoFim);
    }

    private GarraInteracaoComPowerUp getPowerUpBomba()
    {
        if (!poolDePowerUpsDaGarra.contemNome(PowerUpBomba.STATIC_NOME))
        {
            PowerUpBomba bomba = new PowerUpBomba(powerUpDto.TileBomb, this, monoBehaviour);
            poolDePowerUpsDaGarra.addObjetoAoDicionario(bomba.nome, bomba);            
        }
        return poolDePowerUpsDaGarra.getObjetoPeloNome(PowerUpBomba.STATIC_NOME);
    }

    private GarraInteracaoComPowerUp getPowerUpMissil()
    {
        if (!poolDePowerUpsDaGarra.contemNome(PowerUpMissil.STATIC_NOME))
        {
            PowerUpMissil missil = new PowerUpMissil(powerUpDto.TileMissil, this, monoBehaviour);
            poolDePowerUpsDaGarra.addObjetoAoDicionario(missil.nome, missil);
        }
        return poolDePowerUpsDaGarra.getObjetoPeloNome(PowerUpMissil.STATIC_NOME);
    }
}
