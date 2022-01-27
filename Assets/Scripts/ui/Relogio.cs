using System;
using UnityEngine;
using TMPro;

public class Relogio 
{
    private IntervaloDeTempo intervaloDeTempo;
    private ContadorDeTempo contadorDeTempo;
    private Ponteiros ponteiros;

    private TextMeshProUGUI lblHoras;
    private TimeSpan tempoLblHoras;

    public Relogio(TextMeshProUGUI lblHoras,
        Transform transformSegundos, Transform transformMinutos, Transform transformHoras)
    {   
        ponteiros = new Ponteiros(transformSegundos, transformMinutos, transformHoras);
        intervaloDeTempo = new IntervaloDeTempo(1.0f);
        contadorDeTempo = new ContadorDeTempoData();
        contadorDeTempo.iniciarContagem();

        this.lblHoras = lblHoras;
        tempoLblHoras = new TimeSpan(1, 30, 0);
    }

    public void updateSegundo()
    {
        bool contou1Segundo = intervaloDeTempo.contarTempoDT();
        if (contou1Segundo)
        {
            TimeSpan timeSpan = contadorDeTempo.processarContagem();
            ponteiros.andarPonteiros(timeSpan);

            intervaloDeTempo.resetContador();

            TimeSpan diferenca = tempoLblHoras - timeSpan;
            lblHoras.SetText(diferenca.Hours + "h" + diferenca.Minutes + "m");
        }
    }    
}
