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

    public ModalResultadosManager(UIGameDto uiGameDto, CacaNiquelDto cacaNiquelDto, ColetorDeDados coletorDeDados)
    {
        this.uiGameDto = uiGameDto;
        this.cacaNiquelDto  = cacaNiquelDto;
        this.coletorDeDados = coletorDeDados;
    }             

    private void mostrarModalPontuacao()
    {
        if (!mostrandoModal)
        {
            AbstractLevel levelAtual = ContextoEstaticoUtils.level;
            ResultadoLevelsDto resultadoLevels = coletorDeDados.coletar();

            Avaliadores avaliadores = new Avaliadores();
            avaliadores.avaliar(resultadoLevels, levelAtual.getChallenges(), levelAtual.challenge);

            levelAtual.levelConcluido(resultadoLevels.tempoPartida, resultadoLevels.score, avaliadores.challengeUnificado);

            ModalFimPontos modal = new ModalFimPontos(uiGameDto.ModalPontosDto);
            modal.passarResultados(resultadoLevels, avaliadores.resultadoLevel);
            ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(coroutineMostrarModal(modal));
        }
    }

    private void mostrarModalColetados()
    {
        if (!mostrandoModal)
        {
            ModalFimColetaveis modal = ModalFimColetaveis.ofSucess(uiGameDto.ModalColetaveisDto);
            ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(coroutineMostrarModal(modal));
        }
    }

    private void mostrarModalColetadosFail()
    {
        if (!mostrandoModal)
        {
            ModalFimColetaveis modal = ModalFimColetaveis.ofFail(uiGameDto.ModalColetaveisDto);
            ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(coroutineMostrarModal(modal));
        }
    }

    private void mostrarModalCacaNiquelSinglePup(CacaNiquelEventoDto evento)
    {
        if (!mostrandoModal)
        {
            ModalFimCacaNiquelIndividual modal = new ModalFimCacaNiquelIndividual(evento, uiGameDto.ModalCacaNiquelDto, cacaNiquelDto);
            ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(coroutineMostrarModal(modal));
        }
    }   

    private void mostrarModalCacaNiquelAllPups(CacaNiquelEventoDto evento)
    {
        if (!mostrandoModal)
        {
            ModalFimCacaNiquelGeral modal = new ModalFimCacaNiquelGeral(evento, uiGameDto.ModalCacaNiquelDto, cacaNiquelDto);
            ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(coroutineMostrarModal(modal));
        }
    }

    private void mostrarModalOrdemFail(int ordem)
    {
        ModalFailOrdem modal = new ModalFailOrdem(uiGameDto.ModalFailOrdem);
        ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(coroutineMostrarModal(modal));
    }    

    private IEnumerator coroutineMostrarModal(AbstractModalFim modal)
    {
        mostrandoModal = true;       
        yield return new WaitForSeconds(uiGameDto.DelayAbrirModal);
        modal.ligar();
    }

    void AcaoColetado.ConsumidorEvento.consumirEvento(InformacoesColetadoDto evento)
    {  
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
        if (evento.isTimeOver())
        {
            //CRIAR MODAL TEMPO ESGOTADO
            //CRIAR MODAL TEMPO ESGOTADO
            //CRIAR MODAL TEMPO ESGOTADO
            //CRIAR MODAL TEMPO ESGOTADO
            //CRIAR MODAL TEMPO ESGOTADO
            //CRIAR MODAL TEMPO ESGOTADO
            //CRIAR MODAL TEMPO ESGOTADO
            //CRIAR MODAL TEMPO ESGOTADO
            //CRIAR MODAL TEMPO ESGOTADO
            //CRIAR MODAL TEMPO ESGOTADO
            //CRIAR MODAL TEMPO ESGOTADO
            //CRIAR MODAL TEMPO ESGOTADO
            //CRIAR MODAL TEMPO ESGOTADO
            //CRIAR MODAL TEMPO ESGOTADO
            //CRIAR MODAL TEMPO ESGOTADO
            //CRIAR MODAL TEMPO ESGOTADO
            //CRIAR MODAL TEMPO ESGOTADO
            //CRIAR MODAL TEMPO ESGOTADO
            //CRIAR MODAL TEMPO ESGOTADO
            //CRIAR MODAL TEMPO ESGOTADO
            //CRIAR MODAL TEMPO ESGOTADO
            //CRIAR MODAL TEMPO ESGOTADO
            //CRIAR MODAL TEMPO ESGOTADO
            //CRIAR MODAL TEMPO ESGOTADO
            //CRIAR MODAL TEMPO ESGOTADO
            //CRIAR MODAL TEMPO ESGOTADO
            //CRIAR MODAL TEMPO ESGOTADO
            //CRIAR MODAL TEMPO ESGOTADO
            mostrarModalPontuacao();
        }
    }

    void AcaoBoardElevadoFim.ConsumidorEvento.consumirEvento(SubidaBoardAcaoFim evento)
    {
        if (evento.isGameOver)
        {
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            //CRIAR MODAL ELEVADOR GAME OVER
            mostrarModalPontuacao();
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
