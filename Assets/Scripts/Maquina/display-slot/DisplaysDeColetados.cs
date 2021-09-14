using System.Collections;
using UnityEngine;

public class DisplaysDeColetados : AcaoColetadoFim.ProdutorEvento,
                                   InformacaoDisplayColetado
{
    private bool powerUpAcionado;
    private bool displayColetando;
        
    private GrupoDisplays grupoDisplays;    
    private AgendamentoDisplayColetados agendados;    
    private ProdutorDeEvento<ColetadoFim> produtorDeEventoFimColetagem;

    public DisplaysDeColetados(DisplaysSlotsDto displaysSlotsDto, GrupoDisplays grupoDisplays)
    {    
        this.grupoDisplays = grupoDisplays;
        agendados = new AgendamentoDisplayColetados();
        produtorDeEventoFimColetagem = new ProdutorDeEvento<ColetadoFim>();            
    }        

    public void mostrarColetadoNoDisplay(
        InformacoesColetadoDto evento, ArcoIrisEfeito arcoIris, Executor executorPosEvento)
    {
        Utils.MonoBehaviour.StartCoroutine(mostrarSprite(evento, arcoIris, executorPosEvento));        
    }    
    
    public void processarPowerUp(PowerUpEntidade.TIPO tipoPup, PowerUpInteracaoDisplayColetado interacaoDisplayColetado)
    {
        agendados.agendar(tipoPup);
        if (displayColetando)
        {
            agendados.agendar(interacaoDisplayColetado);                
        }
        else
        {
            acionarPowerUp(interacaoDisplayColetado);
        }        
    }

    public void processarFimPowerUp(BotoesPowerUp botoesPup)
    {
        if (powerUpAcionado)
        {
            powerUpAcionado = false;
            grupoDisplays.setarEstadoPowerUp(powerUpAcionado);
            grupoDisplays.desligarAlvos();
            agendados.cleanInteracao();            

            if (agendados.possuiAgendamentoDeEvento())
            {
                if (grupoDisplays.isTodosDisplayOcupados())
                {
                    Utils.MonoBehaviour.StartCoroutine(
                        limpezaEFimTodosDisplaysOcupados(
                            agendados.infoColetadoDto, agendados.arcoIris, agendados.executor));
                }
                else
                {
                    fimLimpezaTodosDisplaysNaoOcupados(agendados.executor);
                }
                agendados.cleanOutros();
            }
            else
            {
                botoesPup.reativarPowerUpPosDisplay();
            }
        }
    }

    private void acionarPowerUp(PowerUpInteracaoDisplayColetado interacaoDisplayColetado)
    {
        powerUpAcionado = true;
        grupoDisplays.setarEstadoPowerUp(powerUpAcionado);
        grupoDisplays.acionarMostrarAlvos();
        interacaoDisplayColetado.iniciar(this);        
    }     

    private IEnumerator mostrarSprite(
        InformacoesColetadoDto evento, ArcoIrisEfeito arcoIris, Executor executorPosEvento)
    {        
        displayColetando = true;
        int indiceDesocupado = grupoDisplays.getIndicePrimeiroDisplayDesocupado();        
        yield return grupoDisplays.mostrarSprColetado(indiceDesocupado, evento.sprite, powerUpAcionado);        

        if (agendados.possuiAgendamentoDePowerUp())
        {
            acionarPowerUpAgendado(evento, arcoIris, executorPosEvento);            
        }
        else if (grupoDisplays.isTodosDisplayOcupados() && !powerUpAcionado)
        {
            yield return limpezaTodosDisplaysOcupados(evento, arcoIris);
            if (agendados.possuiAgendamentoDePowerUp())
            {
                acionarPowerUpAgendado(evento, arcoIris, executorPosEvento);
            }
            else
            {
                fimLimpezaTodosDisplaysOcupados(arcoIris, executorPosEvento);                
            }
        }
        else if (powerUpAcionado)
        {
            agendados.agendar(evento, arcoIris, executorPosEvento);
        }
        else if(!powerUpAcionado)
        {
            fimLimpezaTodosDisplaysNaoOcupados(executorPosEvento);                        
        }
        displayColetando = false;
    }                

    private void acionarPowerUpAgendado(InformacoesColetadoDto evento, ArcoIrisEfeito arcoIris, Executor executorPosEvento)
    {
        displayColetando = false;
        acionarPowerUp(agendados.interacaoDisplayColetado);
        agendados.agendar(evento, arcoIris, executorPosEvento);
    }      

    private IEnumerator descartarColetado(int indice)
    {
        yield return grupoDisplays.mostrarAlvoELimparSprColetado(indice);

        bool[] result = new bool[3] { false, false, false };
        result[indice] = true;
        produtorDeEventoFimColetagem.produziuEvento(ColetadoFim.ofPup(agendados.tipoPup, result));
    }

    private IEnumerator limpezaTodosDisplaysOcupados(InformacoesColetadoDto evento, ArcoIrisEfeito  arcoIris)
    {
        DisplayDeSlot[] displayDeSlot = grupoDisplays.displayDeSlot;
        if (evento.resultCombinacao)
        {
            arcoIris.ligarBlinkVerde();
        }
        else
        {
            arcoIris.ligarBlinkRed();
        }

        yield return grupoDisplays.limparSprColetado(0);
        yield return grupoDisplays.limparSprColetado(1);
        yield return grupoDisplays.limparSprColetado(2);
        yield return new WaitForSeconds(grupoDisplays.displaysSlotsDto.FimDelay);
    }

    private IEnumerator limpezaEFimTodosDisplaysOcupados(InformacoesColetadoDto evento, ArcoIrisEfeito arcoIris, Executor executorPosEvento)
    {
        yield return limpezaTodosDisplaysOcupados(evento, arcoIris);
        fimLimpezaTodosDisplaysOcupados(arcoIris, executorPosEvento);
    }

    private void fimLimpezaTodosDisplaysOcupados(ArcoIrisEfeito arcoIris, Executor executorPosEvento)
    {
        arcoIris.desligarEfeito();
        produtorDeEventoFimColetagem.produziuEvento(ColetadoFim.ofNormal(new bool[] { true, true, true }));
        executorPosEvento.execute();
    }

    private void fimLimpezaTodosDisplaysNaoOcupados(Executor executorPosEvento)
    {        
        produtorDeEventoFimColetagem.produziuEvento(ColetadoFim.ofNormal(new bool[] { false, false, false }));
        executorPosEvento.execute();
    }

    //***** IMPLEMENTACAO INTERFACE INFORMACAODISPLAYCOLETADO INICIO *****
    public bool acertouDisplay(Vector2 toque)
    {
        DisplayDeSlot[] displayDeColetado = grupoDisplays.displayDeSlot;
        for (int contador = 0; contador < displayDeColetado.Length; contador++)
        {
            bool result = displayDeColetado[contador].isCliqueDentroArea(toque);
            if (result)
            {
                Utils.MonoBehaviour.StartCoroutine(descartarColetado(contador));
                return true;
            }
        }
        return false;
    }

    public bool isTodosDisplaysDesocupados()
    {
        return grupoDisplays.isTodosDisplaysDesocupados();
    }

    public void restartPowerUp(PowerUpEntidade.TIPO tipo, PowerUpInteracaoDisplayColetado interacao)
    {
        processarPowerUp(tipo, interacao);
    }
    //***** IMPLEMENTACAO INTERFACE INFORMACAODISPLAYCOLETADO FIM *****

    ProdutorDeEvento<ColetadoFim> AcaoColetadoFim.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEventoFimColetagem;
    }
}
