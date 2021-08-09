public class AntesExecutorTimerRestart : Executor
{
    private BotoesPowerUp botoesPowerUp;
    private DisplayTimer displayTimer;
    private ArcoIrisEfeito arcoIrisEfeito;

    public AntesExecutorTimerRestart(
        BotoesPowerUp botoesPowerUp, DisplayTimer displayTimer, ArcoIrisEfeito arcoIrisEfeito)
    {
        this.botoesPowerUp = botoesPowerUp;
        this.displayTimer = displayTimer;
        this.arcoIrisEfeito = arcoIrisEfeito;
    }

    public void execute()
    {
        botoesPowerUp.desativarPowerUp();
        displayTimer.pause();
        arcoIrisEfeito.ligarBlinkRed();
    }
}
