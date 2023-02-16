using UnityEngine;
using System.Collections;

public class TutorialLevel2 : AcaoBotaoPowerUpVazio.ConsumidorEvento,
                              AcaoPupFromScrollSelecao.ConsumidorEvento,
                              AcaoPowerUpAcionado.ConsumidorEvento,
                              AcaoColetado.ProdutorEvento
{
    private bool finalizacaoDisparada;
    private int contagemColetados;
    private MainGameDto mainDto;
    private AnimacaoTutorial animacaoTutorial;
    private ProdutorDeEvento<InformacoesColetadoDto> produtorDeEvento;

    private AllGameManagers allGameManagers;

    public TutorialLevel2(AllGameManagers allGameManagers, MainGameDto mainDto)
    {
        this.allGameManagers = allGameManagers;
        this.mainDto = mainDto;
        animacaoTutorial = new AnimacaoTutorial(mainDto.TutorialDto.Animator);
        produtorDeEvento = new ProdutorDeEvento<InformacoesColetadoDto>();
    }

    public void iniciar()
    {
        mainDto.TutorialDto.GoTutorial.SetActive(true);
        prepararTutorialPartePowerUp();
    }   

    private void prepararTutorialPartePowerUp()
    {
        allGameManagers.getGarraManager().parar();
        mainDto.TutorialDto.LblTexto.text = "Acione o bot�o power up!\nEsta vazio agora.";

        mainDto.TutorialDto.GoTutorial.SetActive(true);
        allGameManagers.getBotoesPowerUp().reativarPowerUp();
        animacaoTutorial.playPowerUp();
    }

    private void prepararTutorialParteDragPup()
    {
        mainDto.TutorialDto.LblTexto.text = "Arraste e encontre um powerup\ndisponivel, clique nele!\nDica Mini-Asas";
        animacaoTutorial.playDragPowerUp();
    }

    private void prepararTutorialParteAcionarPowerUp()
    {
        mainDto.TutorialDto.LblTexto.text = "Uau Mini-Asas!\nAcione ele!";
        animacaoTutorial.playPowerUp();
    }

    private void prepararTutorialParteJogarPowerUp()
    {
        mainDto.TutorialDto.LblTexto.text = "Mini-Asas servem para um coletavel\nsubir de posição\ndentro da maquina!";
        animacaoTutorial.playParteTexto();
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
            mainDto.TutorialDto.LblTexto.text = "Isso ai!Muibo bom!\nBoa Sorte!";
            animacaoTutorial.playParteTexto();
            ContextoEstaticoUtils.monoBehaviour.StartCoroutine(
                coroutineEncerrarTutorial(mainDto.TutorialDto.DelayFimTutorialSucesso));
        }
    }

    protected IEnumerator coroutineEncerrarTutorial(float valorDelay)
    {
        allGameManagers.getBotoesPowerUp().desativarPowerUp();
        allGameManagers.getGarraManager().parar();
        yield return new WaitForSeconds(valorDelay);

        mainDto.TutorialDto.GoTutorial.SetActive(false);
        InformacoesFimDeJogoDto infoFimDeJogo = InformacoesFimDeJogoDto.ofFimColetados(true);
        InformacoesColetadoDto eventoFim = new InformacoesColetadoDto()
            .addInfoFimDeJogo(infoFimDeJogo);

        //Debug.Log("Criando evento de fim de jogo");
        produtorDeEvento.produziuEvento(eventoFim);
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

    ProdutorDeEvento<InformacoesColetadoDto> AcaoColetado.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
