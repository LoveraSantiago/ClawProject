using UnityEngine;
using System.Collections;

public class Tutorial : AcaoColetadoFim.ConsumidorEvento,
                        AcaoBotaoPowerUpVazio.ConsumidorEvento, 
                        AcaoPupFromScrollSelecao.ConsumidorEvento
{
    private static readonly int ANIM_PARTE_COLETAR = Animator.StringToHash("clique-coletar");
    private static readonly int ANIM_PARTE_POWERUP = Animator.StringToHash("clique-powerup");
    private static readonly int ANIM_PARTE_DRAGPUP = Animator.StringToHash("drag-powerup");    

    private int contagemColetados;
    private MainGameDto mainDto;
    private GarraManager garraManager;
    private MaquinaManager maquinaManager;

    public void iniciar(MainGameDto mainDto, GarraManager garraManager, MaquinaManager maquinaManager)
    {
        this.mainDto        = mainDto;
        this.garraManager   = garraManager;
        this.maquinaManager = maquinaManager;
        mainDto.TutorialDto.GoTutorial.SetActive(true);
        prepararTutorialParteCliqueColetavel();
    }

    private void prepararTutorialParteCliqueColetavel()
    {
        maquinaManager.botoesPowerUp.desativarPowerUp();
        maquinaManager.botaoLigaDesliga.desligar();
        mainDto.TutorialDto.LblTexto.text = "Vamos Coletar!\nClique para acionar a garra!";
        mainDto.TutorialDto.Animator.Play(ANIM_PARTE_COLETAR);        
    }    

    private void tratarColetadosParteCliqueColetavel()
    {
        if(contagemColetados == 1)
        {
            mainDto.TutorialDto.LblTexto.text = "Muito bom!\nColete mais um item!";
        }
        else if (contagemColetados == 2)
        {
            mainDto.TutorialDto.LblTexto.text = "Vamos completar uma trinca!\nFalta só mais um!";
        }
        if(contagemColetados == 3)
        {
            prepararTutorialPartePowerUp();
        }
    }

    private void prepararTutorialPartePowerUp()
    {
        garraManager.parar();        
        mainDto.TutorialDto.LblTexto.text = "Botão vazio!\nAcione o botão power up";        

        mainDto.TutorialDto.GoTutorial.SetActive(true);
        maquinaManager.botoesPowerUp.reativarPowerUp();        
        mainDto.TutorialDto.Animator.Play(ANIM_PARTE_POWERUP);
    }

    private void prepararTutorialParteDragPup()
    {
        mainDto.TutorialDto.LblTexto.text = "Arraste e encontre um powerup\ndisponivel, clique nele!";
        mainDto.TutorialDto.Animator.Play(ANIM_PARTE_DRAGPUP);
    }

    private void prepararTutorialParteAcionarPowerUp()
    {
        mainDto.TutorialDto.LblTexto.text = "Botão preenchido!\nAcione o botão power up";
        mainDto.TutorialDto.Animator.Play(ANIM_PARTE_POWERUP);
    }

    void AcaoColetadoFim.ConsumidorEvento.consumirEvento(ColetadoFimDto evento)
    {
        contagemColetados++;
        tratarColetadosParteCliqueColetavel();
    }

    void AcaoBotaoPowerUpVazio.ConsumidorEvento.consumirEvento(int evento)
    {
        prepararTutorialParteDragPup();
    }

    void AcaoPupFromScrollSelecao.ConsumidorEvento.consumirEvento(PowerUpBtnInfo evento)
    {
        prepararTutorialParteAcionarPowerUp();
    }
}
