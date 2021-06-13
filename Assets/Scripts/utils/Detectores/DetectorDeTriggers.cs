using UnityEngine;

public class DetectorDeTriggers : MonoBehaviour
{
    private ConsumidorDeEventoTrigger consumidorDeTrigger = AdapterDeEventosUtils.getAdapterVazioConsumidorDeEventoTrigger();

    private void OnTriggerEnter2D(Collider2D collider2d)
    {
        consumidorDeTrigger.consumir(collider2d);
    }

    public void registrarConsumidorDeTrigger(ConsumidorDeEventoTrigger consumidorDeTrigger)
    {
        this.consumidorDeTrigger = consumidorDeTrigger;        
    }    
}
