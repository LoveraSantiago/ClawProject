using System;
using UnityEngine;

public class ContadorDeTempo 
{
    private float tempoParaAcao;
    private float contadorTempo;    
    
    public ContadorDeTempo(float tempoEmSegundosParaAcao)
    {
        configTempoParaAcao(tempoEmSegundosParaAcao);
    }

    public bool contarTempo()
    {
        contadorTempo -= Time.deltaTime;
        if (contadorTempo < 0)
        {
            return true;
        }
        return false;
    }

    public void configTempoParaAcao(float tempoParaAcao)
    {
        this.tempoParaAcao = tempoParaAcao;
        resetContador();
    }    

    public void resetContador()
    {
        contadorTempo = tempoParaAcao;
    }
}
