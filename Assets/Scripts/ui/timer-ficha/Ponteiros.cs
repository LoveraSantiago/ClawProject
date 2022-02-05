using System;
using UnityEngine;

public class Ponteiros 
{
    public void andarPonteiros(TimeSpan timeSpan, RelogioDto relogioDto)
    {   
        andarPonteiro(relogioDto.TransfSegundos, timeSpan.Seconds, 6);
        andarPonteiro(relogioDto.TransfMinutos, timeSpan.Minutes, 6);
        andarPonteiro(relogioDto.TransfHoras, timeSpan.Hours, 30);       
    }

    public void zerarPonteiros(RelogioDto relogioDto)
    {
        andarPonteiro(relogioDto.TransfSegundos, 0, 0);
        andarPonteiro(relogioDto.TransfMinutos, 0, 0);
        andarPonteiro(relogioDto.TransfHoras, 0, 0);
    }

    private void andarPonteiro(Transform transform, int tempo, int graus)
    {
        Vector3 acrescimo = -new Vector3(0, 0, graus * tempo);
        Quaternion rotacao = Quaternion.Euler(acrescimo);
        transform.rotation = rotacao;
    }
}
