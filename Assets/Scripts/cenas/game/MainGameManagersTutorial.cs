using System.Collections;
using UnityEngine;

public class MainGameManagersTutorial : MainGameManagers
{    
    private MainGameEventosTutorial eventos;

    public MainGameManagersTutorial() 
        : base()
    {
        AbstractLevel levelEscolhido = ContextoEstaticoUtils.level;
        eventos = LevelUtils.getMainGameEventosTutorial(levelEscolhido, this);        
    }

    protected override IEnumerator startLaizy(MainGameDto mainDto, Consumidor<UpdaterManagers> consumidorUpdateManagers)
    {
        yield return coletaveisManager.start();
        yield return new WaitForSeconds(mainDto.DelayInicio);

        maquinaManager.start(inputGame);
        eventos.iniciar();
        //tutorial.iniciar(mainDto, garraManager, maquinaManager);        

        garraManager.start(mainDto.GarraDto);
        consumidorUpdateManagers.consumir(getUpdatables());
    }

    protected override void configurandoEventos()
    {
        //MainGameEventos eventos = new MainGameEventosTutorial(this, tutorial);
        eventos.configurarEventos();
    }
}
