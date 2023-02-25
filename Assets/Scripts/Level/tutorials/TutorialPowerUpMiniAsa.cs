using System.Collections;
using UnityEngine;

public class TutorialPowerUpMiniAsa : AbstractTutorialPowerUp
{
    private bool emAndamento;
    private bool finalizacaoDisparada;
    private AllGameManagers allGameManagers;
    private AnimacaoTutorial animacaoTutorial;
    private MainGameDto mainDto;
    private ProdutorDeEvento<InformacoesColetadoDto> produtorDeEvento;

    public TutorialPowerUpMiniAsa(AllGameManagers allGameManagers, MainGameDto mainDto)
    {
        this.allGameManagers = allGameManagers;
        this.mainDto = mainDto;
        animacaoTutorial = new AnimacaoTutorialOld(mainDto.TutorialDto);
        produtorDeEvento = new ProdutorDeEvento<InformacoesColetadoDto>();
    }

    public override void iniciar()
    {
        mainDto.TutorialDto.GoTutorialOld.SetActive(true);
        prepararTutorialCliquePowerUp();
    }

    private void prepararTutorialCliquePowerUp()
    {
        //Debug.Log("prepararTutorialCliquePowerUp");
        allGameManagers.getGarraManager().parar();
        allGameManagers.getBotaoLigaDesliga().desligar();
        mainDto.TutorialDto.LblTextoOld.text = "Mini-Asa disponivel!\nAcione o botão power up!";
        animacaoTutorial.playPowerUp();
    }

    private void prepararTutorialInicioPowerUp()
    {
        mainDto.TutorialDto.LblTextoOld.text = "Selecione um coletavel \npara receber Mini-Asas.";
        animacaoTutorial.playParteTexto();
    }

    private void prepararMensagemPupAcionado()
    {
        emAndamento = true;
        mainDto.TutorialDto.LblTextoOld.text = "Otimo! Mini-Asas acionadas!\nO coletavel esta em uma posição melhor.";
        animacaoTutorial.playParteTexto();
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

    protected IEnumerator coroutineEncerrarTutorial(float valorDelay)
    {
        allGameManagers.getBotoesPowerUp().desativarPowerUp();
        allGameManagers.getGarraManager().parar();
        yield return new WaitForSeconds(valorDelay);

        mainDto.TutorialDto.GoTutorialOld.SetActive(false);

        InformacoesFimDeJogoDto infoFimDeJogo = InformacoesFimDeJogoDto.ofFimColetados(true);
        InformacoesColetadoDto eventoFim = new InformacoesColetadoDto()
            .addInfoFimDeJogo(infoFimDeJogo);

        //Debug.Log("Criando evento de fim de jogo");
        produtorDeEvento.produziuEvento(eventoFim);
    }

    private void prepararFimTutorialPupExpirado()
    {
        if (!finalizacaoDisparada && !emAndamento)
        {
            allGameManagers.getGarraManager().parar();
            finalizacaoDisparada = true;
            mainDto.TutorialDto.LblTextoOld.text = "O tempo de duracao da Mini-Asa acabou!";
            animacaoTutorial.playParteTexto();
            ContextoEstaticoUtils.monoBehaviour.StartCoroutine(
                coroutineEncerrarTutorial(mainDto.TutorialDto.DelayFimTutorialExpirado));
        }
    }

    public override void consumirEvento(PowerUpInfoDto evento)
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

    public override ProdutorDeEvento<InformacoesColetadoDto> getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
