using System;
using UnityEngine;

public class DadosDeTempo : Fornecedor<string>
{
    private ContadorDeTempo contadorTempo;

    public DadosDeTempo(ContadorDeTempo contadorTempo)
    {
        this.contadorTempo = contadorTempo;
    }

    public string fornecer()
    {
        float tempoPartida = Time.time - contadorTempo.getTempoInicioPartida();
        TimeSpan timeSpan = TimeSpan.FromSeconds(tempoPartida);
        return TempoUtils.extrairTextoDoTempo(timeSpan);        
    }    
}
