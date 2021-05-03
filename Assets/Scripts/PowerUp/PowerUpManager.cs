using UnityEngine;

public class PowerUpManager : PowerUpAcionamento,
                              PowerUpFinalizacao
{
    private PowerUpDto powerUpDto;
    
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
    }    

    public void acionado(PowerUp powerUp)
    {    
        PowerUpInfo powerUpInfo = new PowerUpInfo();
        powerUpInfo.configurarDuracaoTempo(powerUp.duracao);

        if(powerUp.tipo == PowerUp.TIPO.BOMBA_DA_GARRA)
        {
            powerUpInfo.configurarObjetoInteracaoComGarra(new PowerUpBomba(powerUpDto.TileBomb, this, monoBehaviour));
        }
        else if(powerUp.tipo == PowerUp.TIPO.MISSIL_DA_GARRA)
        {
            powerUpInfo.configurarObjetoInteracaoComGarra(new PowerUpMissil(powerUpDto.TileMissil, this, monoBehaviour));
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
}
