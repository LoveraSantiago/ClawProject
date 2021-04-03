using UnityEngine;

public class SensorDeColetado : ConsumidorDeEventoTrigger
{
    private ProdutorDeEvento<GameObject> produtorDeEventoDeColetado;

    public SensorDeColetado()
    {
        produtorDeEventoDeColetado = new ProdutorDeEvento<GameObject>();
    }

    public ProdutorDeEvento<GameObject> getProdutorDeEventoDeColetado()
    {
        return produtorDeEventoDeColetado;
    }

    //IMPLEMENTACAO INTERFACE ConsumidorDeEventoTrigger INICIO
    //E ACIONADO QUANDO TRIGGER DETECTA COLISAO COM UM COLETAVEL
    //PRODUZ O EVENTO INICIAL DE COLETAVEL COLETADO NO PIPELINEDEEVENTOCOLETADO
    public void consumirEvento(Collider2D collider2d)
    {
        if (collider2d.gameObject.transform.GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            produtorDeEventoDeColetado.produziuEvento(collider2d.gameObject);
        }
    }
    //IMPLEMENTACAO INTERFACEConsumidorDeEventoTrigger FIM
}
