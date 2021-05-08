using System;
using UnityEngine;

public class DisplayTimer 
{    
    private int segundosUnidadeAtual;
    private int segundosDezenaAtual;
    private int minutosUnidadeAtual;
    private int minutosDezenaAtual;

    private float tempoInicial;   

    private DisplayTimerDigito[] displayTimerDigito;
    private DisplayTimerDigito2Pontos displayTimer2Pontos;

    public DisplayTimer(DisplayTimerDto displayDto)
    {
        displayTimer2Pontos = new DisplayTimerDigito2Pontos(displayDto.GoDisplayTimer2Pontos);

        displayTimerDigito = new DisplayTimerDigito[4];        
        for(int contador = 0; contador < displayTimerDigito.Length; contador++)
        {
            displayTimerDigito[contador] = new DisplayTimerDigito(displayDto.GosDisplayTimers[contador]);
        }    
    }

    public void iniciarContagemTempo()
    {        
        tempoInicial = Time.time;
    }

    public void update()
    {     
        atualizarTempo();     
    }

    private void atualizarTempo()
    {
        float tempoAtual = Time.time - tempoInicial;
        TimeSpan timeSpan = TimeSpan.FromSeconds(tempoAtual);

        double segundos = timeSpan.Seconds;
        int dezenaSegundos = (int)(segundos / 10);
        int unidadeSegundos = (int)(segundos - (dezenaSegundos * 10));

        if (unidadeSegundos == segundosUnidadeAtual) return;
        segundosUnidadeAtual = unidadeSegundos;
        displayTimerDigito[3].mostrarDigito(unidadeSegundos);

        if (dezenaSegundos == segundosDezenaAtual) return;
        segundosDezenaAtual = dezenaSegundos;
        displayTimerDigito[2].mostrarDigito(dezenaSegundos);

        double minutos = timeSpan.Minutes;
        int dezenaMinutos = (int) (minutos / 10);
        int unidadeMinutos = (int) (minutos - (dezenaMinutos * 10));

        if (unidadeMinutos == minutosUnidadeAtual) return;
        minutosUnidadeAtual = unidadeMinutos;
        displayTimerDigito[1].mostrarDigito(unidadeMinutos);

        if (dezenaMinutos == minutosDezenaAtual) return;
        minutosDezenaAtual = dezenaMinutos;
        displayTimerDigito[0].mostrarDigito(dezenaMinutos);
    }   
}
