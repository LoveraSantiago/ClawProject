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

    private class AdapterConsumidorDeEventoTrigger : ConsumidorDeEventoTrigger
    {
        public void consumirEvento(Collider2D evento){}
    }
}
