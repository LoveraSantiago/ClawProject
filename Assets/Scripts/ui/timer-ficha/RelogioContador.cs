using System;

public class RelogioContador : Relogio
{
    private TimeSpan tempoLblHoras;
    private IntervaloDeTempo intervaloDeTempo;
    private ContadorDeTempo contadorDeTempo;

    public RelogioContador(DateTime dataFicha, FichaEntidade fichaEntidade)
    {
        intervaloDeTempo = new IntervaloDeTempo(1.0f);
        contadorDeTempo  = new ContadorDeTempoData(dataFicha);
        tempoLblHoras = new TimeSpan(fichaEntidade.intervaloHoras, fichaEntidade.intervaloMinutos, 0);
    }

    public override void updateSegundo(RelogioDto relogioDto)
    {
        bool contou1Segundo = intervaloDeTempo.contarTempoDT();
        if (contou1Segundo)
        {
            TimeSpan timeSpan = contadorDeTempo.processarContagem();

            Ponteiros ponteiros = new Ponteiros();
            ponteiros.andarPonteiros(timeSpan, relogioDto);

            intervaloDeTempo.resetContador();

            TimeSpan diferenca = tempoLblHoras - timeSpan;
            relogioDto.LblHoras.SetText(diferenca.Hours + "h" + diferenca.Minutes + "m");
        }
    }
}
