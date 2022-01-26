using UnityEngine;
using System;

public class Relogio 
{
    private Transform transformSegundos;
    private Transform transformMinutos;
    private Transform transformHoras;

    private IntervaloDeTempo intervaloDeTempo;
    private ContadorDeTempoFramePositivo timer;

    public Relogio(Transform transformSegundos, Transform transformMinutos, Transform transformHoras)
    {
        this.transformSegundos = transformSegundos;
        this.transformMinutos = transformMinutos;
        this.transformHoras = transformHoras;

        intervaloDeTempo = new IntervaloDeTempo(1.0f);
        timer = new ContadorDeTempoFramePositivo();
    }

    public void updateSegundo()
    {
        bool contou1Segundo = intervaloDeTempo.contarTempoFDT();
        if (contou1Segundo)
        {
            TimeSpan timeSpan = timer.processarContagem();
            andarPonteiro(transformSegundos, timeSpan.Seconds);
            andarPonteiro(transformMinutos, timeSpan.Minutes);
            andarPonteiro(transformHoras, timeSpan.Hours);            

            intervaloDeTempo.resetContador();
        }
    }

    private void andarPonteiro(Transform transform, int tempo)
    {
        Vector3 acrescimo = - new Vector3(0, 0, 6 * tempo);
        Quaternion rotacao = Quaternion.Euler(acrescimo);
        transform.rotation = rotacao;
    }
}
