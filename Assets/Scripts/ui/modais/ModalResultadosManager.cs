using System.Collections;
using UnityEngine;

public class ModalResultadosManager : AcaoColetado.ConsumidorEvento,
                                      AcaoTempoEsgotado.ConsumidorEvento,
                                      AcaoBoardElevadoFim.ConsumidorEvento,
                                      AcaoCacaNiquel.ConsumidorEvento
{    
    private bool mostrandoModal;

    private UIGameDto uiGameDto;
    private CacaNiquelDto cacaNiquelDto;
    private ColetorDeDados coletorDeDados;
    private Loading loading;

    public ModalResultadosManager(MainGameDto mainDto, ColetorDeDados coletorDeDados, Loading loading)
    {
        this.uiGameDto      = mainDto.UiDto;
        this.cacaNiquelDto  = mainDto.MaquinaDto.DisplayColetadosDto.CacaNiquelDto;
        this.coletorDeDados = coletorDeDados;
        this.loading        = loading;
    }             

    private void mostrarModalPontuacao()
    {
        if (!mostrandoModal)
        {
            AbstractLevel levelAtual = ContextoEstaticoUtils.level;
            ResultadoLevelDto resultadoLevels = coletorDeDados.coletar();
            Challenge[] challenges = levelAtual.getChallenges();

            AvaliadorDeChallenge avaliadores = new AvaliadorDeChallenge(resultadoLevels, challenges, levelAtual.challenge);            

            levelAtual.levelConcluido(
                resultadoLevels.tempoPartida, resultadoLevels.resultadosColetaveis.score, 
                avaliadores.challengeUnificado, avaliadores.evolucao);

            ModalFimPontos modal = new ModalFimPontos(uiGameDto.ModalPontosDto, loading);
            modal.passarResultados(resultadoLevels, challenges, avaliadores.resultadoLevel);
            ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(coroutineMostrarModal(modal));
        }
    }

    private void mostrarModalColetados()
    {
        if (!mostrandoModal)
        {
            ModalFimColetaveis modal = ModalFimColetaveis.ofSucess(uiGameDto.ModalColetaveisDto, loading);
            ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(coroutineMostrarModal(modal));
        }
    }

    private void mostrarModalColetadosFail()
    {
        if (!mostrandoModal)
        {
            ModalFimColetaveis modal = ModalFimColetaveis.ofFail(uiGameDto.ModalColetaveisDto, loading);
            ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(coroutineMostrarModal(modal));
        }
    }

    private void mostrarModalCacaNiquelSinglePup(CacaNiquelEventoDto evento)
    {
        if (!mostrandoModal)
        {
            ModalFimCacaNiquelIndividual modal = new ModalFimCacaNiquelIndividual(evento, uiGameDto.ModalCacaNiquelDto, cacaNiquelDto, loading);
            ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(coroutineMostrarModal(modal));
        }
    }   

    private void mostrarModalCacaNiquelAllPups(CacaNiquelEventoDto evento)
    {
        if (!mostrandoModal)
        {
            ModalFimCacaNiquelGeral modal = new ModalFimCacaNiquelGeral(evento, uiGameDto.ModalCacaNiquelDto, cacaNiquelDto, loading);
            ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(coroutineMostrarModal(modal));
        }
    }

    private void mostrarModalOrdemFail(int ordem)
    {
        if (!mostrandoModal)
        {
            ModalFailGame modal = new ModalFailGame(uiGameDto.ModalFailOrdem, loading);
            modal.failOrdem();
            ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(coroutineMostrarModal(modal));
        }
    }    

    private IEnumerator coroutineMostrarModal(AbstractModalFim modal)
    {
        mostrandoModal = true;       
        yield return new WaitForSeconds(uiGameDto.DelayAbrirModal);
        modal.ligar();
    }

    void AcaoColetado.ConsumidorEvento.consumirEvento(InformacoesColetadoDto evento)
    {
        Debug.Log("AcaoColetado chamado");
        InformacoesFimDeJogoDto infoFimDeJogo = evento.infosFimDeJogo;
        if (infoFimDeJogo.fimColetados)
        {           
            mostrarModalPontuacao();
        }
        else if (infoFimDeJogo.erroOrdem)
        {
            mostrarModalOrdemFail(evento.ordem);
        }
        else if (infoFimDeJogo.trincaColetaveis)
        {
            mostrarModalColetados();
        }
        else if (infoFimDeJogo.trincaColetaveisFail)
        {
            mostrarModalColetadosFail();
        }
    }

    void AcaoTempoEsgotado.ConsumidorEvento.consumirEvento(TempoEsgotadoDto evento)
    {
        if (evento.isTimeOver() && !mostrandoModal)
        {
            ModalFailGame modal = new ModalFailGame(uiGameDto.ModalFailOrdem, loading);
            modal.failTimeOver();
            ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(coroutineMostrarModal(modal));
        }
    }

    void AcaoBoardElevadoFim.ConsumidorEvento.consumirEvento(SubidaBoardAcaoFim evento)
    {
        if (evento.isGameOver && !mostrandoModal)
        {   
            ModalFailGame modal = new ModalFailGame(uiGameDto.ModalFailOrdem, loading);
            modal.failElevador();
            ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(coroutineMostrarModal(modal));            
        }
    }    

    void AcaoCacaNiquel.ConsumidorEvento.consumirEvento(CacaNiquelEventoDto evento)
    {
        if (evento.isFinalizado)
        {
            if(evento.isPupGeral())
            {
                mostrarModalCacaNiquelAllPups(evento);
            }
            else if (evento.isPupSingle())
            {
                mostrarModalCacaNiquelSinglePup(evento);
            }
        }
    }
}
