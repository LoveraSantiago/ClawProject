using System;
using UnityEngine;

public class ContadorDeTempo 
{
    private float tempoParaAcao;
    private float contadorTempo;

    private Action action;

    public ContadorDeTempo()
    {
    }

    public ContadorDeTempo(Action action)
    {
        tempoParaAcao = float.MaxValue;
        this.action = action;
    }

    public ContadorDeTempo(float tempoEmSegundosParaAcao, Action action)
    {
        configContadorEAction(tempoEmSegundosParaAcao, action);
    }

    public void contarTempo()
    {
        contadorTempo -= Time.deltaTime;
        if (contadorTempo < 0)
        {
            resetContador();
            action.Invoke();
        }
    }

    public void configTempoParaAcao(float tempoParaAcao)
    {
        this.tempoParaAcao = tempoParaAcao;
        resetContador();
    }

    public void configContadorEAction(float tempoParaAcao, Action action)
    {
        this.tempoParaAcao = tempoParaAcao;
        this.action = action;
        resetContador();
    }

    public void resetContador()
    {
        contadorTempo = tempoParaAcao;
    }
}
