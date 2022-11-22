using UnityEngine;
using System.Collections;

public class Tutorial : AcaoColetadoFim.ConsumidorEvento,
                        AcaoBotaoPowerUpVazio.ConsumidorEvento
{
    private readonly int ANIM_PARTE_COLETAR = Animator.StringToHash("clique-coletar");
    private readonly int ANIM_PARTE_POWERUP = Animator.StringToHash("clique-powerup");
    private readonly int ANIM_PARTE_DRAGPUP = Animator.StringToHash("drag-powerup");

    private readonly string MSG_TUTORIAL_PARTE1 = "Clique para acionar a garra";

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
        mainDto.TutorialDto.LblTexto.text = MSG_TUTORIAL_PARTE1;
        mainDto.TutorialDto.Animator.Play(ANIM_PARTE_COLETAR);        
    }    

    private void tratarColetadosParteCliqueColetavel()
    {
        if(contagemColetados == 1)
        {
            mainDto.TutorialDto.LblTexto.text = string.Format("{0} {1}", MSG_TUTORIAL_PARTE1, "\nMuito bom!");
        }
        else if (contagemColetados == 2)
        {
            mainDto.TutorialDto.LblTexto.text = string.Format("{0} {1}", MSG_TUTORIAL_PARTE1, "\nFalta só mais um!");
        }
        if(contagemColetados == 3)
        {
            prepararTutorialPartePowerUp();
        }
    }

    private void prepararTutorialPartePowerUp()
    {
        garraManager.parar();        
        mainDto.TutorialDto.LblTexto.text = "Acione o botão power up";        

        mainDto.TutorialDto.GoTutorial.SetActive(true);
        maquinaManager.botoesPowerUp.reativarPowerUp();        
        mainDto.TutorialDto.Animator.Play(ANIM_PARTE_POWERUP);
    }

    private void prepararTutorialParteDragPup()
    {
        mainDto.TutorialDto.LblTexto.text = "Arraste e encontre um powerup\ndisponivel";
        mainDto.TutorialDto.Animator.Play(ANIM_PARTE_DRAGPUP);
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
}
