using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerFicha 
{
    public TimerFicha(TimerFichaDto timerFichaDto)
    {
        timerFichaDto.ImgMoeda.sprite = timerFichaDto.SprMoeda;
    }
}
