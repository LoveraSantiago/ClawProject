using System.Collections;
using UnityEngine;

public class OrquestradorDisplayDigitos 
{
    private DisplayDeScoreDto displayDeScoresDto;

    private DisplayScoreDigito displayCentena;
    private DisplayScoreDigito displayDezena;
    private DisplayScoreDigito displayUnidade;

    public OrquestradorDisplayDigitos(
        DisplayDeScoreDto displayDeScoresDto,
        DisplayScoreDigito displayCentena, DisplayScoreDigito displayDezena, DisplayScoreDigito displayUnidade)
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

    public IEnumerator mostrarContagemRegressivo(int segundos)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.25f);

        for(int contadorRegressivo = segundos; contadorRegressivo > 0; contadorRegressivo--)
        {
            for(int contador = 0; contador < 2; contador++)//COMPLETA 0.5 A CADA ITERACAO
            {
                passarScore("!", contadorRegressivo, "!", Color.yellow);
                yield return waitForSeconds;

                desligarTodosDigitos();
                yield return waitForSeconds;                
            }
        }

        while (true)
        {
            passarScore("*", "*", "*", Color.yellow);
            yield return waitForSeconds;

            desligarTodosDigitos();
            yield return waitForSeconds;
        }        
    }

    public IEnumerator blinkarAsteriscos()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.25f);//TODO REFATORAR TODOS OS WAITFORSECONDS
        while (true)
        {
            passarScore("*", "*", "*", Color.yellow);
            yield return waitForSeconds;

            desligarTodosDigitos();
            yield return waitForSeconds;
        }
    }   

    public void ligarGlows()
    {
        displayCentena.ligarGlowSucesso();
        displayDezena.ligarGlowSucesso();
        displayUnidade.ligarGlowSucesso();
    }

    public void desligarGlows()
    {
        displayCentena.desligarGlow();
        displayDezena.desligarGlow();
        displayUnidade.desligarGlow();
    }
   
    public void passarScore(int centena, int dezena, int unidade)
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
