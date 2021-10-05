using UnityEngine;

public class ScrollManager : AcaoBBarPupEscolhido<PowerUpBtnInfo>.ProdutorEvento,
                             AcaoPUpAcionado.ConsumidorEvento,
                             AcaoBotaoPUpVazio.ConsumidorEvento        
{
    private bool isLevelPup;
    private ScrollBottomBarGameScene scrollBottomBar;

    public ScrollManager(GameObject prefabBottomBar)
    {
        scrollBottomBar = new ScrollBottomBarGameScene(prefabBottomBar);
    }

    public void configuradoPeloLevel(AbstractLevel level)
    {
        if(level.isPupLevel())
        {
            isLevelPup = true;
        }
    }

    public void start()
    {
        if (isLevelPup)
        {
            int indicePup = PlayerPrefsPup.recuperarIndicePup();
            for(int contador = 0; contador < 4; contador++)
            {
                scrollBottomBar.simularCliqueBoxAcionado(contador, indicePup);
            }
        }
    }

    void AcaoBotaoPUpVazio.ConsumidorEvento.consumirEvento(int evento)
    {
        if (isLevelPup)
        {
            int indicePup = PlayerPrefsPup.recuperarIndicePup();
            scrollBottomBar.simularCliqueBoxAcionado(evento, indicePup);
        }
        else
        {
            ((AcaoBotaoPUpVazio.ConsumidorEvento)scrollBottomBar).consumirEvento(evento);
        }
    }

    void AcaoPUpAcionado.ConsumidorEvento.consumirEvento(PowerUpInfo evento)
    {
        if (evento.isFinalizar)
        {
            if (isLevelPup)
            {
                int indicePup = PlayerPrefsPup.recuperarIndicePup();
                scrollBottomBar.simularCliqueBoxAcionado(evento.indiceBtn, indicePup);
            }
        }
    }

    ProdutorDeEvento<PowerUpBtnInfo> AcaoBBarPupEscolhido<PowerUpBtnInfo>.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoBBarPupEscolhido<PowerUpBtnInfo>.ProdutorEvento)scrollBottomBar).getProdutorDeEvento();
    }
}
