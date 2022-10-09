using System;
using System.Globalization;
using UnityEngine;

public class TempoUtils 
{
    public static double parseTimeFromString(string tempo)
    {
        TimeSpan intervalo = DateTime.ParseExact(tempo, "mm:ss", CultureInfo.InvariantCulture).TimeOfDay;
        return intervalo.TotalSeconds;
    }

    public static string extrairTextoDoTempo(TimeSpan tempo)
    {
        double segundos = tempo.Seconds;
        int dezenaSegundos = (int)(segundos / 10);
        int unidadeSegundos = (int)(segundos - (dezenaSegundos * 10));

        double minutos = tempo.Minutes;
        int dezenaMinutos = (int)(minutos / 10);
        int unidadeMinutos = (int)(minutos - (dezenaMinutos * 10));

        return dezenaMinutos.ToString() + 
               unidadeMinutos.ToString() + 
               ":" + 
               dezenaSegundos.ToString() + 
               unidadeSegundos.ToString();
    }
}
