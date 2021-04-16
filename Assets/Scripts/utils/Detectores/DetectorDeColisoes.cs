using UnityEngine;

public class DetectorDeColisoes : MonoBehaviour
{
    private ConsumidorDeEventoCollider consumidorCollider = AdapterDeEventosUtils.getAdapterVazioConsumidorDeEventoCollider();

    private void Start()
    {
        Debug.Log("Detector de colisoes iniciado");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2d " + consumidorCollider);
        consumidorCollider.consumirEvento(collision);
    }

    public DetectorDeColisoes registrarConsumidorCollision2dOnEnter(ConsumidorDeEventoCollider consumidorCollider)
    {
        this.consumidorCollider = consumidorCollider;
        Debug.Log("Configurado: " + this.consumidorCollider);
        return this;
    }
}
