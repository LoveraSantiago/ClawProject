using UnityEngine;

public class ScrollManager : AcaoBotaoPUpVazio.ConsumidorEvento,
                             AcaoBBarPupEscolhido<PowerUpBtnInfo>.ProdutorEvento,
{
    private ScrollBottomBarGameScene scrollBottomBar;

    public ScrollManager(GameObject prefabBottomBar, MonoBehaviour monoBehaviour)
    {
        scrollBottomBar = new ScrollBottomBarGameScene(prefabBottomBar, monoBehaviour);
    }

    void AcaoBotaoPUpVazio.ConsumidorEvento.consumirEvento(int evento)
    {
        ((AcaoBotaoPUpVazio.ConsumidorEvento)scrollBottomBar).consumirEvento(evento);
    }

    ProdutorDeEvento<PowerUpBtnInfo> AcaoBBarPupEscolhido<PowerUpBtnInfo>.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoBBarPupEscolhido<PowerUpBtnInfo>.ProdutorEvento)scrollBottomBar).getProdutorDeEvento();
    }
}
