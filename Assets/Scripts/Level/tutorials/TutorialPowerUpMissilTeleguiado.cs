using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPowerUpMissilTeleguiado : TutorialPowerUp,
                                               AcaoPowerUpAcionado.ConsumidorEvento,
                                               AcaoColetado.ProdutorEvento
{
    private bool finalizacaoDisparada;
    private MainGameDto mainDto;
    private AllGameManagers allGameManagers;
    private AnimacaoTutorial animacaoTutorial;
    private ProdutorDeEvento<InformacoesColetadoDto> produtorDeEvento;

    public TutorialPowerUpMissilTeleguiado(AllGameManagers allGameManagers, MainGameDto mainDto)
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
        mainDto.TutorialDto.LblTexto.text = "Missil Teleguiado disponivel!\nAcione o botão power up!";
        animacaoTutorial.playPowerUp();
    }

    private void prepararTutorialInicioPowerUp()
    {
        mainDto.TutorialDto.LblTexto.text = "Clique em um coletavel com alvo piscando!\nO display timer marca a duração.";
        animacaoTutorial.playAlvo();
    }

    private void prepararFimTutorialPupExpirado()
    {
        if (!finalizacaoDisparada)
        {
            allGameManagers.getGarraManager().parar();
            finalizacaoDisparada = true;
            mainDto.TutorialDto.LblTexto.text = "O tempo de duracao do Missil acabou!";
            animacaoTutorial.playParteTexto();
            ContextoEstaticoUtils.monoBehaviour.StartCoroutine(
                coroutineEncerrarTutorial(mainDto.TutorialDto.DelayFimTutorialExpirado));
        }
    }

    private void prepararMensagemPupAcionado()
    {
        mainDto.TutorialDto.LblTexto.text = "Otimo! Alvo selecionado!\nO missil espalha o coletavel especifico.";
        animacaoTutorial.playParteTexto();
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

    private void prepararFimTutorialPupAcionado()
    {
        if (!finalizacaoDisparada)
        {
            allGameManagers.getGarraManager().parar();
            finalizacaoDisparada = true;
            ContextoEstaticoUtils.monoBehaviour.StartCoroutine(
                coroutineEncerrarTutorial(mainDto.TutorialDto.DelayFimTutorialSucesso));
        }
    }

    void AcaoPowerUpAcionado.ConsumidorEvento.consumirEvento(PowerUpInfo evento)
    {
        if (evento.isEstadoInicio)
        {
            prepararTutorialInicioPowerUp();
        }
        else if (evento.isEstadoPreFinalizar)
        {
            prepararMensagemPupAcionado();
        }
        else if (evento.isEstadoFinalizar)
        {
            prepararFimTutorialPupAcionado();
        }
        else if (evento.isEstadoExpirado)
        {
            prepararFimTutorialPupExpirado();
        }
    }

    ProdutorDeEvento<InformacoesColetadoDto> AcaoColetado.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
