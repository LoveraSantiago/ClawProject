using System.Collections;
using UnityEngine;

public class TutorialPowerUpMinaTerrestre : AbstractTutorialPowerUp
{
    private MainGameDto mainDto;
    private AllGameManagers allGameManagers;
    private AnimacaoTutorial animacaoTutorial;
    private ProdutorDeEvento<InformacoesColetadoDto> produtorDeEvento;

    public TutorialPowerUpMinaTerrestre(AllGameManagers allGameManagers, MainGameDto mainDto)
    {
        this.mainDto         = mainDto;
        this.allGameManagers = allGameManagers;
        animacaoTutorial     = new AnimacaoTutorialOld(mainDto.TutorialDto);
        produtorDeEvento = new ProdutorDeEvento<InformacoesColetadoDto>();
    }


    public override void iniciar()
    {
        mainDto.TutorialDto.GoTutorialOld.SetActive(true);
        prepararTutorialDragPowerUp();
    }

    private void prepararTutorialDragPowerUp()
    {
        //Debug.Log("prepararTutorialCliquePowerUp");
        allGameManagers.getGarraManager().parar();
        allGameManagers.getBotaoLigaDesliga().desligar();
        mainDto.TutorialDto.LblTextoOld.text = "Mina disponivel!\nArraste para a area de acao\ne solte!";
        animacaoTutorial.playDragAreaPowerUp();
    }

    private void prepararMensagemPupAcionado()
    {
        mainDto.TutorialDto.LblTextoOld.text = "Otimo! Mina acionada!\nA explosão espalha os coletaveis\nna parte de baixo.";
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

        mainDto.TutorialDto.GoTutorialOld.SetActive(false);
        InformacoesFimDeJogoDto infoFimDeJogo = InformacoesFimDeJogoDto.ofFimColetados(true);
        InformacoesColetadoDto eventoFim = new InformacoesColetadoDto()
            .addInfoFimDeJogo(infoFimDeJogo);
                
        produtorDeEvento.produziuEvento(eventoFim);
    }

    public override void consumirEvento(PowerUpInfoDto evento)
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

    public override ProdutorDeEvento<InformacoesColetadoDto> getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
