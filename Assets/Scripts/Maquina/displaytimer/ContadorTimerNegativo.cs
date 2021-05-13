using System;
using System.Globalization;
using UnityEngine;

public class ContadorTimerNegativo : ContadorTimer
{
    private double tempoRegressivoInicial;
    private double tempoInicial;

    public ContadorTimerNegativo(string tempo)
    {
        TimeSpan intervalo = DateTime.ParseExact(tempo, "mm:ss", CultureInfo.InvariantCulture).TimeOfDay;
        tempoRegressivoInicial = intervalo.TotalSeconds;
    }

    public void iniciarContagem()
    {
        tempoInicial = Time.time;
    }

    public TimeSpan processarContagem()
    {
        double tempoAtual = Time.time - tempoInicial;
        return TimeSpan.FromSeconds(tempoRegressivoInicial - tempoAtual);
    }
}
