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
        GameObject placaPrincipal = finder.findNoComponente(goTimer, ConstantesCoresMaquinaV2.TIMER_PLACA_PRINCIPAL);
        return new SingleCompColorivel(placaPrincipal);
    }

    public ComponenteColorivel getPlacaDigitos()
    {   
        GameObject placaDisplayTimer1 = getGoDigito("v61");
        GameObject placaDisplayTimer2 = getGoDigito("v62");
        GameObject placaDisplayTimer3 = getGoDigito("v63");
        GameObject placaDisplayTimer4 = getGoDigito("v64");

        return new MultipleCompColorivel(new GameObject[] {
            placaDisplayTimer1, placaDisplayTimer2, placaDisplayTimer3, placaDisplayTimer4
        });
    }

    public ComponenteColorivel getSegmentos()
    {
        GameObject goTimer = getTimerPrincipal();

        List<GameObject> gosSegmentos = new List<GameObject>();
        gosSegmentos.Add(getSegmentos("v61"));
        gosSegmentos.Add(getSegmentos("v62"));
        gosSegmentos.Add(getSegmentos("v63"));
        gosSegmentos.Add(getSegmentos("v64"));
        gosSegmentos.AddRange(getSegmentos2Pontos());
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

        //List<GameObject> gosSegmentos = new List<GameObject>();
        //for(int contador = 0; contador < 7; contador++)
        //{
        //    GameObject singleDisplay = finder.findNoComponente(displayTimer, ConstantesCoresMaquinaV2.TIMER_DISPLAY_SEGMENTOS + "-" + (contador + 1));
        //    gosSegmentos.Add(singleDisplay);
        //}
        //return gosSegmentos;
    }

    private List<GameObject> getSegmentos2Pontos()
    {
        GameObject display2Pontos = finder.findNoComponente(goTimer, "display-timer-2pontos");
        List<GameObject> gosSegmentos = new List<GameObject>();
        gosSegmentos.Add(finder.findNoComponente(display2Pontos, ConstantesCoresMaquinaV2.TIMER_DISPLAY_SEGMENTOS + "-1"));
        gosSegmentos.Add(finder.findNoComponente(display2Pontos, ConstantesCoresMaquinaV2.TIMER_DISPLAY_SEGMENTOS + "-2"));
        return gosSegmentos;
    }
}
