using UnityEngine;
using System.Collections;

public class Tutorial : AcaoColetadoFim.ConsumidorEvento
{
    private readonly int ANIM_COLETAR = Animator.StringToHash("clique-coletar");
    private readonly string MSG_TUTORIAL_PARTE1 = "Clique para acionar a garra";

    private int contagemColetados;
    private MainGameDto mainDto;
    private GarraManager garraManager;

    public void iniciar(MainGameDto mainDto, GarraManager garraManager, MaquinaManager maquinaManager)
    {
        this.mainDto = mainDto;
        this.garraManager = garraManager;
        mainDto.TutorialDto.GoTutorial.SetActive(true);
        prepararTutorialParteCliqueColetavel(maquinaManager);
    }

    private void prepararTutorialParteCliqueColetavel(MaquinaManager maquinaManager)
    {
        maquinaManager.botoesPowerUp.desativarPowerUp();
        maquinaManager.botaoLigaDesliga.desligar();
        colocarNaPosicaoCliqueColetavel();                
    }

    private void colocarNaPosicaoCliqueColetavel()
    {
        mainDto.TutorialDto.TranformGoTutorial.localPosition = new Vector3(0.48f, 0, 0);
        mainDto.TutorialDto.TransformPonto.localPosition     = new Vector3(-0.45f, 0.54f, 0);
        mainDto.TutorialDto.TransformMao.localPosition       = Vector3.zero;
        mainDto.TutorialDto.TransformText.localPosition      = new Vector3(0.07f, -1.1f, 0);
        mainDto.TutorialDto.LblTexto.text                    = MSG_TUTORIAL_PARTE1;

        mainDto.TutorialDto.Animator.Play(ANIM_COLETAR);
    }

    void AcaoColetadoFim.ConsumidorEvento.consumirEvento(ColetadoFimDto evento)
    {
        contagemColetados++;
        tratarColetadosParteCliqueColetavel();
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
            garraManager.parar();
        }
    }
}
