using System.Collections;
using UnityEngine;

public class ModalResultadosManager : AcaoColetado.ConsumidorEvento,
                                      AcaoTempoEsgotado.ConsumidorEvento,
                                      AcaoBoardElevadoFim.ConsumidorEvento,
                                      AcaoCacaNiquel.ConsumidorEvento
{    
    private bool mostrandoModal;

    private ModalPontosDto modalPontosDto;    
    private ModalResultados modalResultado;

    public ModalResultadosManager(ModalPontosDto modalPontosDto)
    {
        this.modalPontosDto = modalPontosDto;        
    }

    public void configurarLevel(string levelName)
    {        
        modalResultado = new ModalResultados(levelName, modalPontosDto);
    }              

    private void mostrarModalPontuacao()
    {
        if (!mostrandoModal)
        {
            modalResultado.configurar();
            ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(coroutineMostrarModal());
        }
    }

    private void mostrarModalColetados()
    {
        if (!mostrandoModal)
        {
            modalResultado.configurarColetavel();
            ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(coroutineMostrarModal());
        }
    }

    private void mostrarModalColetadosFail()
    {
        if (!mostrandoModal)
        {
            modalResultado.configurarColetavelFail();
            ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(coroutineMostrarModal());
        }
    }

    private void mostrarModalCacaNiquelSinglePup(CacaNiquelEventoDto evento)
    {
        if (!mostrandoModal)
        {
            modalResultado.configurarCacaNiquelIndividual(evento);
            ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(coroutineMostrarModal());
        }
    }   

    private void mostrarModalCacaNiquelAllPups(CacaNiquelEventoDto evento)
    {
        if (!mostrandoModal)
        {
            modalResultado.configurarCacaNiquelGeral(evento);
            ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(coroutineMostrarModal());
        }
    }

    private void mostrarModalOrdemFail(int ordem)
    {        
        modalResultado.setScoreAtual("Não seguiu ordem " + ordem);
        //faltando navegacao de volta
        modalResultado.configurarModalFailOrdem();
        ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(coroutineMostrarModal());
    }  

    private IEnumerator coroutineMostrarModal()
    {      
        mostrandoModal = true;                   
        yield return new WaitForSeconds(0.5f);
        modalResultado.ligar();
    }

    void AcaoColetado.ConsumidorEvento.consumirEvento(InformacoesColetadoDto evento)
    {        
        modalResultado.setScoreAtual(evento.score.ToString());
        InformacoesFimDeJogoDto infoFimDeJogo = evento.infosFimDeJogo;
        if (infoFimDeJogo.fimColetados)
        {
            Debug.Log("Salvando indice");
            AbstractLevel levelAtual = ContextoEstaticoUtils.level;
            levelAtual.levelConcluido();
            
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
            mostrarModalPontuacao();
        }
    }

    void AcaoBoardElevadoFim.ConsumidorEvento.consumirEvento(SubidaBoardAcaoFim evento)
    {
        if (evento.isGameOver)
        {
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
