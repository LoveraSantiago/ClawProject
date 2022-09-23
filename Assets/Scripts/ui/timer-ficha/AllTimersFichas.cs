public class AllTimersFichas 
{
    private TimerFicha timerFichaOuro;
    private TimerFicha timerFichaPrata;
    private TimerFicha timerFichaBronze;

    public AllTimersFichas(TimerFichaDto[] timerFichaDto)
    {
        timerFichaOuro = new TimerFicha(timerFichaDto[0], Ficha.OURO);
        timerFichaPrata = new TimerFicha(timerFichaDto[1], Ficha.PRATA);
        timerFichaBronze = new TimerFicha(timerFichaDto[2], Ficha.BRONZE);
    }

    public void update()
    {
        timerFichaOuro.update();
        timerFichaPrata.update();
        timerFichaBronze.update();
    }
}
