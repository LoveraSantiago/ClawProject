using System.Collections;
using UnityEngine;

public class MainGameManagersTutorial : MainGameManagers
{    
    private MainGameEventosTutorial eventos;

    public MainGameManagersTutorial(MainGameDto mainDto) 
        : base()
    {   
        eventos = LevelUtils.getMainGameEventosTutorial(allGameManagers, mainDto);        
    }

    protected override IEnumerator startLaizy(MainGameDto mainDto, Consumidor<UpdaterManagers> consumidorUpdateManagers)
    {
        yield return allGameManagers.getColetaveisManager().start();
        yield return new WaitForSeconds(mainDto.DelayInicio);

        allGameManagers.getMaquinaManager().start(allGameManagers.getInputGame());
        eventos.iniciar();
        //tutorial.iniciar(mainDto, garraManager, maquinaManager);        

        allGameManagers.getGarraManager().start(mainDto.GarraDto);
        consumidorUpdateManagers.consumir(getUpdatables());
    }

    protected override void configurandoEventos()
    {
        //MainGameEventos eventos = new MainGameEventosTutorial(this, tutorial);
        eventos.configurarEventos();
    }
}
