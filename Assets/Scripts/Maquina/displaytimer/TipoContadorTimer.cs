using System;
using UnityEngine;

public abstract class TipoContadorTimer 
{
    protected float tempoInicial;
    protected float tempoPause;

    public void iniciarContagem()
    {
        tempoInicial = Time.time;
    }

    public abstract TimeSpan processarContagem();

    public void pause()
    {
        tempoPause = Time.time;
    }

    public void continuar()
    {
        tempoPause = Time.time - tempoPause;
        tempoInicial = tempoInicial + tempoPause;
    }
    
    public abstract bool isTimeOver();
    public abstract bool isNearTimeOver();
}
