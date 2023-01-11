using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPowerUpIgual : TutorialPowerUp
{
    private AllGameManagers allGameManagers;
    private MainGameDto mainDto;

    public TutorialPowerUpIgual(AllGameManagers allGameManagers, MainGameDto mainDto)
    {
        this.allGameManagers = allGameManagers;
        this.mainDto = mainDto;
    }

    public void iniciar()
    {
        
    }
}
