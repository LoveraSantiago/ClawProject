using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPowerUpRollback : AbstractTutorialPowerUp
{
    private bool emAndamento;
    private bool finalizacaoDisparada;
    private AllGameManagers allGameManagers;
    private AnimacaoTutorial animacaoTutorial;
    private MainGameDto mainDto;
    private ProdutorDeEvento<InformacoesColetadoDto> produtorDeEvento;

    public TutorialPowerUpRollback(AllGameManagers allGameManagers, MainGameDto mainDto)
    {
        this.allGameManagers = allGameManagers;
        this.mainDto = mainDto;
        animacaoTutorial = new AnimacaoTutorial(mainDto.TutorialDto.Animator);
        produtorDeEvento = new ProdutorDeEvento<InformacoesColetadoDto>();
    }

    public override void iniciar()
    {
        allGameManagers.getGarraManager().parar();
        mainDto.TutorialDto.GoTutorial.SetActive(true);
        prepararTutorialCliquePowerUp();
    }

    private void prepararTutorialCliquePowerUp()
    {
        //Debug.Log("prepararTutorialCliquePowerUp");
        allGameManagers.getBotaoLigaDesliga().desligar();
        mainDto.TutorialDto.LblTexto.text = "Rollback disponivel!\nAcione o botão power up!";
        animacaoTutorial.playPowerUp();
    }

    private void prepararTutorialInicioPowerUp()
    {
        mainDto.TutorialDto.LblTexto.text = "Selecione um coletado \npara ser devolvido à\nmaquina.";
        animacaoTutorial.playAlvoColetado();
    }

    private void prepararFimTutorialPupExpirado()
    {
        if (!finalizacaoDisparada && !emAndamento)
        {
            allGameManagers.getGarraManager().parar();
            finalizacaoDisparada = true;
            mainDto.TutorialDto.LblTexto.text = "O tempo de duracao do Rollback acabou!";
            animacaoTutorial.playParteTexto();
            ContextoEstaticoUtils.monoBehaviour.StartCoroutine(
                coroutineEncerrarTutorial(mainDto.TutorialDto.DelayFimTutorialExpirado));
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

    public override void consumirEvento(PowerUpInfoDto evento)
    {
        if (evento.isEstadoInicio)
        {
            prepararTutorialInicioPowerUp();
        }
        else if (evento.isEstadoExpirado)
        {
            prepararFimTutorialPupExpirado();
        }
    }

    public override ProdutorDeEvento<InformacoesColetadoDto> getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
