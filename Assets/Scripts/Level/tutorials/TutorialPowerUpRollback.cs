using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPowerUpRollback : TutorialPowerUp
{
    private MainGameDto mainDto;
    private ProdutorDeEvento<InformacoesColetadoDto> produtorDeEvento;

    public TutorialPowerUpRollback(AllGameManagers allGameManagers, MainGameDto mainDto)
    {
        this.mainDto = mainDto;
        produtorDeEvento = new ProdutorDeEvento<InformacoesColetadoDto>();
    }

    public void iniciar()
    {
        mainDto.TutorialDto.GoTutorial.SetActive(true);
        //prepararTutorialCliquePowerUp();
    }

    void AcaoPowerUpAcionado.ConsumidorEvento.consumirEvento(PowerUpInfoDto evento)
    { 
    }

    public ProdutorDeEvento<InformacoesColetadoDto> getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
