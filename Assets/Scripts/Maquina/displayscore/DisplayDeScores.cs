using UnityEngine;
using System.Collections;

public class DisplayDeScores : ConsumidorDeEvento<InformacoesColetado>,
                               ConsumidorDeEvento<PowerUp>
{ 
    private DisplayDigito displayCentena;
    private DisplayDigito displayDezena;
    private DisplayDigito displayUnidade;

    private DisplayDeScoreDto displayDeScoresDto;
    private MonoBehaviour monoBehaviour;

    public DisplayDeScores(DisplayDeScoreDto displayDeScoresDto, MonoBehaviour monoBehaviour)
    {
        this.monoBehaviour = monoBehaviour;
        this.displayDeScoresDto = displayDeScoresDto;

        GameObject[] displayScores = displayDeScoresDto.GosDisplayScores;
        displayCentena = new DisplayDigito(displayScores[0]);
        displayDezena = new DisplayDigito(displayScores[1]);
        displayUnidade = new DisplayDigito(displayScores[2]);
    }
   
    private void mostrarScore(int score, bool result)
    {
        int scoreTotal = score;
        int centena = scoreTotal / 100;

        scoreTotal -= centena * 100;
        int dezena =scoreTotal / 10;

        scoreTotal -= dezena * 10;
        int unidade = scoreTotal;
        if (result)
        {
            monoBehaviour.StartCoroutine(blinkarScoreSucesso(centena, dezena, unidade));
        }
        else
        {
            monoBehaviour.StartCoroutine(blinkarScore(centena, dezena, unidade));
        }
    }

    private IEnumerator blinkarScore(int centena, int dezena, int unidade)
    {
        WaitForSeconds wfsTempoBlink = new WaitForSeconds(displayDeScoresDto.TempoBlink);
        for(int contador = 0; contador < displayDeScoresDto.QtdBlinks; contador++)
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

    private IEnumerator blinkarScoreSucesso(int centena, int dezena, int unidade)
    {
        WaitForSeconds wfsTempoBlink = new WaitForSeconds(displayDeScoresDto.TempoBlink);
        for(int contador = 0; contador < displayDeScoresDto.QtdBlinks; contador++)
        {
            displayCentena.mostrarDigito(centena);
            displayDezena.mostrarDigito(dezena);
            displayUnidade.mostrarDigito(unidade);

            yield return wfsTempoBlink;

            displayCentena.mostrarDigito("Y");
            displayDezena.mostrarDigito("E");
            displayUnidade.mostrarDigito("S");

            yield return wfsTempoBlink;
        }

        displayCentena.mostrarDigito(centena);
        displayDezena.mostrarDigito(dezena);
        displayUnidade.mostrarDigito(unidade);
        yield return null;
    }

    //IMPLEMENTANDO INTERFACE ConsumidorDeEvento<InformacoesColetado> INICIO
    //CONSOME EVENTO DISPARADO PELO COLETAVEIS MANAGER AO COLETAR UM COLETAVEL
    public void consumirEvento(InformacoesColetado infoColetado)
    {
        mostrarScore(infoColetado.score, infoColetado.resultCombinacao);        
    }
    //IMPLEMENTANDO INTERFACE ConsumidorDeEvento<InformacoesColetado> FIM

    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<PowerUp> INICIO
    public void consumirEvento(PowerUp evento)
    {
        
    }
    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<PowerUp> INICIO

    public ConsumidorDeEvento<InformacoesColetado> getDisplayScoreConsumidor()
    {
        return this;
    }

    public ConsumidorDeEvento<PowerUp> getConsumidorDePowerUp()
    {
        return this;
    }
}
