using UnityEngine;

public class AdapterDeEventosUtils 
{
    private static ConsumidorDeEventoTrigger adapterConsumidorDeEventoTrigger;

    public static ConsumidorDeEventoTrigger getAdapterVazioConsumidorDeEventoTrigger()
    {
        if(adapterConsumidorDeEventoTrigger == null)
        {
            adapterConsumidorDeEventoTrigger = new AdapterConsumidorDeEventoTrigger();
        }
        return adapterConsumidorDeEventoTrigger;
    }

    //CLASSE QUE IMPLEMENTA CONSUMIDORDEEVENTOTRIGGER DE FORMA VAZIA
    //SERVE PARA SER ASSINALADO A UM CONSUMIDORDEEVENTOTRIGGER COMO GARANTIA DE NUNCA SER NULO    
    private class AdapterConsumidorDeEventoTrigger : ConsumidorDeEventoTrigger
    {
        public void consumirEvento(Collider2D evento){}
    }
}
