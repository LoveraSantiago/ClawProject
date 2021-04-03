using UnityEngine;

public class DisplayDeScores : ConsumidorDeEvento<int>
{
    private DisplayDigito displayCentena;
    private DisplayDigito displayDezena;
    private DisplayDigito displayUnidade;

    public DisplayDeScores(GameObject goDisplay1, GameObject goDisplay2, GameObject goDisplay3)
    {
        displayCentena = new DisplayDigito(goDisplay1);
        displayDezena = new DisplayDigito(goDisplay2);
        displayUnidade = new DisplayDigito(goDisplay3);        
    }

   
    private void mostrarScore(int score)
    {
        int scoreTotal = score;
        int centena = scoreTotal / 100;

        scoreTotal -= centena * 100;
        int dezena =scoreTotal / 10;

        scoreTotal -= dezena * 10;
        int unidade = scoreTotal;

        displayCentena.mostrarDigito(centena);
        displayDezena.mostrarDigito(dezena);
        displayUnidade.mostrarDigito(unidade);
    }

    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<int> INICIO
    //É CHAMADO PELO PIPELINEDEEVENTOCOLETADO APOS SER COMPUTADO O SCORE VINDO DO COLETAVEL MANAGER
    public void consumirEvento(int evento)
    {
        mostrarScore(evento);
    }
    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<int> INICIO

    public ConsumidorDeEvento<int> getDisplayScoreConsumidor()
    {
        return this;
    }
}
