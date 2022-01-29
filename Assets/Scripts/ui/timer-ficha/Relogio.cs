using System;

public abstract class Relogio 
{
    protected TimeSpan tempoLblHoras;
    protected IntervaloDeTempo intervaloDeTempo;
    protected ContadorDeTempo contadorDeTempo;    

    public Relogio()
    {   
        intervaloDeTempo = new IntervaloDeTempo(1.0f);
        contadorDeTempo = new ContadorDeTempoData();
        contadorDeTempo.iniciarContagem();
        
        tempoLblHoras = new TimeSpan(1, 30, 0);
    }

    public abstract void updateSegundo(RelogioDto relogioDto);    
    
    public void zerarPonteiros(RelogioDto relogioDto)
    {
        relogioDto.LblHoras.SetText("cheio");
        Ponteiros ponteiros = new Ponteiros();
        ponteiros.zerarPonteiros(relogioDto);
    }    
}
