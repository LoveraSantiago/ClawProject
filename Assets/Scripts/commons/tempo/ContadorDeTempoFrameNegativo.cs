using System;
using UnityEngine;

public class ContadorDeTempoFrameNegativo : ContadorDeTempoFrame
{
    private double tempoRegressivoInicial;    
    private double tempoResult;

    public ContadorDeTempoFrameNegativo(string tempo)
    {
        setTempoRegressivoInicial(tempo);
    }    

    protected void setTempoRegressivoInicial(string tempo)
    {
        tempoRegressivoInicial = TempoUtils.parseTimeFromString(tempo);
    }
        
    public override bool isTimeOver()
    {
        return tempoResult <= 0;
    }

    public override bool isNearTimeOver()
    {
        return tempoResult <= 15;
    }

    public override TimeSpan processarContagem()
    {
        double tempoAtual = Time.time - tempoInicial;
        tempoResult = tempoRegressivoInicial - tempoAtual;
        return TimeSpan.FromSeconds(tempoResult);
    }
}
