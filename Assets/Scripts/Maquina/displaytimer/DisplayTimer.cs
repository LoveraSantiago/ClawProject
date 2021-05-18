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
        displayTimer2Pontos = new DisplayTimerDigito2Pontos(displayDto.SingleDisplay[4]);

        displayTimerDigito = new DisplayTimerDigito[4];
        displayTimerDigito[0] = new DisplayTimerDigito(displayDto.SingleDisplay[0]);
        displayTimerDigito[1] = new DisplayTimerDigito(displayDto.SingleDisplay[1]);
        displayTimerDigito[2] = new DisplayTimerDigito(displayDto.SingleDisplay[2]);
        displayTimerDigito[3] = new DisplayTimerDigito(displayDto.SingleDisplay[3]);        
        
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
