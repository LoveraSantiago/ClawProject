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

    private ContadorTimer contadorTimer;
    public ProdutorDeEvento<bool> produtorDeEventoTempoEsgotado { get; private set; }

    public DisplayTimer(DisplayTimerDto displayDto)
    {
        displayTimer2Pontos = new DisplayTimerDigito2Pontos(displayDto.GoDisplayTimer2Pontos);

        displayTimerDigito = new DisplayTimerDigito[4];        
        for(int contador = 0; contador < displayTimerDigito.Length; contador++)
        {
            displayTimerDigito[contador] = new DisplayTimerDigito(displayDto.GosDisplayTimers[contador]);
        }
        produtorDeEventoTempoEsgotado = new ProdutorDeEvento<bool>();
    }

    public void configuradoPeloLevel(AbstractLevel levelEscolhido)
    {
        if (levelEscolhido.isTempoContagemNormal())
        {
            contadorTimer = new ContadorTimerPositivo();
        }
        else
        {
            contadorTimer = new ContadorTimerNegativo(levelEscolhido.getTempoContagem());
        }
    }

    public void iniciarContagemTempo()
    {
        contadorTimer.iniciarContagem();
    }

    public void update()
    {    
        if(Time.frameCount % 5 == 0)//Contabilizando tempo a cada 5frames
        {
            atualizarTempo();
            if (contadorTimer.isTimeOver())
            {
                produtorDeEventoTempoEsgotado.produziuEvento(true);
            }
        }
    }

    private void atualizarTempo()
    {
        TimeSpan timeSpan = contadorTimer.processarContagem();

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
