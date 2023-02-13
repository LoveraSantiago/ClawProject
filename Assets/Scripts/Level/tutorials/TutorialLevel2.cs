using System.Collections;
using UnityEngine;

public class TutorialLevel2 : AbstractTutorialPowerUp
{
    private bool emAndamento;
    private bool finalizacaoDisparada;
    private AllGameManagers allGameManagers;
    private AnimacaoTutorial animacaoTutorial;
    private MainGameDto mainDto;
    private ProdutorDeEvento<InformacoesColetadoDto> produtorDeEvento;

    public TutorialLevel2(AllGameManagers allGameManagers, MainGameDto mainDto)
    {
        this.allGameManagers = allGameManagers;
        this.mainDto = mainDto;
        animacaoTutorial = new AnimacaoTutorial(mainDto.TutorialDto.Animator);
        produtorDeEvento = new ProdutorDeEvento<InformacoesColetadoDto>();
    }

    public override void iniciar()
    {
        mainDto.TutorialDto.GoTutorial.SetActive(true);
        prepararTutorialCliquePowerUp();
    }

    public override void consumirEvento(PowerUpInfoDto evento)
    {
        if (evento.isEstadoInicio)
        {
            prepararTutorialInicioPowerUp();
        }
        else if (evento.isEstadoPreFinalizar)
        {
            mainDto.TutorialDto.GoTutorial.SetActive(false);
            //prepararMensagemPupAcionado();
        }
        else if (evento.isEstadoFinalizar)
        {
            // prepararFimTutorialPupAcionado();
        }
        else if (evento.isEstadoExpirado)
        {
            // prepararFimTutorialPupExpirado();
            mainDto.TutorialDto.GoTutorial.SetActive(false);
        }
    }

    private void prepararTutorialCliquePowerUp()
    {
        allGameManagers.getGarraManager().parar();
        mainDto.TutorialDto.LblTexto.text = "Uau, power-up!";
        mainDto.TutorialDto.GoTutorial.SetActive(true);
        allGameManagers.getBotoesPowerUp().reativarPowerUp();
        animacaoTutorial.playPowerUp();
    }

    private void prepararTutorialInicioPowerUp()
    {
        mainDto.TutorialDto.LblTexto.text = "Toque para usar a mini asas";
        animacaoTutorial.playParteTexto();
    }

    private void prepararMensagemPupAcionado()
    {
        emAndamento = true;
        mainDto.TutorialDto.LblTexto.text = "Otimo! Mini-Asas acionadas!\nO coletavel esta em uma posi��o melhor.";
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

        mainDto.TutorialDto.GoTutorial.SetActive(false);
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
            mainDto.TutorialDto.LblTexto.text = "O tempo de duracao da Mini-Asa acabou!";
            animacaoTutorial.playParteTexto();
            ContextoEstaticoUtils.monoBehaviour.StartCoroutine(
                coroutineEncerrarTutorial(mainDto.TutorialDto.DelayFimTutorialExpirado));
        }
    }

    public override ProdutorDeEvento<InformacoesColetadoDto> getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
