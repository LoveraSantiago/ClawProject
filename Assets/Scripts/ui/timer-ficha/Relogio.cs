using System;

public abstract class Relogio 
{
    protected TimeSpan tempoLblHoras;    

    public abstract void updateSegundo(RelogioDto relogioDto);    
    
    public void zerarPonteiros(RelogioDto relogioDto)
    {
        relogioDto.LblHoras.SetText("cheio");
        Ponteiros ponteiros = new Ponteiros();
        ponteiros.zerarPonteiros(relogioDto);
    }    
}
