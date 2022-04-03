using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoridorDeLeds 
{
    private DisplayScoreDigito displayCentena;
    private DisplayScoreDigito displayDezena;
    private DisplayScoreDigito displayUnidade;

    public ColoridorDeLeds(
        DisplayScoreDigito displayCentena, DisplayScoreDigito displayDezena, DisplayScoreDigito displayUnidade)
    {
        this.displayCentena = displayCentena;
        this.displayDezena = displayDezena;
        this.displayUnidade = displayUnidade;
    }

    public void colorir(Dictionary<string, string> dicionarioDeCores)
    {
        string hexCor = dicionarioDeCores[ConstantesCoresMaquina.DISPLAY_SCORES1];
        string hexLed = dicionarioDeCores[ConstantesCoresMaquina.LEDS1];
        displayCentena.configuradoPeloLevel(hexCor, hexLed);

        hexCor = dicionarioDeCores[ConstantesCoresMaquina.DISPLAY_SCORES2];
        hexLed = dicionarioDeCores[ConstantesCoresMaquina.LEDS2];
        displayDezena.configuradoPeloLevel(hexCor, hexLed);

        hexCor = dicionarioDeCores[ConstantesCoresMaquina.DISPLAY_SCORES3];
        hexLed = dicionarioDeCores[ConstantesCoresMaquina.LEDS3];
        displayUnidade.configuradoPeloLevel(hexCor, hexLed);
    }
}
