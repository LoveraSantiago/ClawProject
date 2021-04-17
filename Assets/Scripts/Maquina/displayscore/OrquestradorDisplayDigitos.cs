using System.Collections;
using UnityEngine;

public class OrquestradorDisplayDigitos 
{
    private bool continuarContagemRegressiva;

    private DisplayDeScoreDto displayDeScoresDto;

    private DisplayDigito displayCentena;
    private DisplayDigito displayDezena;
    private DisplayDigito displayUnidade;

    public OrquestradorDisplayDigitos(
        DisplayDeScoreDto displayDeScoresDto,
        DisplayDigito displayCentena, DisplayDigito displayDezena, DisplayDigito displayUnidade)
    {
        this.displayDeScoresDto = displayDeScoresDto;
        this.displayCentena = displayCentena;
        this.displayDezena = displayDezena;
        this.displayUnidade = displayUnidade;
    }

    public IEnumerator blinkarScore(int centena, int dezena, int unidade)
    {
        WaitForSeconds wfsTempoBlink = new WaitForSeconds(displayDeScoresDto.TempoBlink);
        for (int contador = 0; contador < displayDeScoresDto.QtdBlinks; contador++)
        {
            desligarTodosDigitos();
            yield return wfsTempoBlink;

            passarScore(centena, dezena, unidade);
            yield return wfsTempoBlink;
        }
        yield return null;
    }

    public IEnumerator blinkarScoreSucesso(int centena, int dezena, int unidade)
    {
        WaitForSeconds wfsTempoBlink = new WaitForSeconds(displayDeScoresDto.TempoBlink);
        for (int contador = 0; contador < displayDeScoresDto.QtdBlinks; contador++)
        {
            passarScore(centena, dezena, unidade);
            yield return wfsTempoBlink;

            displayCentena.mostrarDigito("Y", Color.green);
            displayDezena.mostrarDigito ("E", Color.green);
            displayUnidade.mostrarDigito("S", Color.green);

            yield return wfsTempoBlink;
        }
        
        passarScore(centena, dezena, unidade);
        yield return null;
    }

    public IEnumerator mostrarContagemRegressivo(int segundos, int centena, int dezena, int unidade)
    {
        continuarContagemRegressiva = true;
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.25f);

        for(int contadorRegressivo = segundos; contadorRegressivo >= 0; contadorRegressivo--)
        {        
            for(int contador = 0; contador < 2; contador++)//COMPLETA 0.5 A CADA ITERACAO
            {
                passarScore("!", contadorRegressivo, "!", Color.yellow);
                yield return waitForSeconds;

                desligarTodosDigitos();
                yield return waitForSeconds;                
            }
        }

        while (continuarContagemRegressiva)
        {
            passarScore("*", "*", "*", Color.yellow);
            yield return waitForSeconds;

            desligarTodosDigitos();
            yield return waitForSeconds;
        }

        passarScore(centena, dezena, unidade);
        yield return null;
    }

    public void finalizarContatemRegressiva()
    {
        continuarContagemRegressiva = false;
    }

    private void passarScore(int centena, int dezena, int unidade)
    {
        displayCentena.mostrarDigito(centena, Color.red);
        displayDezena.mostrarDigito(dezena, Color.red);
        displayUnidade.mostrarDigito(unidade, Color.red);
    }

    private void passarScore(string centena, string dezena, string unidade, Color cor)
    {
        displayCentena.mostrarDigito(centena, cor);
        displayDezena.mostrarDigito(dezena, cor);
        displayUnidade.mostrarDigito(unidade, cor);
    }

    private void passarScore(string centena, int dezena, string unidade, Color cor)
    {
        displayCentena.mostrarDigito(centena, cor);
        displayDezena.mostrarDigito(dezena, cor);
        displayUnidade.mostrarDigito(unidade, cor);
    }

    private void desligarTodosDigitos()
    {
        displayCentena.desligarDigito();
        displayDezena.desligarDigito();
        displayUnidade.desligarDigito();
    }
}
