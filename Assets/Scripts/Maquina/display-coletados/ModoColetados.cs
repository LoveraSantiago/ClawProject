using System.Collections;
using UnityEngine;

public class ModoColetados : AcaoColetadoFim.ProdutorEvento,
                                   InformacaoDisplayColetado
{
    private bool powerUpAcionado;
    private bool displayColetando;
        
    private GrupoDisplays grupoDisplays;    
    private AgendamentoDisplayColetados agendados;    
    private ProdutorDeEvento<ColetadoFimDto> produtorDeEventoFimColetagem;

    public ModoColetados(GrupoDisplays grupoDisplays)
    {    
        this.grupoDisplays = grupoDisplays;
        agendados = new AgendamentoDisplayColetados();
        produtorDeEventoFimColetagem = new ProdutorDeEvento<ColetadoFimDto>();            
    }        

    public void mostrarColetadoNoDisplay(InformacoesColetadoDto evento, ArcoIrisEfeito arcoIris)
    {
        ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(mostrarSprite(evento, arcoIris));        
    }    
    
    public void processarPowerUp(PowerUpEnums.TIPO tipoPup, PowerUpInteracaoComDisplayColetado interacaoDisplayColetado)
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
            agendados.cleanInteracao();            

            if (agendados.possuiAgendamentoDeEvento())
            {
                finalizacaoPeloEstadoDisplay();
                agendados.cleanOutros();
            }
            else
            {
                botoesPup.reativarPowerUpPosDisplay();
            }
        }
    }

    public void restaurarEstadoAntesPowerUp(Executor executor)
    {
        grupoDisplays.desligarAlvos(executor);
    }

    private void acionarPowerUp(PowerUpInteracaoComDisplayColetado interacaoDisplayColetado)
    {
        //Debug.Log("Pup acionado no display de coletado inicio");
        powerUpAcionado = true;
        grupoDisplays.setarEstadoPowerUp(powerUpAcionado);        
        grupoDisplays.acionarMostrarAlvos(interacaoDisplayColetado.getExecutorDeInicio());
        //Debug.Log("Pup acionado no display de coletado fim");
    }     

    private IEnumerator mostrarSprite(InformacoesColetadoDto evento, ArcoIrisEfeito arcoIris)
    {        
        displayColetando = true;
        int indiceDesocupado = grupoDisplays.getIndicePrimeiroDisplayDesocupado();        
        yield return grupoDisplays.mostrarSprColetado(indiceDesocupado, evento.sprite, powerUpAcionado);        

        if (agendados.possuiAgendamentoDePowerUp())
        {
            acionarPowerUpAgendado(evento, arcoIris);
        }
        else if (grupoDisplays.isTodosDisplayOcupados() && !powerUpAcionado)
        {
            yield return limpezaTodosDisplaysOcupados(evento, arcoIris);
            if (agendados.possuiAgendamentoDePowerUp())
            {
                acionarPowerUpAgendado(evento, arcoIris);
            }
            else
            {
                finalizacaoTodosDisplaysOcupados(arcoIris);                
            }
        }
        else if (powerUpAcionado)
        {
            agendados.agendar(evento, arcoIris);
        }
        else if(!powerUpAcionado)
        {
            finalizacaoTodosDisplaysNaoOcupados();                        
        }
        displayColetando = false;
    }                

    private void acionarPowerUpAgendado(InformacoesColetadoDto evento, ArcoIrisEfeito arcoIris)
    {
        displayColetando = false;
        acionarPowerUp(agendados.interacaoDisplayColetado);
        agendados.agendar(evento, arcoIris);
    }      

    private IEnumerator descartarColetado(int indice)
    {
        yield return grupoDisplays.mostrarAlvoELimparSprColetado(indice);

        bool[] result = new bool[3] { false, false, false };
        result[indice] = true;
        produtorDeEventoFimColetagem.produziuEvento(ColetadoFimDto.ofPup(agendados.tipoPup, result));
    }

    private IEnumerator limpezaTodosDisplaysOcupados(InformacoesColetadoDto evento, ArcoIrisEfeito  arcoIris)
    {
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

        SingleDisplayDeColetado[] singleDisplayDeColetado = grupoDisplays.singleDisplayDeColetado;
        yield return new WaitForSeconds(singleDisplayDeColetado[0].getFimDelay());
    }

    private void finalizacaoPeloEstadoDisplay()
    {
        if (grupoDisplays.isTodosDisplayOcupados())
        {
            ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(finalizacaoCompletaTodosDisplaysOcupados(agendados));
        }
        else
        {
            finalizacaoTodosDisplaysNaoOcupados();
        }
    }

    private IEnumerator finalizacaoCompletaTodosDisplaysOcupados(AgendamentoDisplayColetados agendados)
    {
        yield return finalizacaoCompletaTodosDisplaysOcupados(agendados.infoColetadoDto, agendados.arcoIris);
    }

    private IEnumerator finalizacaoCompletaTodosDisplaysOcupados(InformacoesColetadoDto evento, ArcoIrisEfeito arcoIris)
    {
        yield return limpezaTodosDisplaysOcupados(evento, arcoIris);
        finalizacaoTodosDisplaysOcupados(arcoIris);
    }

    private void finalizacaoTodosDisplaysOcupados(ArcoIrisEfeito arcoIris)
    {
        arcoIris.desligarEfeito();
        produtorDeEventoFimColetagem.produziuEvento(ColetadoFimDto.ofNormal(new bool[] { true, true, true }));        
    }

    private void finalizacaoTodosDisplaysNaoOcupados()
    {        
        produtorDeEventoFimColetagem.produziuEvento(ColetadoFimDto.ofNormal(new bool[] { false, false, false }));        
    }

    //***** IMPLEMENTACAO INTERFACE INFORMACAODISPLAYCOLETADO INICIO *****
    public bool acertouDisplay(Vector2 toque)
    {
        SingleDisplayDeColetado[] displayDeColetado = grupoDisplays.singleDisplayDeColetado;
        for (int contador = 0; contador < displayDeColetado.Length; contador++)
        {
            bool result = displayDeColetado[contador].isCliqueDentroArea(toque);
            if (result)
            {
                ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(descartarColetado(contador));
                return true;
            }
        }
        return false;
    }

    public bool isTodosDisplaysDesocupados()
    {
        return grupoDisplays.isTodosDisplaysDesocupados();
    }

    public int getQtdDisplaysOcupados()
    {
        return grupoDisplays.getQtdDisplaysOcupados();
    }

    public void restartPowerUp(PowerUpEnums.TIPO tipo, PowerUpInteracaoComDisplayColetado interacao)
    {
        processarPowerUp(tipo, interacao);
    }
    //***** IMPLEMENTACAO INTERFACE INFORMACAODISPLAYCOLETADO FIM *****

    ProdutorDeEvento<ColetadoFimDto> AcaoColetadoFim.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEventoFimColetagem;
    }   
}
