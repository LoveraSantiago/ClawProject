using System;

public class AllTimersFichas 
{
    private TimerFicha timerFichaOuro;
    private TimerFicha timerFichaPrata;
    private TimerFicha timerFichaBronze;  

    public AllTimersFichas(TimerFichaDto[] timerFichaDto, Loading loading, SomMap somMap)
    {
        timerFichaOuro   = new TimerFicha(timerFichaDto[0], loading, somMap, Ficha.OURO);
        timerFichaPrata  = new TimerFicha(timerFichaDto[1], loading, somMap, Ficha.PRATA);
        timerFichaBronze = new TimerFicha(timerFichaDto[2], loading, somMap, Ficha.BRONZE);
    }

    public void update()
    {
        timerFichaOuro.update();
        timerFichaPrata.update();
        timerFichaBronze.update();
    }
}
