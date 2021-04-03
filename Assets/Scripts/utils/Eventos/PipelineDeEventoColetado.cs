using UnityEngine;

public class PipelineDeEventoColetado : ConsumidorDeEvento<GameObject>
{
    private TransformadorDeEvento<GameObject, Sprite> processadorDeColetado;
    private ConsumidorDeEvento<Sprite> consumidorDeSpriteColetado;

    public PipelineDeEventoColetado configLancadorDeEventoColetado(ProdutorDeEvento<GameObject> produtorDeEvento)
    {
        produtorDeEvento.registrarConsumidorDeEvento(this);
        return this;
    }

    public PipelineDeEventoColetado configProcessadorDeColetado(TransformadorDeEvento<GameObject, Sprite> processadorDeColetado)
    {
        this.processadorDeColetado = processadorDeColetado;
        return this;
    }

    public PipelineDeEventoColetado configConsumidorDeSpriteDoColetado(ConsumidorDeEvento<Sprite> consumidorDeSpriteColetado)
    {
        this.consumidorDeSpriteColetado = consumidorDeSpriteColetado;
        return this;
    }

    public void consumirEvento(GameObject evento)
    {
        Sprite sprite = processadorDeColetado.transformarEvento(evento);
        consumidorDeSpriteColetado.consumirEvento(sprite);
    }
}
