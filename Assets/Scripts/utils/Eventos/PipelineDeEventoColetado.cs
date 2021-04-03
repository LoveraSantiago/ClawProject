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

    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<GameObject> INICIO
    //É CHAMADO QUANDO O SENSOR DE COLETADO É ACIONADO
    //INICIA O PIPELINE DE EVENTOS QUE UM COLETADO PASSA
    public void consumirEvento(GameObject evento)
    {
        Sprite sprite = processadorDeColetado.transformarEvento(evento);
        consumidorDeSpriteColetado.consumirEvento(sprite);
    }
    //IMPLEMENTACAO INTERFACE onsumidorDeEvento<GameObject> FIM
}
