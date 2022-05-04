using System.Collections.Generic;
using UnityEngine;

public class ScrollPupsManager : AcaoBBarItemEscolhido<PowerUpBtnInfo>.ProdutorEvento,
                                 AcaoPowerUpAcionado.ConsumidorEvento,
                                 AcaoBotaoPowerUpVazio.ConsumidorEvento
{
    private bool isLevelPup;
    private bool isPupsToLevel;

    private PowerUpsParaLevel pupsToLevel;
    public ScrollPups scrollPups { get; private set; }

    public void configuradoPeloLevel(ScrollPupsDto scrollPupsDto, AbstractLevel level)
    {
        if (LevelUtils.isPupLevel(level))
        {
            isLevelPup = true;
        }
        else if (level.hasPupToLevel())
        {
            pupsToLevel = level.getPupsToLevel();
            isPupsToLevel = true;
        }

        new ColoridorScrollPups().colorir(scrollPupsDto, level.getDicionarioDeCores());
    }

    public void iniciar()
    {
        if (isLevelPup)
        {
            int indicePup = PlayerPrefsPowerUp.recuperarIndicePup();
            for (int contador = 0; contador < 2; contador++)
            {
                //scrollBottomBar.simularCliqueBoxAcionado(contador, indicePup);
            }
        }
        else if (isPupsToLevel)
        {
            for (int contador = 0; contador < pupsToLevel.getQtdBotoes(); contador++)
            {
                //scrollBottomBar.simularCliqueBoxAcionado(contador, pupsToLevel.getPupEntidade(contador));
            }
        }
    }

    void AcaoBotaoPowerUpVazio.ConsumidorEvento.consumirEvento(int evento)
    {
        if (isLevelPup)
        {
            int indicePup = PlayerPrefsPowerUp.recuperarIndicePup();
            //scrollBottomBar.simularCliqueBoxAcionado(evento, indicePup);
        }
        else
        {
            //((AcaoBotaoPowerUpVazio.ConsumidorEvento)scrollBottomBar).consumirEvento(evento);
        }
    }

    void AcaoPowerUpAcionado.ConsumidorEvento.consumirEvento(PowerUpInfo evento)
    {
        if (evento.isFinalizar)
        {
            if (isLevelPup)
            {
                int indicePup = PlayerPrefsPowerUp.recuperarIndicePup();
                //scrollBottomBar.simularCliqueBoxAcionado(evento.indiceBtn, indicePup);
            }
            else if (isPupsToLevel)
            {
                //scrollBottomBar.simularCliqueBoxAcionado(evento.indiceBtn, pupsToLevel.getPupEntidade(evento.indiceBtn));
            }
        }
    }

    ProdutorDeEvento<PowerUpBtnInfo> AcaoBBarItemEscolhido<PowerUpBtnInfo>.ProdutorEvento.getProdutorDeEvento()
    {
        //return ((AcaoBBarItemEscolhido<PowerUpBtnInfo>.ProdutorEvento)scrollBottomBar).getProdutorDeEvento();
        return null;
    }
}
