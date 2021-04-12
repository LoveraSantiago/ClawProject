using System.Collections;
using UnityEngine;

public class OrquestradorDisplayDigitos 
{
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

            displayCentena.mostrarDigito("Y");//Talve tirar daqui
            displayDezena.mostrarDigito("E");
            displayUnidade.mostrarDigito("S");

            yield return wfsTempoBlink;
        }
        
        passarScore(centena, dezena, unidade);
        yield return null;
    }

    public IEnumerator mostrarContagemRegressivo(int segundos, int centena, int dezena, int unidade)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.15f);
        for(int contadorRegressivo = segundos; contadorRegressivo > 0; contadorRegressivo--)
        {        
            for(int contador = 0; contador < 2; contador++)//COMPLETA 0.5 A CADA ITERACAO
            {
                passarScore(0, 0, contadorRegressivo);
                yield return waitForSeconds;

                desligarTodosDigitos();
                yield return waitForSeconds;                
            }
        }
        
        passarScore(centena, dezena, unidade);
        yield return null;
    }

    private  void passarScore(int centena, int dezena, int unidade)
    {
        displayCentena.mostrarDigito(centena);
        displayDezena.mostrarDigito(dezena);
        displayUnidade.mostrarDigito(unidade);
    }

    private void desligarTodosDigitos()
    {
        displayCentena.desligarDigito();
        displayDezena.desligarDigito();
        displayUnidade.desligarDigito();
    }
}
