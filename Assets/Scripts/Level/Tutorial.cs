using UnityEngine;
using System.Collections;

public class Tutorial : AcaoColetadoFim.ConsumidorEvento
{
    private readonly int ANIM_ZOOM    = Animator.StringToHash("zoom");
    private readonly int ANIM_COLETAR = Animator.StringToHash("clique-coletar");

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
        mainDto.TutorialDto.Animator.Play(ANIM_COLETAR);        
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
        ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(coroutinePrepararTutorialPartePowerUp());
    }

    protected IEnumerator coroutinePrepararTutorialPartePowerUp()
    {
        garraManager.parar();
        mainDto.TutorialDto.GoTutorial.SetActive(false);
        mainDto.TutorialDto.LblTexto.text = "Acione o botão power up";
        mainDto.TutorialDto.Animator.Play(ANIM_COLETAR);        
        yield return null;

        mainDto.TutorialDto.GoTutorial.SetActive(true);
        maquinaManager.botoesPowerUp.reativarPowerUp();
        yield return new WaitForSeconds(mainDto.DelayInicio / 2);

        mainDto.TutorialDto.Animator.Play(ANIM_COLETAR);
    }    

    void AcaoColetadoFim.ConsumidorEvento.consumirEvento(ColetadoFimDto evento)
    {
        contagemColetados++;
        tratarColetadosParteCliqueColetavel();
    }
}
