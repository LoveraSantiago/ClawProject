using UnityEngine;
using System.Collections;

public class TutorialLevel2 : AcaoBotaoPowerUpVazio.ConsumidorEvento,
                              AcaoPupFromScrollSelecao.ConsumidorEvento,
                              AcaoPowerUpAcionado.ConsumidorEvento
{
    private bool finalizacaoDisparada;
    private bool asaSelecionada;
    private MainGameDto mainDto;
    private AnimacaoTutorial animacaoTutorial;    

    private AllGameManagers allGameManagers;

    public TutorialLevel2(AllGameManagers allGameManagers, MainGameDto mainDto)
    {
        this.allGameManagers = allGameManagers;
        this.mainDto = mainDto;
        animacaoTutorial = new AnimacaoTutorialNew(mainDto.TutorialDto);
        mainDto.TutorialDto.LblTextoNew.text = "Clique no botão e selecione um power-up incrível!";
    }

    public void iniciar()
    {        
        prepararTutorialPartePowerUp();        
    }   

    private void prepararTutorialPartePowerUp()
    {
        allGameManagers.getGarraManager().parar();
        mainDto.TutorialDto.LblTextoNew.text = "Clique no botão e selecione um power-up incrível!";

        mainDto.TutorialDto.GoTutorialNew.SetActive(true);
        allGameManagers.getBotoesPowerUp().reativarPowerUp();        
        animacaoTutorial.playPowerUp();
    }

    private void prepararTutorialParteDragPup()
    {
        mainDto.TutorialDto.LblTextoNew.text = "Uau, duas mini-Asas! Encontre ela e clique para selecionar!";        
        animacaoTutorial.playDragAreaPowerUp();
    }

    private void prepararTutorialParteAcionarPowerUp()
    {
        mainDto.TutorialDto.LblTextoNew.text = "Mini-Asas traz o seu coletável para cima do outros. Clique nela!";        
        animacaoTutorial.playPowerUp();
    }

    private void prepararTutorialParteJogarPowerUp()
    {        
        prepararFimTutorial();       
    }

    private void prepararFimTutorialPupExpirado()
    {
        if (!finalizacaoDisparada)
        {
            finalizacaoDisparada = true;
            mainDto.TutorialDto.LblTextoNew.text = "Ah!O tempo de ativação\nda Mini-Asa acabou.";
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
            mainDto.TutorialDto.LblTextoNew.text = "Agora selecione um item! Rápido, cuidado com o tempo!";
            animacaoTutorial.playParteTexto();
            ContextoEstaticoUtils.monoBehaviour.StartCoroutine(
                coroutineEncerrarTutorial(mainDto.TutorialDto.DelayFimTutorialSucesso));
        }
    }

    protected IEnumerator coroutineEncerrarTutorial(float valorDelay)
    {   
        yield return new WaitForSeconds(valorDelay);
        mainDto.TutorialDto.GoTutorialNew.SetActive(false);                
    }
    
    void AcaoBotaoPowerUpVazio.ConsumidorEvento.consumirEvento(int evento)
    {
        prepararTutorialParteDragPup();
    }

    void AcaoPupFromScrollSelecao.ConsumidorEvento.consumirEvento(PowerUpBtnInfoDto evento)
    {        
        if (evento.hasEntidade)
        {
            asaSelecionada = true;
            prepararTutorialParteAcionarPowerUp();
        }
        else if(!asaSelecionada)
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
