using System;
using UnityEngine;

public class DetectorDeTriggers : MonoBehaviour
{
    private Action<Collider2D> actionsConsumerCollider2d;

    private void OnTriggerEnter2D(Collider2D collider2d)
    {
        actionsConsumerCollider2d.Invoke(collider2d);
    }

    public void registrarConsumidorDeTrigger(Action<Collider2D> consumer)
    {
        actionsConsumerCollider2d = consumer;        
    }
}
