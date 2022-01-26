using System;

public class ContadorTimerContinuo : ContadorDeTempoFrameNegativo
{
    private string tempoRestart;
    private Executor executorAntes;

    public ContadorTimerContinuo(string tempo, Executor executorAntes)
        : base(tempo)
    {
        tempoRestart = tempo;
        this.executorAntes = executorAntes;
    }

    public override bool isTimeOver()
    {
        return false;
    }

    public override TimeSpan processarContagem()
    {
        TimeSpan timeSpan = base.processarContagem();

        if (base.isTimeOver())
        {
            iniciarContagem();
            setTempoRegressivoInicial(tempoRestart);
            executorAntes.execute();
        }

        return timeSpan;
    }
}
