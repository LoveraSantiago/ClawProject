using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPowerUpCoringa : TutorialPowerUp
{
    private AllGameManagers allGameManagers;
    private AnimacaoTutorial animacaoTutorial;
    private MainGameDto mainDto;
    private ProdutorDeEvento<InformacoesColetadoDto> produtorDeEvento;

    public TutorialPowerUpCoringa(AllGameManagers allGameManagers, MainGameDto mainDto)
    {
        this.allGameManagers = allGameManagers;
        this.mainDto         = mainDto;
        animacaoTutorial = new AnimacaoTutorial(mainDto.TutorialDto.Animator);
        produtorDeEvento = new ProdutorDeEvento<InformacoesColetadoDto>();
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
        allGameManagers.getBotaoLigaDesliga().desligar();
        mainDto.TutorialDto.LblTexto.text = "Coringa disponivel!\nAcione o botão power up!";
        animacaoTutorial.playPowerUp();
    }

    void AcaoPowerUpAcionado.ConsumidorEvento.consumirEvento(PowerUpInfoDto evento)
    {
        
    }

    public ProdutorDeEvento<InformacoesColetadoDto> getProdutorDeEvento()
    {
        return produtorDeEvento;
    }

}
