public class PowerUpParaMaquina : AcaoBotaoPowerUp
{
    private static PowerUpAcionamento powerUpAcionamento;

    private bool clicavel;
    private PowerUp powerUp;

    public PowerUpParaMaquina(PowerUp powerUp, bool clicavel)
    {
        this.powerUp = powerUp;
        this.clicavel = clicavel;
    }

    public void acionar()
    {
        powerUpAcionamento.acionado(powerUp.tipo);
    }

    public bool isClicavel()
    {
        return clicavel;
    }

    public bool isDraggavel()
    {
        return !isClicavel();
    }

    public static void configAcionadorDePowerUp(PowerUpAcionamento powerUpAcionamentoArg)
    {
        powerUpAcionamento = powerUpAcionamentoArg;
    }
}
