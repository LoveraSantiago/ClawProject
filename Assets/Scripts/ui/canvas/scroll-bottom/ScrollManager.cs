using UnityEngine;

public class ScrollManager : AcaoBBarItemEscolhido<PowerUpBtnInfo>.ProdutorEvento,
                             AcaoPUpAcionado.ConsumidorEvento,
                             AcaoBotaoPUpVazio.ConsumidorEvento        
{
    private bool isLevelPup;
    private bool isPupsToLevel;

    private PowerUpsToLevel pupsToLevel;
    private ScrollBottomBarSceneGame scrollBottomBar;

    public ScrollManager(GameObject prefabBottomBar)
    {
        scrollBottomBar = new ScrollBottomBarSceneGame(prefabBottomBar);
    }

    public void configuradoPeloLevel(AbstractLevel level)
    {
        if(level.isPupLevel())
        {
            isLevelPup = true;
        }
        else if (level.hasPupLevel())
        {
            pupsToLevel = level.getPupsLevel();
            isPupsToLevel = true;
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
        else if(isPupsToLevel)
        {
            for(int contador = 0; contador < 4; contador++)
            {
                scrollBottomBar.simularCliqueBoxAcionado(contador, pupsToLevel.getPupEntidade(contador));
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
            else if (isPupsToLevel)
            {                
                scrollBottomBar.simularCliqueBoxAcionado(evento.indiceBtn, pupsToLevel.getPupEntidade(evento.indiceBtn));
            }
        }
    }

    ProdutorDeEvento<PowerUpBtnInfo> AcaoBBarItemEscolhido<PowerUpBtnInfo>.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoBBarItemEscolhido<PowerUpBtnInfo>.ProdutorEvento)scrollBottomBar).getProdutorDeEvento();
    }
}
