using UnityEngine;

public class PipelineDeEventoColetado : ConsumidorDeEvento<GameObject>
{
    private TransformadorDeEvento<GameObject, InformacoesColetado> processadorDeColetado;
    private ConsumidorDeEvento<Sprite> consumidorDeSpriteColetado;
    private ConsumidorDeEvento<int> consumidorDeScore;

    public PipelineDeEventoColetado configLancadorDeEventoColetado(ProdutorDeEvento<GameObject> produtorDeEvento)
    {
        produtorDeEvento.registrarConsumidorDeEvento(this);
        return this;
    }

    public PipelineDeEventoColetado configProcessadorDeColetado(TransformadorDeEvento<GameObject, InformacoesColetado> processadorDeColetado)
    {
        this.processadorDeColetado = processadorDeColetado;
        return this;
    }

    public PipelineDeEventoColetado configConsumidorDeSpriteDoColetado(ConsumidorDeEvento<Sprite> consumidorDeSpriteColetado)
    {
        this.consumidorDeSpriteColetado = consumidorDeSpriteColetado;
        return this;
    }

    public PipelineDeEventoColetado configConsumidorDeScore(ConsumidorDeEvento<int> consumidorDeEscore)
    {
        this.consumidorDeScore = consumidorDeEscore;
        return this;
    }

    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<GameObject> INICIO
    //É CHAMADO QUANDO O SENSOR DE COLETADO É ACIONADO
    //INICIA O PIPELINE DE EVENTOS QUE UM COLETADO PASSA
    public void consumirEvento(GameObject evento)
    {
        InformacoesColetado infoColetado = processadorDeColetado.transformarEvento(evento);
        consumidorDeSpriteColetado.consumirEvento(infoColetado.sprite);
        consumidorDeScore.consumirEvento(infoColetado.score);
    }
    //IMPLEMENTACAO INTERFACE onsumidorDeEvento<GameObject> FIM
}
