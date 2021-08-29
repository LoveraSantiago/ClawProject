using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaysDeColetados : AcaoColetadoFim.ProdutorEvento,
                                   InformacaoDisplayColetado
{
    private bool powerUpAcionado;
    private bool displayColetando;
    
    private DisplayDeColetadoDto displayColetadoDto;    
    
    private GrupoDisplays grupoDisplays;
    private MonoBehaviour monoBehaviour;
    private ProdutorDeEvento<ColetadoFim> produtorDeEventoFimColetagem;

    private InformacoesColetadoDto agendadoEvento;
    private ArcoIrisEfeito agendadoArcoIris;
    private Executor agendadoPosExecutor;
    private PowerUpInteracaoDisplayColetado agendadoInteracaoDisplayColetado;

    public DisplaysDeColetados(DisplayDeColetadoDto displayColetadoDto, MonoBehaviour monoBehaviour)
    {
        this.displayColetadoDto = displayColetadoDto;
        this.monoBehaviour = monoBehaviour;

        DisplayDeColetado.configurarDisplay(displayColetadoDto);

        grupoDisplays = new GrupoDisplays(displayColetadoDto.SingleDisplaysColetadoDto);
        produtorDeEventoFimColetagem = new ProdutorDeEvento<ColetadoFim>();        
    }    

    public void configuradoPeloLevel(Dictionary<string, string> dicionarioDeCores)
    {
        grupoDisplays.colorirDisplays(dicionarioDeCores);
    }

    public void mostrarColetadoNoDisplay(InformacoesColetadoDto evento, ArcoIrisEfeito arcoIris, Executor executorPosEvento)
    {
        monoBehaviour.StartCoroutine(mostrarSprite(evento, arcoIris, executorPosEvento));        
    }    
    
    public void processarPowerUp(PowerUpInteracaoDisplayColetado interacaoDisplayColetado)
    {
        if (interacaoDisplayColetado != null)
        {            
            if (displayColetando)
            {
                agendadoInteracaoDisplayColetado = interacaoDisplayColetado;
            }
            else
            {
                acionarPowerUp(interacaoDisplayColetado);
            }
        }        
    }

    public void processarFimPowerUp(BotoesPowerUp botoesPup)
    {
        if (powerUpAcionado)
        {
            powerUpAcionado = false;
            grupoDisplays.setarEstadoPowerUp(powerUpAcionado);
            grupoDisplays.desligarAlvos(monoBehaviour);            
            agendadoInteracaoDisplayColetado = null;

            if (possuiAgendamentoDeEvento())
            {
                if (grupoDisplays.isTodosDisplayOcupados())
                {
                    monoBehaviour.StartCoroutine(limpezaEFimTodosDisplaysOcupados(agendadoEvento, agendadoArcoIris, agendadoPosExecutor));
                }
                else
                {
                    fimLimpezaTodosDisplaysNaoOcupados(agendadoPosExecutor);
                }
                limparEventoAgendado();
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
        grupoDisplays.acionarMostrarAlvos(monoBehaviour);
        interacaoDisplayColetado.iniciar(this);        
    }     

    private IEnumerator mostrarSprite(InformacoesColetadoDto evento, ArcoIrisEfeito arcoIris, Executor executorPosEvento)
    {        
        displayColetando = true;
        int indiceDesocupado = grupoDisplays.getIndicePrimeiroDisplayDesocupado();        
        yield return grupoDisplays.mostrarSprColetado(indiceDesocupado, evento.sprite, powerUpAcionado);        

        if (possuiAgendamentoDePowerUp())
        {
            acionarPowerUpAgendado(evento, arcoIris, executorPosEvento);            
        }
        else if (grupoDisplays.isTodosDisplayOcupados() && !powerUpAcionado)
        {
            yield return limpezaTodosDisplaysOcupados(evento, arcoIris);
            if (possuiAgendamentoDePowerUp())
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
            agendarEvento(evento, arcoIris, executorPosEvento);
        }
        else if(!powerUpAcionado)
        {
            fimLimpezaTodosDisplaysNaoOcupados(executorPosEvento);                        
        }
        displayColetando = false;
    }     

    public ArcoIrisConjunto getDisplayColetadoGlow()
    {
        return grupoDisplays;
    }

    private bool possuiAgendamentoDePowerUp()
    {
        return agendadoInteracaoDisplayColetado != null;
    }

    private bool possuiAgendamentoDeEvento()
    {
        return agendadoEvento != null;
    }

    private void acionarPowerUpAgendado(InformacoesColetadoDto evento, ArcoIrisEfeito arcoIris, Executor executorPosEvento)
    {
        displayColetando = false;
        acionarPowerUp(agendadoInteracaoDisplayColetado);
        agendarEvento(evento, arcoIris, executorPosEvento);
    }

    private void agendarEvento(InformacoesColetadoDto evento, ArcoIrisEfeito arcoIris, Executor executorPosEvento)
    {
        agendadoEvento = evento;
        agendadoArcoIris = arcoIris;
        agendadoPosExecutor = executorPosEvento;
    }

    private void limparEventoAgendado()
    {
        agendadoEvento = null;
        agendadoArcoIris = null;
        agendadoPosExecutor = null;
    }

    private IEnumerator descartarColetado(int indice)
    {
        //Debug.Log("Acertou display indice " + indice);
        DisplayDeColetado[] displayDeColetado = grupoDisplays.displayDeColetado;
        displayDeColetado[indice].mostrarAlvoSelecionado();
        yield return displayDeColetado[indice].limparSprColetado();

        bool[] result = new bool[3] { false, false, false };
        result[indice] = true;
        produtorDeEventoFimColetagem.produziuEvento(new ColetadoFim(result));
    }

    private IEnumerator limpezaTodosDisplaysOcupados(InformacoesColetadoDto evento, ArcoIrisEfeito  arcoIris)
    {
        DisplayDeColetado[] displayDeColetado = grupoDisplays.displayDeColetado;
        if (evento.resultCombinacao)
        {
            arcoIris.ligarBlinkVerde();
        }
        else
        {
            arcoIris.ligarBlinkRed();
        }

        yield return displayDeColetado[0].limparSprColetado();
        yield return displayDeColetado[1].limparSprColetado();
        yield return displayDeColetado[2].limparSprColetado();
        yield return new WaitForSeconds(displayColetadoDto.FimDelay);
    }

    private IEnumerator limpezaEFimTodosDisplaysOcupados(InformacoesColetadoDto evento, ArcoIrisEfeito arcoIris, Executor executorPosEvento)
    {
        yield return limpezaTodosDisplaysOcupados(evento, arcoIris);
        fimLimpezaTodosDisplaysOcupados(arcoIris, executorPosEvento);
    }

    private void fimLimpezaTodosDisplaysOcupados(ArcoIrisEfeito arcoIris, Executor executorPosEvento)
    {
        arcoIris.desligarEfeito();
        produtorDeEventoFimColetagem.produziuEvento(new ColetadoFim(true, true, true));
        executorPosEvento.execute();
    }

    private void fimLimpezaTodosDisplaysNaoOcupados(Executor executorPosEvento)
    {        
        produtorDeEventoFimColetagem.produziuEvento(new ColetadoFim(false, false, false));
        executorPosEvento.execute();
    }

    //***** IMPLEMENTACAO INTERFACE INFORMACAODISPLAYCOLETADO INICIO *****
    public bool acertouDisplay(Vector2 toque)
    {
        DisplayDeColetado[] displayDeColetado = grupoDisplays.displayDeColetado;
        for (int contador = 0; contador < displayDeColetado.Length; contador++)
        {
            bool result = displayDeColetado[contador].isCliqueDentroArea(toque);
            if (result)
            {
                monoBehaviour.StartCoroutine(descartarColetado(contador));
                return true;
            }
        }
        return false;
    }

    public bool isTodosDisplaysDesocupados()
    {
        return grupoDisplays.isTodosDisplaysDesocupados();
    }

    public void restartPowerUp(PowerUpInteracaoDisplayColetado interacao)
    {
        processarPowerUp(interacao);
    }
    //***** IMPLEMENTACAO INTERFACE INFORMACAODISPLAYCOLETADO FIM *****

    ProdutorDeEvento<ColetadoFim> AcaoColetadoFim.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEventoFimColetagem;
    }
}
