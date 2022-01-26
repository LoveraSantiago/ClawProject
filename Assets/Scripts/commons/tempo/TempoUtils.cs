using System;
using System.Globalization;
using UnityEngine;

public class TempoUtils : MonoBehaviour
{
    public static double parseTimeFromString(string tempo)
    {
        TimeSpan intervalo = DateTime.ParseExact(tempo, "mm:ss", CultureInfo.InvariantCulture).TimeOfDay;
        return intervalo.TotalSeconds;
    }
}
