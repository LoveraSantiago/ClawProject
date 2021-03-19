using System;
using UnityEngine;

public class ProdutorDeEvento<T>
{
    private Action<T> consumidorDeEvento;

    public void produziuEvento(T evento)
    {
        consumidorDeEvento.Invoke(evento);
    }

    public void registrarConsumidorDeEvento(Action<T> consumidorDeEvento)
    {
        //Debug.Log("Registrado consumidor de evento");
        if (this.consumidorDeEvento != null)
        {
            Debug.LogError("ERRO!!!! - Mais de um consumidor de evento sendo registrado.");
        }
        this.consumidorDeEvento = consumidorDeEvento;
    }
}
