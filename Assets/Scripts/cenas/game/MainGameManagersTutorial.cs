using System.Collections;
using UnityEngine;

public class MainGameManagersTutorial : MainGameManagers
{
    private Tutorial tutorial;

    public MainGameManagersTutorial(MainGameDto mainDto, Consumidor<UpdaterManagers> consumidorUpdateManagers) 
        : base(mainDto, consumidorUpdateManagers)
    {
        AbstractLevel levelEscolhido = ContextoEstaticoUtils.level;
        tutorial = LevelUtils.getTutorial(levelEscolhido);
    }

    protected override IEnumerator startLaizy(MainGameDto mainDto, Consumidor<UpdaterManagers> consumidorUpdateManagers)
    {
        yield return coletaveisManager.start();
        yield return new WaitForSeconds(mainDto.DelayInicio);

        maquinaManager.start(inputGame);

        yield return tutorial.iniciar(mainDto);        

        garraManager.start(mainDto.GarraDto);
        consumidorUpdateManagers.consumir(getUpdatables());
    }
}
