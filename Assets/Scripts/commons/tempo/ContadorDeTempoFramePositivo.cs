using System;
using UnityEngine;

public class ContadorDeTempoFramePositivo : ContadorDeTempoFrame
{
    private TimeSpan tempoNearTimeOver;
    private TimeSpan tempoTimeOver;
    private TimeSpan tempoAtual;

    public ContadorDeTempoFramePositivo()
    {
        tempoNearTimeOver = TimeSpan.FromSeconds(TempoUtils.parseTimeFromString("59:50"));
        tempoTimeOver     = TimeSpan.FromSeconds(TempoUtils.parseTimeFromString("59:59"));
    }

    public override TimeSpan processarContagem()
    {
        float tempoAtualFloat = Time.time - tempoInicial;                
        tempoAtual = TimeSpan.FromSeconds(tempoAtualFloat);
        return tempoAtual;
    }

    public override bool isNearTimeOver()
    {
        return TimeSpan.Compare(tempoAtual, tempoNearTimeOver) >= 0;
    }

    public override bool isTimeOver()
    {
        return TimeSpan.Compare(tempoAtual, tempoTimeOver) >= 0;
    }
}
