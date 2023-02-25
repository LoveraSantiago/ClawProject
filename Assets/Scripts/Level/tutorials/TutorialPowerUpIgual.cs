using System.Collections;
using UnityEngine;

public class TutorialPowerUpIgual : AbstractTutorialPowerUp
{
    private bool finalizacaoDisparada;
    private bool emAndamento;
    private AllGameManagers allGameManagers;
    private AnimacaoTutorial animacaoTutorial;
    private MainGameDto mainDto;
    private ProdutorDeEvento<InformacoesColetadoDto> produtorDeEvento;

    public TutorialPowerUpIgual(AllGameManagers allGameManagers, MainGameDto mainDto)
    {
        this.allGameManagers = allGameManagers;
        this.mainDto         = mainDto;
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
        mainDto.TutorialDto.LblTextoOld.text = "Igual disponivel!\nAcione o botão power up!";
        animacaoTutorial.playPowerUp();
    }

    private void prepararFimTutorialPupExpirado()
    {
        if (!finalizacaoDisparada && !emAndamento)
        {
            allGameManagers.getGarraManager().parar();
            finalizacaoDisparada = true;
            mainDto.TutorialDto.LblTextoOld.text = "O tempo de duracao do Igual acabou!";
            animacaoTutorial.playParteTexto();
            ContextoEstaticoUtils.monoBehaviour.StartCoroutine(
                coroutineEncerrarTutorial(mainDto.TutorialDto.DelayFimTutorialExpirado));
        }
    }

    private void prepararTutorialInicioPowerUp()
    {
        mainDto.TutorialDto.LblTextoOld.text = "Selecione o 1º coletavel\npara ser igualado.";
        animacaoTutorial.playParteTextoBaixo();
    }
    
    private void prepararTutorialColetavel1Acionado()
    {
        mainDto.TutorialDto.LblTextoOld.text = "Selecione o 2º coletavel\npara igualar.\n";
        animacaoTutorial.playParteTextoBaixo();
    }
    
    private void prepararTutorialColetavel2Acionado()
    {
        emAndamento = true;
        mainDto.TutorialDto.LblTextoOld.text = "Otimo!\nAgora você tem 2 coletaveis iguais!";
        animacaoTutorial.playParteTextoBaixo();
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

    public override void consumirEvento(PowerUpInfoDto evento)
    {        
        if (evento.isEstadoInicio)
        {
            prepararTutorialInicioPowerUp();
        }
        else if (evento.isEstadoEmAndamento)
        {
            if(evento.estadoAtual == PowerUpEnums.ESTADO.ALVO1_SELECIONADO)
            {
                prepararTutorialColetavel1Acionado();
            }
            else if(evento.estadoAtual == PowerUpEnums.ESTADO.ALVO2_SELECIONADO)
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

    public override ProdutorDeEvento<InformacoesColetadoDto> getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
