using UnityEngine;
using System;

public class Relogio 
{
    private Transform transformSegundos;
    private Transform transformMinutos;
    private Transform transformHoras;

    private IntervaloDeTempo intervaloDeTempo;
    private ContadorDeTempo contadorDeTempo;

    public Relogio(Transform transformSegundos, Transform transformMinutos, Transform transformHoras)
    {
        this.transformSegundos = transformSegundos;
        this.transformMinutos = transformMinutos;
        this.transformHoras = transformHoras;

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
            andarPonteiro(transformSegundos, timeSpan.Seconds, 6);
            andarPonteiro(transformMinutos, timeSpan.Minutes, 6);
            andarPonteiro(transformHoras, timeSpan.Hours, 30);            

            intervaloDeTempo.resetContador();
        }
    }

    private void andarPonteiro(Transform transform, int tempo, int graus)
    {
        Vector3 acrescimo = - new Vector3(0, 0, graus * tempo);
        Quaternion rotacao = Quaternion.Euler(acrescimo);
        transform.rotation = rotacao;
    }
}
