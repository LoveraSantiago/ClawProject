using System.Collections;
using System.Collections.Generic;
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

    public IEnumerator blinkarScoreSucesso(int centena, int dezena, int unidade)
    {
        WaitForSeconds wfsTempoBlink = new WaitForSeconds(displayDeScoresDto.TempoBlink);
        for (int contador = 0; contador < displayDeScoresDto.QtdBlinks; contador++)
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

}
