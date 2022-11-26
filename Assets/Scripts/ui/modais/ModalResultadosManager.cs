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
    private SomModais somModais;

    public ModalResultadosManager(MainGameDto mainDto, ColetorDeDados coletorDeDados, SomModais somModais)
    {
        this.uiGameDto      = mainDto.UiDto;
        this.cacaNiquelDto  = mainDto.MaquinaDto.DisplayColetadosDto.CacaNiquelDto;
        this.coletorDeDados = coletorDeDados;        
        this.somModais      = somModais;
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

            ModalFimPontos modal = new ModalFimPontos(uiGameDto.ModalPontosDto, somModais);
            modal.passarResultados(resultadoLevels, challenges, avaliadores.resultadoLevel);
            ContextoEstaticoUtils.monoBehaviour.StartCoroutine(coroutineMostrarModal(modal));
        }
    }

    private void mostrarModalColetados()
    {
        if (!mostrandoModal)
        {
            ModalFimColetaveis modal = ModalFimColetaveis.ofSucess(uiGameDto.ModalColetaveisDto);
            ContextoEstaticoUtils.monoBehaviour.StartCoroutine(coroutineMostrarModal(modal));
        }
    }

    private void mostrarModalColetadosFail()
    {
        if (!mostrandoModal)
        {
            ModalFimColetaveis modal = ModalFimColetaveis.ofFail(uiGameDto.ModalColetaveisDto);
            ContextoEstaticoUtils.monoBehaviour.StartCoroutine(coroutineMostrarModal(modal));
        }
    }

    private void mostrarModalCacaNiquelSinglePup(CacaNiquelEventoDto evento)
    {
        if (!mostrandoModal)
        {
            ModalFimCacaNiquelIndividual modal = new ModalFimCacaNiquelIndividual(evento, uiGameDto.ModalCacaNiquelDto, cacaNiquelDto, somModais);
            ContextoEstaticoUtils.monoBehaviour.StartCoroutine(coroutineMostrarModal(modal));
        }
    }   

    private void mostrarModalCacaNiquelAllPups(CacaNiquelEventoDto evento)
    {
        if (!mostrandoModal)
        {
            ModalFimCacaNiquelGeral modal = new ModalFimCacaNiquelGeral(evento, uiGameDto.ModalCacaNiquelDto, cacaNiquelDto);
            ContextoEstaticoUtils.monoBehaviour.StartCoroutine(coroutineMostrarModal(modal));
        }
    }

    private void mostrarModalOrdemFail(int ordem)
    {
        if (!mostrandoModal)
        {
            ModalFailGame modal = new ModalFailGame(uiGameDto.ModalFailOrdem);
            modal.failOrdem();
            ContextoEstaticoUtils.monoBehaviour.StartCoroutine(coroutineMostrarModal(modal));
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
        //Debug.Log("AcaoColetado chamado");
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
            ModalFailGame modal = new ModalFailGame(uiGameDto.ModalFailOrdem);
            modal.failTimeOver();
            ContextoEstaticoUtils.monoBehaviour.StartCoroutine(coroutineMostrarModal(modal));
        }
    }

    void AcaoBoardElevadoFim.ConsumidorEvento.consumirEvento(SubidaBoardAcaoFim evento)
    {
        if (evento.isGameOver && !mostrandoModal)
        {   
            ModalFailGame modal = new ModalFailGame(uiGameDto.ModalFailOrdem);
            modal.failElevador();
            ContextoEstaticoUtils.monoBehaviour.StartCoroutine(coroutineMostrarModal(modal));            
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
