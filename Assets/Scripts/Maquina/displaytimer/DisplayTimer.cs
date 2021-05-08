using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DisplayTimer 
{
    private float tempoInicial;   

    private ContadorDeTempo contadorDeTempo;
    private DisplayTimerDigito[] displayTimerDigito;
    

    public DisplayTimer(DisplayTimerDto displayDto)
    {
        displayTimerDigito = new DisplayTimerDigito[4];
        
        for(int contador = 0; contador < displayTimerDigito.Length; contador++)
        {
            displayTimerDigito[contador] = new DisplayTimerDigito(displayDto.GosDisplayTimers[contador]);
        }

        contadorDeTempo = new ContadorDeTempo(1);
        tempoInicial = Time.time;
    }

    public void update()
    {
        if (contadorDeTempo.contarTempoDT())
        {
            atualizarTempo();
            contadorDeTempo.resetContador();
        }
    }

    private void atualizarTempo()
    {
        float tempoAtual = Time.time - tempoInicial;
        TimeSpan timeSpan = TimeSpan.FromSeconds(tempoAtual);

        double minutos = timeSpan.TotalMinutes;
        double segundos = timeSpan.TotalSeconds;

        int dezenaMinutos = (int) (minutos / 10);
        int unidadeMinutos = (int) (minutos - (dezenaMinutos * 10));

        int dezenaSegundos = (int)(segundos / 10);
        int unidadeSegundos = (int)(segundos - (dezenaSegundos * 10));

        displayTimerDigito[0].mostrarDigito(dezenaMinutos);
        displayTimerDigito[1].mostrarDigito(unidadeMinutos);
        displayTimerDigito[2].mostrarDigito(dezenaSegundos);
        displayTimerDigito[3].mostrarDigito(unidadeSegundos);

    }

    
}
