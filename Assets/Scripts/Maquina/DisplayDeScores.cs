using UnityEngine;
using System.Collections;

public class DisplayDeScores : ConsumidorDeEvento<InformacoesColetado>
{ 
    private DisplayDigito displayCentena;
    private DisplayDigito displayDezena;
    private DisplayDigito displayUnidade;

    private int qtdBlinks;
    private float tempoBlink;
    private MonoBehaviour monoBehaviour;

    public DisplayDeScores(GameObject[] displayScores, int qtdBlinks, float tempoBlink, MonoBehaviour monoBehaviour)
    {
        this.monoBehaviour = monoBehaviour;
        this.qtdBlinks = qtdBlinks;
        this.tempoBlink = tempoBlink;

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

        monoBehaviour.StartCoroutine(blinkarScore(centena, dezena, unidade));
    }

    private IEnumerator blinkarScore(int centena, int dezena, int unidade)
    {
        WaitForSeconds wfsTempoBlink = new WaitForSeconds(tempoBlink);
        for(int contador = 0; contador < qtdBlinks; contador++)
        {
            displayCentena.desligarDigito();
            displayDezena.desligarDigito();
            displayUnidade.desligarDigito();

            yield return wfsTempoBlink;

            displayCentena.mostrarDigito(centena);
            displayDezena.mostrarDigito(dezena);
            displayUnidade.mostrarDigito(unidade);

            yield return wfsTempoBlink;
        }
        yield return null;
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
