using System;

public class ContadorTimerContinuo : ContadorTimerNegativo
{
    private string tempoRestart;
    public ProdutorDeEvento<bool> innerProdutorDeEventoTempoRestart;

    public ContadorTimerContinuo(string tempo)
        : base(tempo)
    {
        tempoRestart = tempo;
        innerProdutorDeEventoTempoRestart = new ProdutorDeEvento<bool>();
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
            innerProdutorDeEventoTempoRestart.produziuEvento(true);
            iniciarContagem();
            setTempoRegressivoInicial(tempoRestart);
        }

        return timeSpan;
    }
}
