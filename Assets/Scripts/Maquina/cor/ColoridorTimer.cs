using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoridorTimer 
{
    private SpriteRenderer placaTimer;
    private DisplayTimerDigito[] displayTimerDigito;

    public ColoridorTimer(SpriteRenderer placaTimer, DisplayTimerDigito[] displayTimerDigito)
    {
        this.placaTimer = placaTimer;
        this.displayTimerDigito = displayTimerDigito;
    }

    public void colorir(Dictionary<string, string> dicionarioDeCores)
    {
        string corTimerHex = dicionarioDeCores[ConstantesCoresMaquina.DISPLAY_TIMER];
        string corDigitosHex = dicionarioDeCores[ConstantesCoresMaquina.DIGITOS_TIMERS];

        placaTimer.color = Utils.getCorByHex(corTimerHex);

        Color corDigito = Utils.getCorByHex(corDigitosHex);
        //displayTimerDigito[0].configuradoPeloLevel(corDigito);
        //displayTimerDigito[1].configuradoPeloLevel(corDigito);
        //displayTimerDigito[2].configuradoPeloLevel(corDigito);
        //displayTimerDigito[3].configuradoPeloLevel(corDigito);
    }
}
