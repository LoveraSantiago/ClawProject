using System;
using System.Globalization;
using UnityEngine;

public class ContadorTimerNegativo : TipoContadorTimer
{
    private double tempoRegressivoInicial;    
    private double tempoResult;

    public ContadorTimerNegativo(string tempo)
    {
        TimeSpan intervalo = DateTime.ParseExact(tempo, "mm:ss", CultureInfo.InvariantCulture).TimeOfDay;
        tempoRegressivoInicial = intervalo.TotalSeconds;
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
