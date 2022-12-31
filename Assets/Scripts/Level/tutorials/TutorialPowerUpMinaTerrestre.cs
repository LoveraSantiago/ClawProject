using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPowerUpMinaTerrestre 
{
    private MainGameDto mainDto;
    private AllGameManagers allGameManagers;
    private AnimacaoTutorial animacaoTutorial;

    public TutorialPowerUpMinaTerrestre(AllGameManagers allGameManagers, MainGameDto mainDto)
    {
        this.mainDto         = mainDto;
        this.allGameManagers = allGameManagers;
        animacaoTutorial     = new AnimacaoTutorial(mainDto.TutorialDto.Animator);
    }

    public void iniciar()
    {
        mainDto.TutorialDto.GoTutorial.SetActive(true);
        prepararTutorialDragPowerUp();
    }

    private void prepararTutorialDragPowerUp()
    {
        //Debug.Log("prepararTutorialCliquePowerUp");
        allGameManagers.getGarraManager().parar();
        allGameManagers.getBotaoLigaDesliga().desligar();
        mainDto.TutorialDto.LblTexto.text = "Mina disponivel!\nArraste para a area de acao\ne solte!";
        animacaoTutorial.playDragAreaPowerUp();
    }
}
