using System;
using UnityEngine;

public class ContadorDeTempoData : ContadorDeTempo
{
    private DateTime tempoInicial;

    public void iniciarContagem()
    {
        tempoInicial = DateTime.Now;
        Debug.Log(tempoInicial);
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


}
