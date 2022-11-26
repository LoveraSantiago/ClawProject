using System;

public class AllTimersFichas 
{
    private TimerFicha timerFichaOuro;
    private TimerFicha timerFichaPrata;
    private TimerFicha timerFichaBronze;  

    public AllTimersFichas(TimerFichaDto[] timerFichaDto, SomMap somMap)
    {
        timerFichaOuro   = new TimerFicha(timerFichaDto[0], somMap, Ficha.OURO);
        timerFichaPrata  = new TimerFicha(timerFichaDto[1], somMap, Ficha.PRATA);
        timerFichaBronze = new TimerFicha(timerFichaDto[2], somMap, Ficha.BRONZE);
    }

    public void update()
    {
        timerFichaOuro.update();
        timerFichaPrata.update();
        timerFichaBronze.update();
    }
}
