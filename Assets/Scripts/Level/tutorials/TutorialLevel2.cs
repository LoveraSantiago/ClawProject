using UnityEngine;
using System.Collections;

public class TutorialLevel2 : AcaoBotaoPowerUpVazio.ConsumidorEvento,
                              AcaoPupFromScrollSelecao.ConsumidorEvento,
                              AcaoPowerUpAcionado.ConsumidorEvento
{
    private bool finalizacaoDisparada;
    private int contagemColetados;
    private MainGameDto mainDto;
    private AnimacaoTutorial animacaoTutorial;    

    private AllGameManagers allGameManagers;

    public TutorialLevel2(AllGameManagers allGameManagers, MainGameDto mainDto)
    {
        this.allGameManagers = allGameManagers;
        this.mainDto = mainDto;
        animacaoTutorial = new AnimacaoTutorial(mainDto.TutorialDto.Animator);
        mainDto.TutorialDto.LblTexto.text = "Clique no botão e selecione um power-up incrível!";
    }

    public void iniciar()
    {        
        prepararTutorialPartePowerUp();
        //prepararTutorialPartePowerUp();
    }   

    private void prepararTutorialPartePowerUp()
    {
        allGameManagers.getGarraManager().parar();
        mainDto.TutorialDto.LblTexto.text = "Clique no botão e selecione um power-up incrível!";

        mainDto.TutorialDto.GoTutorial.SetActive(true);
        allGameManagers.getBotoesPowerUp().reativarPowerUp();
        //animacaoTutorial.playPowerUp();
        animacaoTutorial.playAnimacao(AnimacaoTutorial.TUTORIAL_POWER_UP);
    }

    private void prepararTutorialParteDragPup()
    {
        mainDto.TutorialDto.LblTexto.text = "Uau, duas mini-Asas! Encontre ela e clique para selecionar!";
        //animacaoTutorial.playDragPowerUp();
        animacaoTutorial.playAnimacao(AnimacaoTutorial.TUTORIAL_POWER_UP_ARRASTA);
    }

    private void prepararTutorialParteAcionarPowerUp()
    {
        mainDto.TutorialDto.LblTexto.text = "Mini-Asas traz o seu coletável para cima do outros. Clique nela!";
        //animacaoTutorial.playPowerUp();
        animacaoTutorial.playAnimacao(AnimacaoTutorial.TUTORIAL_POWER_UP);
    }

    private void prepararTutorialParteJogarPowerUp()
    {        
        prepararFimTutorial();
        //mainDto.TutorialDto.LblTexto.text = "Mini-Asas servem para um coletavel\nsubir de posição\ndentro da maquina!2";
        //animacaoTutorial.playParteTexto();
    }

    private void prepararFimTutorialPupExpirado()
    {
        if (!finalizacaoDisparada)
        {
            finalizacaoDisparada = true;
            mainDto.TutorialDto.LblTexto.text = "Ah!O tempo de ativação\nda Mini-Asa acabou.";
            animacaoTutorial.playParteTexto();
            ContextoEstaticoUtils.monoBehaviour.StartCoroutine(
                coroutineEncerrarTutorial(mainDto.TutorialDto.DelayFimTutorialExpirado));
        }
    }

    private void prepararFimTutorial()
    {
        if (!finalizacaoDisparada)
        {
            finalizacaoDisparada = true;
            mainDto.TutorialDto.LblTexto.text = "Agora selecione um item! Rápido, cuidado com o tempo!";
            animacaoTutorial.playParteTexto();
            ContextoEstaticoUtils.monoBehaviour.StartCoroutine(
                coroutineEncerrarTutorial(mainDto.TutorialDto.DelayFimTutorialSucesso));
        }
    }

    protected IEnumerator coroutineEncerrarTutorial(float valorDelay)
    {   
        yield return new WaitForSeconds(valorDelay);
        mainDto.TutorialDto.GoTutorial.SetActive(false);                
    }
    
    void AcaoBotaoPowerUpVazio.ConsumidorEvento.consumirEvento(int evento)
    {
        prepararTutorialParteDragPup();
    }

    void AcaoPupFromScrollSelecao.ConsumidorEvento.consumirEvento(PowerUpBtnInfoDto evento)
    {
        if (evento.hasEntidade)
        {
            prepararTutorialParteAcionarPowerUp();
        }
        else
        {
            prepararTutorialPartePowerUp();
        }
    }

    void AcaoPowerUpAcionado.ConsumidorEvento.consumirEvento(PowerUpInfoDto evento)
    {
        if (evento.isEstadoInicio)
        {
            prepararTutorialParteJogarPowerUp();
        }
        else if (evento.isEstadoExpirado)
        {
            prepararFimTutorialPupExpirado();
        }
        else if (evento.isEstadoFinalizar)
        {
            prepararFimTutorial();
        }
    }    
}
