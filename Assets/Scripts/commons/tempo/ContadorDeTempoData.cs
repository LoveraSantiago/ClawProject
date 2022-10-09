using System;
using UnityEngine;

public class ContadorDeTempoData : ContadorDeTempo
{
    private DateTime tempoInicial;

    public ContadorDeTempoData()
    {
    }

    public ContadorDeTempoData(DateTime dateTime)
    {
        iniciarContagem(dateTime);
    }

    public void iniciarContagem()
    {
        tempoInicial = DateTime.Now;
        Debug.Log(tempoInicial);
    }

    public void iniciarContagem(DateTime dateTime)
    {
        tempoInicial = dateTime;
    }

    public TimeSpan processarContagem()
    {
        TimeSpan resultado = DateTime.Now - tempoInicial;
        //Debug.Log(resultado);
        return resultado;
    }

    public void pause()
    {
        
    }

    public void continuar()
    {
        
    }

    public bool isNearTimeOver()
    {
        return false;
    }

    public bool isTimeOver()
    {
        return false;
    }

    public float getTempoInicioPartida()
    {
        return 0;
    }
}
