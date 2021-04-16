public class PowerUpManager : PowerUpAcionamento
{   

    public ProdutorDeEvento<PowerUpInfo> produtorDeEventoPowerUp { get; private set; }

    public PowerUpManager()
    {
        PowerUpParaMaquina.configAcionadorDePowerUp(this);
        produtorDeEventoPowerUp = new ProdutorDeEvento<PowerUpInfo>();
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

            produtorDeEventoPowerUp.produziuEvento(powerUpInfo);
        }
    }    
}
