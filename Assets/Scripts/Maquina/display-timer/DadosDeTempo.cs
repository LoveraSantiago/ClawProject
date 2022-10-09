using System;
using UnityEngine;

public class DadosDeTempo : ProvedorDadosTempo
{
    private ContadorDeTempo contadorTempo;

    public DadosDeTempo(ContadorDeTempo contadorTempo)
    {
        this.contadorTempo = contadorTempo;
    }

    public string getTempoPartida()
    {
        float tempoPartida = Time.time - contadorTempo.getTempoInicioPartida();
        TimeSpan timeSpan = TimeSpan.FromSeconds(tempoPartida);
        return timeSpan.Minutes + ":" + timeSpan.Seconds;
    }
}
