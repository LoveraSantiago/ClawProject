using System;

public class ContadorTimerContinuo : ContadorTimerNegativo
{
    private string tempoRestart;
    private ProdutorDeEvento<TempoEsgotado> produtorDeEventoTempoEsgotado;

    public ContadorTimerContinuo(string tempo, ProdutorDeEvento<TempoEsgotado> produtorDeEventoTempoEsgotado)
        : base(tempo)
    {
        tempoRestart = tempo;
        this.produtorDeEventoTempoEsgotado = produtorDeEventoTempoEsgotado;
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
            produtorDeEventoTempoEsgotado.produziuEvento(new TempoEsgotado(true));
            iniciarContagem();
            setTempoRegressivoInicial(tempoRestart);
        }

        return timeSpan;
    }
}
