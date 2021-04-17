using UnityEngine;

public class PowerUpManager : PowerUpAcionamento
{
    private GameObject tileBomb;
    private MonoBehaviour monoBehaviour;
    public ProdutorDeEvento<PowerUpInfo> produtorDeEventoPowerUp { get; private set; }

    public PowerUpManager(GameObject tileBomb, MonoBehaviour monoBehaviour)
    {
        PowerUpParaMaquina.configAcionadorDePowerUp(this);
        produtorDeEventoPowerUp = new ProdutorDeEvento<PowerUpInfo>();
        this.tileBomb = tileBomb;
        this.monoBehaviour = monoBehaviour;
    }

    public PowerUpParaMaquina distribuirPowerUpParaMaquina()
    {
        PowerUp  powerUpBomba = new PowerUp(PowerUp.TIPO.BOMBA_DA_GARRA, 5);
        PowerUpParaMaquina powerUpParaMaquinaBomba = new PowerUpParaMaquina(powerUpBomba, true);
        return powerUpParaMaquinaBomba;
    }

    public void acionado(PowerUp.TIPO tipoPowerUp)
    {    
        if(tipoPowerUp == PowerUp.TIPO.BOMBA_DA_GARRA)
        {
            PowerUpInfo powerUpInfo = new PowerUpInfo();
            powerUpInfo.configurarDuracaoTempo(9);
            powerUpInfo.configurarObjetoInteracaoComGarra(new PowerUpBomba(tileBomb, monoBehaviour));

            produtorDeEventoPowerUp.produziuEvento(powerUpInfo);
        }
    }    
}
