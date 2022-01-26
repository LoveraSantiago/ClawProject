using System;

public class ContadorTimerContinuo : ContadorDeTempoFrameNegativo
{
    private string tempoRestart;
    private ProdutorDeEvento<TempoEsgotado> produtorDeEventoTempoEsgotado;

    private Executor executorAntes;

    public ContadorTimerContinuo(
        string tempo, ProdutorDeEvento<TempoEsgotado> produtorDeEventoTempoEsgotado, Executor executorAntes)
        : base(tempo)
    {
        tempoRestart = tempo;
        this.produtorDeEventoTempoEsgotado = produtorDeEventoTempoEsgotado;
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
            produtorDeEventoTempoEsgotado.produziuEvento(new TempoEsgotado(true));
        }

        return timeSpan;
    }
}
