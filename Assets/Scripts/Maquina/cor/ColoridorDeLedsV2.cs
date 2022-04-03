using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoridorDeLedsV2 : MonoBehaviour
{
    private DisplayScoreDigito displayCentena;
    private DisplayScoreDigito displayDezena;
    private DisplayScoreDigito displayUnidade;

    public ColoridorDeLedsV2(
        DisplayScoreDigito displayCentena, DisplayScoreDigito displayDezena, DisplayScoreDigito displayUnidade)
    {
        this.displayCentena = displayCentena;
        this.displayDezena = displayDezena;
        this.displayUnidade = displayUnidade;
    }

    public void colorir(Dictionary<string, string> dicionarioDeCores)
    {
    }
}
