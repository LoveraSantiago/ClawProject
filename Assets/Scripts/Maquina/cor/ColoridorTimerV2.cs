using System.Collections;
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
        
    }
}
