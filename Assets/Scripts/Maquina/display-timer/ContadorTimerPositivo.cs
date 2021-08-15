using System;
using UnityEngine;

public class ContadorTimerPositivo : TipoContadorTimer
{         

    public override bool isNearTimeOver()
    {
        return false;
    }

    public override bool isTimeOver()
    {
        return false;
    }

    public override TimeSpan processarContagem()
    {
        float tempoAtual = Time.time - tempoInicial;        
        return TimeSpan.FromSeconds(tempoAtual);
    }
}
