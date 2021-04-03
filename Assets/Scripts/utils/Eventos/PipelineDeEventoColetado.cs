using UnityEngine;

public class PipelineDeEventoColetado : ConsumidorDeEvento<GameObject>
{
    private TransformadorDeEvento<GameObject, InformacoesColetado> processadorDeColetado;
    private BiConsumidorDeEvento<Sprite, bool> displayImgsConsumidor;
    private ConsumidorDeEvento<int> displayScoreConsumidor;

    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<GameObject> INICIO
    //É CHAMADO QUANDO O SENSOR DE COLETADO É ACIONADO
    //INICIA O PIPELINE DE EVENTOS QUE UM COLETADO PASSA
    public void consumirEvento(GameObject evento)
    {
        InformacoesColetado infoColetado = processadorDeColetado.transformarEvento(evento);
        displayImgsConsumidor.consumirEvento(infoColetado.sprite, infoColetado.resetDisplay);
        displayScoreConsumidor.consumirEvento(infoColetado.score);
    }
    //IMPLEMENTACAO INTERFACE onsumidorDeEvento<GameObject> FIM
        
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

    public PipelineDeEventoColetado configDisplayImgConsumidor(BiConsumidorDeEvento<Sprite, bool> displayImgsConsumidor)
    {
        this.displayImgsConsumidor = displayImgsConsumidor;
        return this;
    }

    public PipelineDeEventoColetado configdisplayScoreConsumidor(ConsumidorDeEvento<int> displayScoreConsumidor)
    {
        this.displayScoreConsumidor = displayScoreConsumidor;
        return this;
    }

}
