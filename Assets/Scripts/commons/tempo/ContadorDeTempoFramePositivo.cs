using System;
using UnityEngine;

public class ContadorDeTempoFramePositivo : ContadorDeTempoFrame
{
    public override TimeSpan processarContagem()
    {
        float tempoAtual = Time.time - tempoInicial;        
        return TimeSpan.FromSeconds(tempoAtual);
    }

    public override bool isNearTimeOver()
    {
        return false;
    }

    public override bool isTimeOver()
    {
        return false;
    }
}
