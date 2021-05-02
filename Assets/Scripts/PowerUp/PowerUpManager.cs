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

    public PowerUpParaMaquina distribuirPowerUpParaMaquina()
    {
        PowerUp  powerUpBomba = new PowerUp(PowerUp.TIPO.BOMBA_DA_GARRA, 5);
        PowerUpParaMaquina powerUpParaMaquinaBomba = new PowerUpParaMaquina(powerUpBomba, powerUpDto.SpriteBomb, true);
        return powerUpParaMaquinaBomba;
    }

    public void acionado(PowerUp.TIPO tipoPowerUp)
    {    
        if(tipoPowerUp == PowerUp.TIPO.BOMBA_DA_GARRA)
        {
            PowerUpInfo powerUpInfo = new PowerUpInfo();
            powerUpInfo.configurarDuracaoTempo(9);
            powerUpInfo.configurarObjetoInteracaoComGarra(new PowerUpBomba(powerUpDto.TileBomb, this, monoBehaviour));
            produtorDeEventoPowerUp.produziuEvento(powerUpInfo);
        }
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
