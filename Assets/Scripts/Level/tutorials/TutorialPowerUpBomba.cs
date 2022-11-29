using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPowerUpBomba 
{
    private MainGameDto mainDto;
    private AnimacaoTutorial animacaoTutorial;

    private AllGameManagers allGameManagers;

    public TutorialPowerUpBomba(AllGameManagers allGameManagers, MainGameDto mainDto)
    {
        this.mainDto         = mainDto;
        this.allGameManagers = allGameManagers;
        animacaoTutorial = new AnimacaoTutorial(mainDto.TutorialDto.Animator);
    }

    public void iniciar()
    {
        mainDto.TutorialDto.GoTutorial.SetActive(true);
        prepararTutorialCliquePowerUp();
    }

    private void prepararTutorialCliquePowerUp()
    {
        //Debug.Log("prepararTutorialCliquePowerUp");
        allGameManagers.getGarraManager().parar();
        mainDto.TutorialDto.LblTexto.text = "Bomba disponivel!\nAcione o botão power up!";
        animacaoTutorial.playPowerUp();
    }
}
