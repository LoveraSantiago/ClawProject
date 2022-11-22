using System.Collections;
using UnityEngine;

public class MainGameManagersTutorial : MainGameManagers
{
    private Tutorial tutorial;

    public MainGameManagersTutorial() 
        : base()
    {
        AbstractLevel levelEscolhido = ContextoEstaticoUtils.level;
        tutorial = LevelUtils.getTutorial(levelEscolhido);
    }

    protected override IEnumerator startLaizy(MainGameDto mainDto, Consumidor<UpdaterManagers> consumidorUpdateManagers)
    {
        yield return coletaveisManager.start();
        yield return new WaitForSeconds(mainDto.DelayInicio);

        maquinaManager.start(inputGame);
        tutorial.iniciar(mainDto);        

        garraManager.start(mainDto.GarraDto);
        consumidorUpdateManagers.consumir(getUpdatables());
    }

    protected override void configurandoEventos()
    {
        MainGameEventos eventos = new MainGameEventosTutorial(tutorial);
        eventos.configurarEventos(this);
    }
}
