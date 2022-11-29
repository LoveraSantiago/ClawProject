using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameEventosPowerUpBomba : AbstractMainGameEventosTutorial
{
    private TutorialPowerUpBomba tutorial;

    public MainGameEventosPowerUpBomba(AllGameManagers allGameManagers, TutorialPowerUpBomba tutorial) 
        : base(allGameManagers)
    {
        this.tutorial = tutorial;
    }

    public override void iniciar()
    {
        tutorial.iniciar();
    }
}
