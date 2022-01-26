public class AntesExecutorTimerRestart : Executor
{
    private BotoesPowerUp botoesPowerUp;
    private ArcoIrisEfeito arcoIrisEfeito;

    public AntesExecutorTimerRestart(
        BotoesPowerUp botoesPowerUp, ArcoIrisEfeito arcoIrisEfeito)
    {
        this.botoesPowerUp = botoesPowerUp;
        this.arcoIrisEfeito = arcoIrisEfeito;
    }

    public void execute()
    {
        botoesPowerUp.desativarPowerUp();
        arcoIrisEfeito.ligarBlinkRed();
    }
}
