using System;
using UnityEngine;

public class ContadorTimerPositivo : ContadorTimer
{
    private float tempoInicial;

    public void iniciarContagem()
    {
        tempoInicial = Time.time;
    }

    public bool isTimeOver()
    {
        return false;
    }

    public TimeSpan processarContagem()
    {
        float tempoAtual = Time.time - tempoInicial;        
        return TimeSpan.FromSeconds(tempoAtual);
    }
}
