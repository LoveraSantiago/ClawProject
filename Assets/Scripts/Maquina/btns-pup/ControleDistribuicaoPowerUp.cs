using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDistribuicaoPowerUp 
{
    private bool isLevelPup;
    private bool isPupsToLevel;

    private PowerUpsParaLevel pupsToLevel;

    public void configuradoPeloLevel(AbstractLevel level)
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
    }

    public void iniciar(int qtdBotoes)//TEMPORARIO
    {
        if (isLevelPup)
        {
            int indicePup = PlayerPrefsPowerUp.recuperarIndicePup();
            for (int contador = 0; contador < qtdBotoes; contador++)
            {
                //scrollBottomBar.simularCliqueBoxAcionado(contador, indicePup);
                PowerUpEntidade pupEscolhido = FactoryPowerUpEntidade.getPowerUpFromIndice(indicePup);
                if (pupEscolhido != null)
                {
                    PowerUpBtnInfo pupBtnInfo = new PowerUpBtnInfo(contador, pupEscolhido);
                    //consumidor.consumirEvento(pupBtnInfo);                    
                }
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
}
