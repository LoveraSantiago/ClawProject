using UnityEngine;

public class AcaoDeColetado : ConsumidorDeEvento<GameObject>
{    


    public AcaoDeColetado configurarLancadorDeEventoColetado(ProdutorDeEvento<GameObject> produtorDeEvento)
    {
        produtorDeEvento.registrarConsumidorDeEvento(this);
        return this;
    }

    public void consumirEvento(GameObject evento)
    {
        
    }
}
