using System;
using UnityEngine;

public class Ponteiros 
{
    private Transform transformSegundos;
    private Transform transformMinutos;
    private Transform transformHoras;

    public Ponteiros(Transform transformSegundos, Transform transformMinutos, Transform transformHoras)
    {
        this.transformSegundos = transformSegundos;
        this.transformMinutos = transformMinutos;
        this.transformHoras = transformHoras;
    }

    public void andarPonteiros(TimeSpan timeSpan)
    {   
        andarPonteiro(transformSegundos, timeSpan.Seconds, 6);
        andarPonteiro(transformMinutos, timeSpan.Minutes, 6);
        andarPonteiro(transformHoras, timeSpan.Hours, 30);       
    }

    private void andarPonteiro(Transform transform, int tempo, int graus)
    {
        Vector3 acrescimo = -new Vector3(0, 0, graus * tempo);
        Quaternion rotacao = Quaternion.Euler(acrescimo);
        transform.rotation = rotacao;
    }
}
