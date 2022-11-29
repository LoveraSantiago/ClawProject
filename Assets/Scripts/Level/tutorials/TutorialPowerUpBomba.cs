using System.Collections;
using UnityEngine;

public class TutorialPowerUpBomba : AcaoPowerUpAcionado.ConsumidorEvento,
                                    AcaoColetado.ProdutorEvento
{
    private bool finalizacaoDisparada;
    private MainGameDto mainDto;
    private AnimacaoTutorial animacaoTutorial;
    private ProdutorDeEvento<InformacoesColetadoDto> produtorDeEvento;

    private AllGameManagers allGameManagers;

    public TutorialPowerUpBomba(AllGameManagers allGameManagers, MainGameDto mainDto)
    {
        this.mainDto         = mainDto;
        this.allGameManagers = allGameManagers;
        animacaoTutorial = new AnimacaoTutorial(mainDto.TutorialDto.Animator);
        produtorDeEvento = new ProdutorDeEvento<InformacoesColetadoDto>();
    }

    public void iniciar()
    {
        mainDto.TutorialDto.GoTutorial.SetActive(true);
        prepararTutorialCliquePowerUp();
    }

    private void prepararTutorialCliquePowerUp()
    {
        //Debug.Log("prepararTutorialCliquePowerUp");
        allGameManagers.getGarraManager().parar();
        allGameManagers.getBotaoLigaDesliga().desligar();
        mainDto.TutorialDto.LblTexto.text = "Bomba disponivel!\nAcione o botão power up!";
        animacaoTutorial.playPowerUp();
    }

    private void prepararTutorialInicioPowerUp()
    {
        mainDto.TutorialDto.LblTexto.text = "Clique para soltar a bomba!\nO display timer marca a duração.";
        animacaoTutorial.playColetar();
    }

    private void prepararFimTutorialPupExpirado()
    {
        if (!finalizacaoDisparada)
        {
            finalizacaoDisparada = true;
            mainDto.TutorialDto.LblTexto.text = "O tempo de duracao da Bomba acabou!";
            animacaoTutorial.playParteTexto();
            ContextoEstaticoUtils.monoBehaviour.StartCoroutine(coroutineEncerrarTutorial(16));        
        }
    }

    private void prepararMensagemPupAcionado()
    {
        mainDto.TutorialDto.LblTexto.text = "Bomba acionada!\nA explosão espalha os coletaveis.";
        animacaoTutorial.playParteTexto();        
    }

    private void prepararFimTutorialPupAcionado()
    {
        if (!finalizacaoDisparada)
        {
            finalizacaoDisparada = true;            
            ContextoEstaticoUtils.monoBehaviour.StartCoroutine(coroutineEncerrarTutorial(4));
        }
    }

    protected IEnumerator coroutineEncerrarTutorial(int acrescimoDelay)
    {
        allGameManagers.getBotoesPowerUp().desativarPowerUp();
        allGameManagers.getGarraManager().parar();
        yield return new WaitForSeconds(mainDto.DelayInicio * acrescimoDelay);

        mainDto.TutorialDto.GoTutorial.SetActive(false);
        InformacoesFimDeJogoDto infoFimDeJogo = InformacoesFimDeJogoDto.ofFimColetados(true);
        InformacoesColetadoDto eventoFim = new InformacoesColetadoDto()
            .addInfoFimDeJogo(infoFimDeJogo);

        //Debug.Log("Criando evento de fim de jogo");
        produtorDeEvento.produziuEvento(eventoFim);
    }

    void AcaoPowerUpAcionado.ConsumidorEvento.consumirEvento(PowerUpInfo evento)
    {
        if (evento.isInicio)
        {
            prepararTutorialInicioPowerUp();
        }
        else if (evento.isPreFinalizar)
        {
            prepararMensagemPupAcionado();
        }
        else if (evento.isFinalizar)
        {
            prepararFimTutorialPupAcionado();
        }
        else if (evento.isExpirado)
        {
            prepararFimTutorialPupExpirado();
        }
    }

    ProdutorDeEvento<InformacoesColetadoDto> AcaoColetado.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
