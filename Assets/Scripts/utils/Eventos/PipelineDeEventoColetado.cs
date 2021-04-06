using UnityEngine;

public class PipelineDeEventoColetado : ConsumidorDeEvento<GameObject>
{
    private TransformadorDeEvento<GameObject, InformacoesColetado> processadorDeColetado;
    private BiConsumidorDeEvento<Sprite, bool> displayImgsConsumidor;
    private ConsumidorDeEvento<int> displayScoreConsumidor;
    private ConsumidorDeEvento<InformacoesColetado> consumidorInformacoesColetado;

    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<GameObject> INICIO
    //� CHAMADO QUANDO O SENSOR DE COLETADO � ACIONADO
    //INICIA O PIPELINE DE EVENTOS QUE UM COLETADO PASSA
    public void consumirEvento(GameObject evento)
    {
        InformacoesColetado infoColetado = processadorDeColetado.transformarEvento(evento);
        displayImgsConsumidor.consumirEvento(infoColetado.sprite, infoColetado.resetDisplay);
        displayScoreConsumidor.consumirEvento(infoColetado.score);
    }
    //IMPLEMENTACAO INTERFACE onsumidorDeEvento<GameObject> FIM
        
    public PipelineDeEventoColetado configStep1LancadorDeEventoColetado(ProdutorDeEvento<GameObject> produtorDeEvento)
    {
        produtorDeEvento.registrarConsumidorDeEvento(this);
        return this;
    }

    public PipelineDeEventoColetado configStep2ProcessadorDeColetado(TransformadorDeEvento<GameObject, InformacoesColetado> processadorDeColetado)
    {
        this.processadorDeColetado = processadorDeColetado;
        return this;
    }

    public PipelineDeEventoColetado configStep3DisplayImgConsumidor(BiConsumidorDeEvento<Sprite, bool> displayImgsConsumidor)
    {
        this.displayImgsConsumidor = displayImgsConsumidor;
        return this;
    }

    public PipelineDeEventoColetado configStep4displayScoreConsumidor(ConsumidorDeEvento<int> displayScoreConsumidor)
    {
        this.displayScoreConsumidor = displayScoreConsumidor;
        return this;
    }

    public PipelineDeEventoColetado configStep5displayScoreConsumidor(ConsumidorDeEvento<InformacoesColetado> consumidorInformacoesColetado)
    {
        this.consumidorInformacoesColetado = consumidorInformacoesColetado;
        return this;
    }

}
