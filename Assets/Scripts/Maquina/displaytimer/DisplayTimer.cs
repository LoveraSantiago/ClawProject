using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTimer 
{
    private DisplayTimerDigito[] displayTimerDigito;


    public DisplayTimer(DisplayTimerDto displayDto)
    {
        displayTimerDigito = new DisplayTimerDigito[4];
        
        for(int contador = 0; contador < displayTimerDigito.Length; contador++)
        {
            displayTimerDigito[contador] = new DisplayTimerDigito(displayDto.GosDisplayTimers[contador]);
        }
    }

    public void update()
    {

    }

    
}
