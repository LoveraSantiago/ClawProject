using System.Collections;
using UnityEngine;

public class TutorialPowerUpBuracoNegro : AbstractTutorialPowerUp
{
    private bool finalizacaoDisparada;
    private bool emAndamento;
    private AllGameManagers allGameManagers;
    private AnimacaoTutorial animacaoTutorial;
    private MainGameDto mainDto;
    private ProdutorDeEvento<InformacoesColetadoDto> produtorDeEvento;

    public TutorialPowerUpBuracoNegro(AllGameManagers allGameManagers, MainGameDto mainDto)
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
        mainDto.TutorialDto.LblTextoOld.text = "Buraco Negro disponivel!\nAcione o botão power up!";
        animacaoTutorial.playPowerUp();
    }

    private void prepararTutorialInicioPowerUp()
    {
        mainDto.TutorialDto.LblTextoOld.text = "Selecione o 1º coletavel\npara ser atraído pelo\nburaco negro.";
        animacaoTutorial.playParteTextoBaixo();
    }

    private void prepararTutorialColetavel1Acionado()
    {
        mainDto.TutorialDto.LblTextoOld.text = "Selecione o 2º coletavel\npara ser atraído pelo\nburaco negro.";
        animacaoTutorial.playParteTextoBaixo();
    }
    
    private void prepararTutorialColetavel2Acionado()
    {
        mainDto.TutorialDto.LblTextoOld.text = "Selecione o 3º coletavel\npara ser atraído pelo\nburaco negro.";
        animacaoTutorial.playParteTextoBaixo();
    }

    private void prepararTutorialColetavel3Acionado()
    {
        emAndamento = true;
        mainDto.TutorialDto.LblTextoOld.text = "Otimo!\n3 Coletaveis\ncoletados de uma vez!";
        animacaoTutorial.playParteTextoBaixo();
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
        yield return new WaitForSeconds(valorDelay * 3);

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
            mainDto.TutorialDto.LblTextoOld.text = "O tempo de duracao do\nBuraco Negro acabou!";
            animacaoTutorial.playParteTexto();
            ContextoEstaticoUtils.monoBehaviour.StartCoroutine(
                coroutineEncerrarTutorial(mainDto.TutorialDto.DelayFimTutorialExpirado));
        }
    }

    public override void consumirEvento(PowerUpInfoDto evento)
    {
        Debug.Log("Evento estado " + evento.estadoAtual + " andamento " + evento.isEstadoEmAndamento);
        if (evento.isEstadoInicio)
        {
            prepararTutorialInicioPowerUp();
        }
        else if (evento.isEstadoEmAndamento)
        {
            if (evento.estadoAtual == PowerUpEnums.ESTADO.ALVO1_SELECIONADO)
            {
                Debug.Log("Evento coletado 1");
                prepararTutorialColetavel1Acionado();
            }
            else if (evento.estadoAtual == PowerUpEnums.ESTADO.ALVO2_SELECIONADO)
            {
                Debug.Log("Evento coletado 2");
                prepararTutorialColetavel2Acionado();
            }
            else if(evento.estadoAtual == PowerUpEnums.ESTADO.ALVO3_SELECIONADO)
            {
                Debug.Log("Evento coletado 3");
                prepararTutorialColetavel3Acionado();
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

    public override ProdutorDeEvento<InformacoesColetadoDto> getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
