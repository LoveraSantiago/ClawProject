using UnityEngine;

public class PipelineDeEventoColetado : ConsumidorDeEvento<GameObject>
{
    public PipelineDeEventoColetado configurarLancadorDeEventoColetado(ProdutorDeEvento<GameObject> produtorDeEvento)
    {
        produtorDeEvento.registrarConsumidorDeEvento(this);
        return this;
    }

    public void consumirEvento(GameObject evento)
    {
        
    }
}
