using System;

public class RelogioContador : Relogio
{
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
