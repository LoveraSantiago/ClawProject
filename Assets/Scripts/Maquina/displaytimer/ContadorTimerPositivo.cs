using System;
using UnityEngine;

public class ContadorTimerPositivo : TipoContadorTimer
{
    private float tempoInicial;
    private float tempoPause;

    public void iniciarContagem()
    {
        tempoInicial = Time.time;
    }

    public void pause()
    {
        tempoPause = Time.time;
    }

    public void continuar()
    {
        tempoPause = Time.time - tempoPause;
        tempoInicial = tempoInicial + tempoPause;
    }

    public bool isNearTimeOver()
    {
        return false;
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
