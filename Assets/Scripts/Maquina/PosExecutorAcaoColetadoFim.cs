using UnityEngine;

public class PosExecutorAcaoColetadoFim : Executor
{
    private DisplayTimer displayTimer;
    private BotoesPowerUp botoesPowerUp;

    public PosExecutorAcaoColetadoFim(DisplayTimer displayTimer, BotoesPowerUp botoesPowerUp)
    {
        this.displayTimer = displayTimer;
        this.botoesPowerUp = botoesPowerUp;
    }

    public void execute()
    {
        Debug.Log("Pos Execucao chamado");
        displayTimer.continuar();
        botoesPowerUp.reativarPowerUpPosDisplay();
    }
}
