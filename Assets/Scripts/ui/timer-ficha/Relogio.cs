using System;

public class Relogio 
{
    private TimeSpan tempoLblHoras;    
    private IntervaloDeTempo intervaloDeTempo;
    private ContadorDeTempo contadorDeTempo;    

    public Relogio()
    {   
        intervaloDeTempo = new IntervaloDeTempo(1.0f);
        contadorDeTempo = new ContadorDeTempoData();
        contadorDeTempo.iniciarContagem();
        
        tempoLblHoras = new TimeSpan(1, 30, 0);
    }

    public void updateSegundo(RelogioDto relogioDto)
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
    
    public void zerarPonteiros(RelogioDto relogioDto)
    {
        relogioDto.LblHoras.SetText("cheio");
        Ponteiros ponteiros = new Ponteiros();
        ponteiros.zerarPonteiros(relogioDto);
    }    
}
