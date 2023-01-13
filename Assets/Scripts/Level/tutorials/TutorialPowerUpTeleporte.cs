using System.Collections;
using UnityEngine;

public class TutorialPowerUpTeleporte : TutorialPowerUp
{
    private bool finalizacaoDisparada;
    private bool emAndamento;
    private AllGameManagers allGameManagers;
    private AnimacaoTutorial animacaoTutorial;
    private MainGameDto mainDto;
    private ProdutorDeEvento<InformacoesColetadoDto> produtorDeEvento;

    public TutorialPowerUpTeleporte(AllGameManagers allGameManagers, MainGameDto mainDto)
    {
        this.allGameManagers = allGameManagers;
        this.mainDto = mainDto;
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
        mainDto.TutorialDto.LblTexto.text = "Teleporte disponivel!\nAcione o botão power up!";
        animacaoTutorial.playPowerUp();
    }

    private void prepararFimTutorialPupExpirado()
    {
        if (!finalizacaoDisparada && !emAndamento)
        {
            allGameManagers.getGarraManager().parar();
            finalizacaoDisparada = true;
            mainDto.TutorialDto.LblTexto.text = "O tempo de duracao do Teleporte acabou!";
            animacaoTutorial.playParteTexto();
            ContextoEstaticoUtils.monoBehaviour.StartCoroutine(
                coroutineEncerrarTutorial(mainDto.TutorialDto.DelayFimTutorialExpirado));
        }
    }

    private void prepararTutorialInicioPowerUp()
    {
        mainDto.TutorialDto.LblTexto.text = "Selecione o 1º coletavel \npara ser teleportado.";
        animacaoTutorial.playParteTextoBaixo();
    }

    private void prepararTutorialColetavel1Acionado()
    {
        mainDto.TutorialDto.LblTexto.text = "Selecione o 2º coletavel \npara teleportar.\n";
        animacaoTutorial.playParteTextoBaixo();
    }

    private void prepararTutorialColetavel2Acionado()
    {
        emAndamento = true;
        mainDto.TutorialDto.LblTexto.text = "Otimo! Eles trocaram\nde posição!";
        animacaoTutorial.playParteTextoBaixo();
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

    void AcaoPowerUpAcionado.ConsumidorEvento.consumirEvento(PowerUpInfoDto evento)
    {
        if (evento.isEstadoInicio)
        {
            prepararTutorialInicioPowerUp();
        }
        else if (evento.isEstadoEmAndamento)
        {
            if (evento.estadoAtual == PowerUpEnums.ESTADO.ALVO1_SELECIONADO)
            {
                prepararTutorialColetavel1Acionado();
            }
            else if (evento.estadoAtual == PowerUpEnums.ESTADO.ALVO2_SELECIONADO)
            {
                prepararTutorialColetavel2Acionado();
            }
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
