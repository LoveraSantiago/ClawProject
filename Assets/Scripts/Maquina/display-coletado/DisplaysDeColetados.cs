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
    
    private PowerUpInteracaoDisplayColetado interacaoDisplayColetadoAgendado;

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
                interacaoDisplayColetadoAgendado = interacaoDisplayColetado;
            }
            else
            {
                acionarPowerUp(interacaoDisplayColetado);
            }
        }        
    }

    public void processarFimPowerUp()
    {
        if (powerUpAcionado)
        {
            powerUpAcionado = false;
            grupoDisplays.setarEstadoPowerUp(powerUpAcionado);
            grupoDisplays.desligarAlvos(monoBehaviour);            
            interacaoDisplayColetadoAgendado = null;
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
        DisplayDeColetado[] displayDeColetado = grupoDisplays.displayDeColetado;        
        yield return displayDeColetado[indiceDesocupado].mostrarSprColetado(evento.sprite, powerUpAcionado);        

        if (possuiAgendamentoDePowerUp())
        {
            displayColetando = false;
            acionarPowerUp(interacaoDisplayColetadoAgendado);
        }
        else if (grupoDisplays.isTodosDisplayOcupados() && !powerUpAcionado)
        {
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

            if (possuiAgendamentoDePowerUp())
            {
                displayColetando = false;
                acionarPowerUp(interacaoDisplayColetadoAgendado);
            }
            else
            {
                arcoIris.desligarEfeito();
                produtorDeEventoFimColetagem.produziuEvento(new ColetadoFim(true, true, true));
                executorPosEvento.execute();
            }
        }
        else if(!powerUpAcionado)
        {
            produtorDeEventoFimColetagem.produziuEvento(new ColetadoFim(false, false, false));
            executorPosEvento.execute();
        }
        displayColetando = false;
    }   

    private IEnumerator descartarColetado(int indice)
    {
        Debug.Log("Acertou display indice " + indice);
        DisplayDeColetado[] displayDeColetado = grupoDisplays.displayDeColetado;
        displayDeColetado[indice].mostrarAlvoSelecionado();
        yield return displayDeColetado[indice].limparSprColetado();

        bool[] result = new bool[3]{ false, false, false };
        result[indice] = true;
        produtorDeEventoFimColetagem.produziuEvento(new ColetadoFim(result));
    }        

    private bool possuiAgendamentoDePowerUp()
    {
        return interacaoDisplayColetadoAgendado != null;
    }

    public ArcoIrisConjunto getDisplayColetadoGlow()
    {
        return grupoDisplays;
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

    ProdutorDeEvento<ColetadoFim> AcaoColetadoFim.ProdutorEvento.getProdutorDeEventoColetado()
    {
        return produtorDeEventoFimColetagem;
    }
}
