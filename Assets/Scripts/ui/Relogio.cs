using System;
using UnityEngine;

public class Relogio 
{
    private IntervaloDeTempo intervaloDeTempo;
    private ContadorDeTempo contadorDeTempo;
    private Ponteiros ponteiros;

    public Relogio(Transform transformSegundos, Transform transformMinutos, Transform transformHoras)
    {   
        ponteiros = new Ponteiros(transformSegundos, transformMinutos, transformHoras);
        intervaloDeTempo = new IntervaloDeTempo(1.0f);
        contadorDeTempo = new ContadorDeTempoData();
        contadorDeTempo.iniciarContagem();
    }

    public void updateSegundo()
    {
        bool contou1Segundo = intervaloDeTempo.contarTempoDT();
        if (contou1Segundo)
        {
            TimeSpan timeSpan = contadorDeTempo.processarContagem();
            ponteiros.andarPonteiros(timeSpan);

            intervaloDeTempo.resetContador();
        }
    }    
}
