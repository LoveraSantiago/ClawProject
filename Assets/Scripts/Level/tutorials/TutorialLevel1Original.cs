using UnityEngine;
using System.Collections;

public class TutorialLevel1Original : AcaoColetadoFim.ConsumidorEvento,
                                      AcaoBotaoPowerUpVazio.ConsumidorEvento, 
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

    public TutorialLevel1Original(AllGameManagers allGameManagers, MainGameDto mainDto)
    {
        this.allGameManagers = allGameManagers;
        this.mainDto         = mainDto;
        animacaoTutorial = new AnimacaoTutorialNew(mainDto.TutorialDto);
        produtorDeEvento = new ProdutorDeEvento<InformacoesColetadoDto>();
    }

    public void iniciar()
    {
        mainDto.TutorialDto.GoTutorialNew.SetActive(true);
        prepararTutorialParteCliqueColetavel();
    }

    private void prepararTutorialParteCliqueColetavel()
    {
        allGameManagers.getBotoesPowerUp().desativarPowerUp();
        allGameManagers.getBotaoLigaDesliga().desligar();
        mainDto.TutorialDto.LblTextoNew.text = "Vamos Coletar!\nClique para acionar a garra!";
        animacaoTutorial.playColetar();        
    }    

    private void tratarColetadosParteCliqueColetavel()
    {
        if(contagemColetados == 1)
        {
            mainDto.TutorialDto.LblTextoNew.text = "Muito bom!\nColete mais um item!";
        }
        else if (contagemColetados == 2)
        {
            mainDto.TutorialDto.LblTextoNew.text = "Vamos completar uma trinca!\nFalta s� mais um!";
        }
        if(contagemColetados == 3)
        {
            prepararTutorialPartePowerUp();
        }
    }

    private void prepararTutorialPartePowerUp()
    {
        allGameManagers.getGarraManager().parar();        
        mainDto.TutorialDto.LblTextoNew.text = "Acione o bot�o power up!\nEsta vazio agora.";        

        mainDto.TutorialDto.GoTutorialNew.SetActive(true);
        allGameManagers.getBotoesPowerUp().reativarPowerUp();
        animacaoTutorial.playPowerUp();
    }

    private void prepararTutorialParteDragPup()
    {
        mainDto.TutorialDto.LblTextoNew.text = "Arraste e encontre um powerup\ndisponivel, clique nele!";
        animacaoTutorial.playDragPowerUp();        
    }

    private void prepararTutorialParteAcionarPowerUp()
    {
        mainDto.TutorialDto.LblTextoNew.text = "Acione o bot�o power up!\nAgora esta carregado!";
        animacaoTutorial.playPowerUp();
    }

    private void prepararTutorialParteJogarPowerUp()
    {
        mainDto.TutorialDto.LblTextoNew.text = "Ative o powerup!\nClique para soltar o power up!";
        animacaoTutorial.playColetar();
    }    

    private void prepararFimTutorialPupExpirado()
    {
        if (!finalizacaoDisparada)
        {
            finalizacaoDisparada = true;
            mainDto.TutorialDto.LblTextoNew.text = "ok!O tempo acabou.\nBoa Sorte!";
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
            mainDto.TutorialDto.LblTextoNew.text = "Isso ai!Muibo bom!\nBoa Sorte!";
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

        mainDto.TutorialDto.GoTutorialNew.SetActive(false);
        InformacoesFimDeJogoDto infoFimDeJogo = InformacoesFimDeJogoDto.ofFimColetados(true);
        InformacoesColetadoDto eventoFim = new InformacoesColetadoDto()
            .addInfoFimDeJogo(infoFimDeJogo);

        //Debug.Log("Criando evento de fim de jogo");
        produtorDeEvento.produziuEvento(eventoFim);
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
        else if(evento.isEstadoFinalizar)
        {
            prepararFimTutorial();
        }       
    }

    ProdutorDeEvento<InformacoesColetadoDto> AcaoColetado.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
