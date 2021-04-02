using UnityEngine;

public class DetectorDeTriggers : MonoBehaviour
{
    private ConsumidorDeTrigger consumidorDeTrigger;

    private void OnTriggerEnter2D(Collider2D collider2d)
    {
        consumidorDeTrigger.consumirEvento(collider2d);
    }

    public void registrarConsumidorDeTrigger(ConsumidorDeTrigger consumidorDeTrigger)
    {
        this.consumidorDeTrigger = consumidorDeTrigger;        
    }
}
