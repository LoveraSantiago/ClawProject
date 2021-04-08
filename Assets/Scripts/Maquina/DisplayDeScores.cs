using UnityEngine;

public class DisplayDeScores : ConsumidorDeEvento<InformacoesColetado>
{ 
    private DisplayDigito displayCentena;
    private DisplayDigito displayDezena;
    private DisplayDigito displayUnidade;

    public DisplayDeScores(GameObject[] displayScores)
    {
        displayCentena = new DisplayDigito(displayScores[0]);
        displayDezena = new DisplayDigito(displayScores[1]);
        displayUnidade = new DisplayDigito(displayScores[2]);        
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

    //IMPLEMENTANDO INTERFACE ConsumidorDeEvento<InformacoesColetado> INICIO
    //CONSOME EVENTO DISPARADO PELO COLETAVEIS MANAGER AO COLETAR UM COLETAVEL
    public void consumirEvento(InformacoesColetado infoColetado)
    {
        mostrarScore(infoColetado.score);        
    }
    //IMPLEMENTANDO INTERFACE ConsumidorDeEvento<InformacoesColetado> FIM

    public ConsumidorDeEvento<InformacoesColetado> getDisplayScoreConsumidor()
    {
        return this;
    }
}
