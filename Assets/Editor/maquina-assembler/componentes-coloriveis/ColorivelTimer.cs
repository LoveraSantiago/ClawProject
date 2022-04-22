using UnityEngine;
using System.Collections.Generic;

public class ColorivelTimer 
{
    private GameObject goTimer;
    private FinderComponente finder;

    public ColorivelTimer(FinderComponente finder)
    {
        this.finder = finder;
        goTimer = getTimerPrincipal();
    }

    public ComponenteColorivel getPlacaPrincipal()
    {   
        return new SingleCompColorivel(goTimer);
    }

    public ComponenteColorivel getPlacaDigitos()
    {   
        GameObject placaDisplayTimer1 = getGoDigito("1");
        GameObject placaDisplayTimer2 = getGoDigito("2");
        GameObject placaDisplayTimer3 = getGoDigito("3");
        GameObject placaDisplayTimer4 = getGoDigito("4");

        return new MultipleCompColorivel(new GameObject[] {
            placaDisplayTimer1, placaDisplayTimer2, placaDisplayTimer3, placaDisplayTimer4
        });
    }

    public ComponenteColorivel getSegmentos()
    {
        GameObject goTimer = getTimerPrincipal();

        List<GameObject> gosSegmentos = new List<GameObject>();
        gosSegmentos.Add(getSegmentos("1"));
        gosSegmentos.Add(getSegmentos("2"));
        gosSegmentos.Add(getSegmentos("3"));
        gosSegmentos.Add(getSegmentos("4"));
        gosSegmentos.Add(getSegmentos2Pontos());
        return new MultipleCompColorivel(gosSegmentos.ToArray());
    }

    private GameObject getTimerPrincipal()
    {
        return finder.findNaMaquina("display-timer");
    }

    private GameObject getGoDigito(string numero)
    {
        return finder.findNoComponente(goTimer, ConstantesCoresMaquinaV2.TIMER_PLACA_DIGITO + numero);
    }

    private GameObject getSegmentos(string digito)
    {
        GameObject placaDisplayTimer = getGoDigito(digito);
        GameObject displayTimer = finder.findNoComponente(placaDisplayTimer, "display");
        return displayTimer;       
    }

    private GameObject getSegmentos2Pontos()
    {
        GameObject display2Pontos = finder.findNoComponente(goTimer, "display-timer-2pontos");
        return display2Pontos;       
    }
}
