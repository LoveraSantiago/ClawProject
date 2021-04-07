using UnityEngine;

public class DisplayDeScores : ConsumidorDeEvento<InformacoesColetado>
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
