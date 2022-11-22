using UnityEngine;
using System.Collections;

public class Tutorial : AcaoColetadoFim.ConsumidorEvento
{
    private readonly int ANIM_COLETAR = Animator.StringToHash("clique-coletar");

    private int contagemColetados;
    private MainGameDto mainDto;

    public void iniciar(MainGameDto mainDto, MaquinaManager maquinaManager)
    {
        this.mainDto = mainDto;
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
        mainDto.TutorialDto.LblTexto.text                    = "Clique para acionar a garra";

        mainDto.TutorialDto.Animator.Play(ANIM_COLETAR);
    }

    void ProdutorConsumidoresDeEvento<ColetadoFimDto>.ConsumidorEvento.consumirEvento(ColetadoFimDto evento)
    {
        contagemColetados++;
        tratarColetadosParteCliqueColetavel();
    }

    private void tratarColetadosParteCliqueColetavel()
    {
        if(contagemColetados == 1)
        {
            mainDto.TutorialDto.LblTexto.text = "Clique para acionar a garra\nMuito bom!";
        }
        else if (contagemColetados == 2)
        {
            mainDto.TutorialDto.LblTexto.text = "Clique para acionar a garra\nFalta só mais um!";
        }
        if(contagemColetados == 3)
        {
            
        }
    }
}
