using UnityEngine;

public class ScrollManager : AcaoBBarItemEscolhido<PowerUpBtnInfo>.ProdutorEvento,
                             AcaoPowerUpAcionado.ConsumidorEvento,
                             AcaoBotaoPowerUpVazio.ConsumidorEvento        
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
        if(LevelUtils.isPupLevel(level))
        {
            isLevelPup = true;
        }
        else if (level.hasPupToLevel())
        {
            pupsToLevel = level.getPupsToLevel();
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

    void AcaoBotaoPowerUpVazio.ConsumidorEvento.consumirEvento(int evento)
    {
        if (isLevelPup)
        {
            int indicePup = PlayerPrefsPup.recuperarIndicePup();
            scrollBottomBar.simularCliqueBoxAcionado(evento, indicePup);
        }
        else
        {
            ((AcaoBotaoPowerUpVazio.ConsumidorEvento)scrollBottomBar).consumirEvento(evento);
        }
    }

    void AcaoPowerUpAcionado.ConsumidorEvento.consumirEvento(PowerUpInfo evento)
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
