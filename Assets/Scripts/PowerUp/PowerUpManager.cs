public class PowerUpManager : PowerUpAcionamento
{
    private PowerUp powerUpBomba;
    private PowerUpParaMaquina powerUpParaMaquinaBomba;

    public PowerUpManager()
    {
        powerUpBomba = new PowerUp(PowerUp.TIPO.BOMBA_DA_GARRA, 5);

        PowerUpParaMaquina.configAcionadorDePowerUp(this);
        powerUpParaMaquinaBomba = new PowerUpParaMaquina(powerUpBomba, true);
    }

    public PowerUpParaMaquina distribuirPowerUpParaMaquina()
    {
        return powerUpParaMaquinaBomba;
    }

    public void acionado(PowerUp.TIPO tipoPowerUp)
    {    
    }

    
}
