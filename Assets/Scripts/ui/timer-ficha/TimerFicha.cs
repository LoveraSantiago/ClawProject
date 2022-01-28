using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerFicha 
{
    public TimerFicha(TimerFichaDto timerFichaDto, Ficha ficha)
    {
        timerFichaDto.ImgMoeda.sprite = timerFichaDto.SprMoeda;
        timerFichaDto.BtnMais.onClick.AddListener(() => CenaUtils.irParaCenaLoja());
        timerFichaDto.LblQdtFichas.text = PlayerPrefsFichas.getQtdFichas(ficha).ToString();
    }
}
