using System.Collections.Generic;
using UnityEngine;

public class ColoridorTimerV2 
{
    private SpriteRenderer placaTimer;
    private DisplayTimerDigito[] displayTimerDigito;

    public ColoridorTimerV2(SpriteRenderer placaTimer, DisplayTimerDigito[] displayTimerDigito)
    {
        this.placaTimer = placaTimer;
        this.displayTimerDigito = displayTimerDigito;
    }

    public void colorir(Dictionary<string, string> dicionarioDeCores)
    {
        string corDigitosHex = dicionarioDeCores[ConstantesCoresMaquinaV2.TIMER_DISPLAY_SEGMENTOS];
        Color corDigito = Utils.getCorByHex(corDigitosHex);
        displayTimerDigito[0].configuradoPeloLevel(corDigito);
        displayTimerDigito[1].configuradoPeloLevel(corDigito);
        displayTimerDigito[2].configuradoPeloLevel(corDigito);
        displayTimerDigito[3].configuradoPeloLevel(corDigito);
    }
}
