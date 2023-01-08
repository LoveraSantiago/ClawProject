using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameEventosPowerUpMissilTeleguiado : AbstractMainGameEventosTutorial
{
    private TutorialPowerUpMissilTeleguiado tutorial;
    public MainGameEventosPowerUpMissilTeleguiado(AllGameManagers allGameManagers, TutorialPowerUpMissilTeleguiado tutorial)
       : base(allGameManagers)
    {
        this.tutorial = tutorial;
    }

    public override void iniciar()
    {
        tutorial.iniciar();
    }
}
