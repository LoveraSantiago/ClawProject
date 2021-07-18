using System;

public class ContadorTimerContinuo : ContadorTimerNegativo
{
    private string tempoRestart;

    public ContadorTimerContinuo(string tempo)
        : base(tempo)
    {
        tempoRestart = tempo;
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
        }

        return timeSpan;
    }
}
