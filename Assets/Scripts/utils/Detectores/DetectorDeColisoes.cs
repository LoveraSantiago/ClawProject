using UnityEngine;
using System;

public class DetectorDeColisoes : MonoBehaviour
{
    private Action<Collision2D> actionCollisionOnEnter;

    private void OnCollisionEnter2D(Collision2D collision)
    {        
        actionCollisionOnEnter.Invoke(collision);
    }

    public DetectorDeColisoes registrarConsumidorCollision2dOnEnter(Action<Collision2D> actionCollisionOnEnter)
    {        
        this.actionCollisionOnEnter = actionCollisionOnEnter;
        return this;
    }
}
