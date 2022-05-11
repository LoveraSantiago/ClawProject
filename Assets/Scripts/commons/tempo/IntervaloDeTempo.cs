using UnityEngine;

public class IntervaloDeTempo 
{
    private float intervalo;
    private float contadorTempo;

    public IntervaloDeTempo()
    {
    }

    public IntervaloDeTempo(float tempoEmSegundos)
    {
        configTempoParaAcao(tempoEmSegundos);
    }

    public bool contarTempo()
    {
        contadorTempo -= Time.deltaTime;
        if (contadorTempo <= 0)
        {
            return true;
        }
        return false;
    }

    public bool contarTempoUnescaled()
    {
        contadorTempo -= Time.unscaledDeltaTime;
        if (contadorTempo <= 0)
        {
            return true;
        }
        return false;
    }

    public void configTempoParaAcao(float tempoEmSegundos)
    {
        intervalo = tempoEmSegundos;
        resetContador();
    }    

    public void resetContador()
    {
        contadorTempo = intervalo;        
    }

    public void addTempoLongo()
    {
        contadorTempo = float.MaxValue;
    }
}
