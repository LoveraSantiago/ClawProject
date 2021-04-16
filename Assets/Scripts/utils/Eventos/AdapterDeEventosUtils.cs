using System;
using UnityEngine;

public class AdapterDeEventosUtils 
{
    private static ConsumidorDeEventoTrigger adapterConsumidorDeEventoTrigger;
    private static ConsumidorDeEventoCollider adapterConsumidorDeEventoCollider;

    public static ConsumidorDeEventoTrigger getAdapterVazioConsumidorDeEventoTrigger()
    {
        if(adapterConsumidorDeEventoTrigger == null)
        {
            adapterConsumidorDeEventoTrigger = new AdapterConsumidorDeEventoTrigger();
        }
        return adapterConsumidorDeEventoTrigger;
    }

    public static ConsumidorDeEventoCollider getAdapterVazioConsumidorDeEventoCollider()
    {
        if(adapterConsumidorDeEventoCollider == null)
        {
            adapterConsumidorDeEventoCollider = new AdapterConsumidorDeEventoCollider();
        }
        return adapterConsumidorDeEventoCollider;
    }

    //CLASSE QUE IMPLEMENTA CONSUMIDORDEEVENTOTRIGGER DE FORMA VAZIA
    //SERVE PARA SER ASSINALADO A UM CONSUMIDORDEEVENTOTRIGGER COMO GARANTIA DE NUNCA SER NULO    
    private class AdapterConsumidorDeEventoTrigger : ConsumidorDeEventoTrigger
    {
        public void consumirEvento(Collider2D evento){}
    }

    private class AdapterConsumidorDeEventoCollider : ConsumidorDeEventoCollider
    {
        public void consumirEvento(Collision2D evento){}
    }
}
