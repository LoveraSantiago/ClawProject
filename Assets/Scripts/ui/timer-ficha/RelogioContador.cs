using System;

public class RelogioContador : Relogio
{   
    private IntervaloDeTempo intervaloDeTempo;
    private ContadorDeTempo contadorDeTempo;

    private Executor executorAoFinalizar;

    public RelogioContador(DateTime dataFicha, FichaEntidade fichaEntidade, Executor executorAoFinalizar)
    {
        intervaloDeTempo = new IntervaloDeTempo(1.0f);
        contadorDeTempo  = new ContadorDeTempoData(dataFicha);
        tempoLblHoras    = new TimeSpan(fichaEntidade.intervaloHoras, fichaEntidade.intervaloMinutos, 0);

        this.executorAoFinalizar = executorAoFinalizar;
    }

    public override void updateSegundo(RelogioDto relogioDto)
    {
        bool contou1Segundo = intervaloDeTempo.contarTempo();
        if (contou1Segundo)
        {
            TimeSpan timeSpan = contadorDeTempo.processarContagem();

            Ponteiros ponteiros = new Ponteiros();
            ponteiros.andarPonteiros(timeSpan, relogioDto);

            intervaloDeTempo.resetContador();

            TimeSpan diferenca = tempoLblHoras - timeSpan;
            relogioDto.LblHoras.SetText(diferenca.Hours + "h" + diferenca.Minutes + "m");

            if (isTempoZerado(diferenca))
            {
                executorAoFinalizar.execute();
            }
        }
    }

    private bool isTempoZerado(TimeSpan tempo)
    {
        return tempo.Hours == 0 && tempo.Minutes == 0;
    }
}
