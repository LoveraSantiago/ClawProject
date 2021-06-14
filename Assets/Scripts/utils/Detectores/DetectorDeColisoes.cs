using UnityEngine;

public class DetectorDeColisoes : MonoBehaviour
{
    private ConsumidorDeEventoCollider consumidorCollider = AdapterDeEventosUtils.getAdapterVazioConsumidorDeEventoCollider();

    private void Start()
    {        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {     
        consumidorCollider.consumir(collision);
    }

    public DetectorDeColisoes registrarConsumidorCollision2dOnEnter(ConsumidorDeEventoCollider consumidorCollider)
    {
        this.consumidorCollider = consumidorCollider;     
        return this;
    }
}
