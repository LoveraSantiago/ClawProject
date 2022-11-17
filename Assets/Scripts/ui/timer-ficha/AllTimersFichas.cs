using System;

public class AllTimersFichas 
{
    private TimerFicha timerFichaOuro;
    private TimerFicha timerFichaPrata;
    private TimerFicha timerFichaBronze;  

    public AllTimersFichas(TimerFichaDto[] timerFichaDto, Loading loading)
    {
        timerFichaOuro   = new TimerFicha(timerFichaDto[0], loading, Ficha.OURO);
        timerFichaPrata  = new TimerFicha(timerFichaDto[1], loading, Ficha.PRATA);
        timerFichaBronze = new TimerFicha(timerFichaDto[2], loading, Ficha.BRONZE);
    }

    public void update()
    {
        timerFichaOuro.update();
        timerFichaPrata.update();
        timerFichaBronze.update();
    }
}
