using System.Collections;
using UnityEngine;

public class TutorialPowerUpMinaTerrestre : TutorialPowerUp
{
    private MainGameDto mainDto;
    private AllGameManagers allGameManagers;
    private AnimacaoTutorial animacaoTutorial;
    private ProdutorDeEvento<InformacoesColetadoDto> produtorDeEvento;

    public TutorialPowerUpMinaTerrestre(AllGameManagers allGameManagers, MainGameDto mainDto)
    {
        this.mainDto         = mainDto;
        this.allGameManagers = allGameManagers;
        animacaoTutorial     = new AnimacaoTutorial(mainDto.TutorialDto.Animator);
        produtorDeEvento = new ProdutorDeEvento<InformacoesColetadoDto>();
    }


    public void iniciar()
    {
        mainDto.TutorialDto.GoTutorial.SetActive(true);
        prepararTutorialDragPowerUp();
    }

    private void prepararTutorialDragPowerUp()
    {
        //Debug.Log("prepararTutorialCliquePowerUp");
        allGameManagers.getGarraManager().parar();
        allGameManagers.getBotaoLigaDesliga().desligar();
        mainDto.TutorialDto.LblTexto.text = "Mina disponivel!\nArraste para a area de acao\ne solte!";
        animacaoTutorial.playDragAreaPowerUp();
    }

    private void prepararMensagemPupAcionado()
    {
        mainDto.TutorialDto.LblTexto.text = "Otimo! Mina acionada!\nA explosão espalha os coletaveis\nna parte de baixo.";
        animacaoTutorial.playParteTexto();
    }


    private void prepararFimTutorialPupAcionado()
    {   
        ContextoEstaticoUtils.monoBehaviour.StartCoroutine(
                coroutineEncerrarTutorial(mainDto.TutorialDto.DelayFimTutorialSucesso));
        
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
                
        produtorDeEvento.produziuEvento(eventoFim);
    }

    void AcaoPowerUpAcionado.ConsumidorEvento.consumirEvento(PowerUpInfoDto evento)
    {
        if (evento.isEstadoInicio)
        {
            animacaoTutorial.playIdle();
        }
        else if (evento.isEstadoPreFinalizar)
        {
            prepararMensagemPupAcionado();
        }
        else if (evento.isEstadoFinalizar)
        {
            prepararFimTutorialPupAcionado();
        }
    }

    ProdutorDeEvento<InformacoesColetadoDto> AcaoColetado.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
