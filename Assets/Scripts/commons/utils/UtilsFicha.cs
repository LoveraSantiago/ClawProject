public class UtilsFicha
{
    private static PlayerPrefsFichas playerPrefsFichas = new PlayerPrefsFichas();

    public static int getQtdFichasBronze()
    {
        return playerPrefsFichas.getQtdFichas(Ficha.BRONZE); 
    }

    public static bool possuiFichasDeOuro(int qtd)
    {
        return playerPrefsFichas.possueFichas(Ficha.OURO, qtd);
    }
    
    public static bool possuiFichasDeBronze(int qtd)
    {
        return playerPrefsFichas.possueFichas(Ficha.BRONZE, qtd);
    }
    
    public static bool possuiFichasDePrata(int qtd)
    {
        return playerPrefsFichas.possueFichas(Ficha.PRATA, qtd);
    }

    public static void agendarFichaDeBronzeGanha(int qtd)
    {
        playerPrefsFichas.ganharFicha(Ficha.BRONZE, qtd);//TODO MODIFICAR PARA AGENDAMENTO E EM TIMER FICHA RECUPERAR AGENDAMENTOS
        playerPrefsFichas.ganhouFichasBronzeCacaNiquel(qtd);
    }

    public static int getFichasGanhasDeBronze()
    {
        return playerPrefsFichas.getFichasDeBronzeGanhasCacaNiquel();
    }
}
