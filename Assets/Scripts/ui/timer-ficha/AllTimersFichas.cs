using System;

public class AllTimersFichas 
{
    private TimerFicha timerFichaOuro;
    private TimerFicha timerFichaPrata;
    private TimerFicha timerFichaBronze;  

    public AllTimersFichas(TimerFichaDto[] timerFichaDto, SomTimerFicha somTimerFicha)
    {
        timerFichaOuro   = new TimerFicha(timerFichaDto[0], somTimerFicha, Ficha.OURO);
        timerFichaPrata  = new TimerFicha(timerFichaDto[1], somTimerFicha, Ficha.PRATA);
        timerFichaBronze = new TimerFicha(timerFichaDto[2], somTimerFicha, Ficha.BRONZE);
    }

    public void update()
    {
        timerFichaOuro.update();
        timerFichaPrata.update();
        timerFichaBronze.update();
    }

    public bool ganharFichasDeOuro(int qtdFichas)
    {
        return timerFichaOuro.ganharFichas(qtdFichas);
    }
    
    public bool ganharFichasDePrata(int qtdFichas)
    {
        return timerFichaPrata.ganharFichas(qtdFichas);
    }
    
    public bool ganharFichasDeBronze(int qtdFichas)
    {
        return timerFichaBronze.ganharFichas(qtdFichas);
    }
}
