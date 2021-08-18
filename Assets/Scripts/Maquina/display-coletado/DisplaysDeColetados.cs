using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaysDeColetados : AcaoColetadoFim.ProdutorEvento,
                                   InformacaoDisplayColetado
{
    private bool powerUpAcionado;
    private bool displayColetando;
    
    private DisplayDeColetadoDto displayColetadoDto;    
    private DisplayDeColetado[] displayDeColetado;
    private DisplayDeColetadosArcoIris displayArcoIris;
    private MonoBehaviour monoBehaviour;
    private ProdutorDeEvento<ColetadoFim> produtorDeEventoFimColetagem;

    PowerUpInteracaoDisplayColetado interacaoDisplayColetadoAgendado;

    public DisplaysDeColetados(DisplayDeColetadoDto displayColetadoDto, MonoBehaviour monoBehaviour)
    {
        this.displayColetadoDto = displayColetadoDto;
        this.monoBehaviour = monoBehaviour;

        DisplayDeColetado.configurarDisplay(displayColetadoDto);
        inicializarDisplayDeColetado(displayColetadoDto.SingleDisplaysColetadoDto);

        displayArcoIris = new DisplayDeColetadosArcoIris(displayDeColetado);
        produtorDeEventoFimColetagem = new ProdutorDeEvento<ColetadoFim>();
    }    

    public void configuradoPeloLevel(Dictionary<string, string> dicionarioDeCores)
    {
        new ColoridorDisplaysColetados().colorir(displayDeColetado, dicionarioDeCores);        
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
            displayArcoIris.setarEstadoPowerUp(powerUpAcionado);
            displayDeColetado[0].desligarAlvo(monoBehaviour);
            displayDeColetado[1].desligarAlvo(monoBehaviour);
            displayDeColetado[2].desligarAlvo(monoBehaviour);
            interacaoDisplayColetadoAgendado = null;
        }
    }
    
    public ArcoIrisConjunto getDisplayColetadoGlow()
    {
        return displayArcoIris;
    }

    public bool acertouDisplay(Vector2 toque)
    {
        for(int contador = 0; contador < displayDeColetado.Length; contador++)
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

    private void inicializarDisplayDeColetado(SingleDisplayColetadoDto[] singlesDisplayColetadosDto)
    {
        displayDeColetado = new DisplayDeColetado[singlesDisplayColetadosDto.Length];
        displayDeColetado[0] = new DisplayDeColetado(singlesDisplayColetadosDto[0]);
        displayDeColetado[1] = new DisplayDeColetado(singlesDisplayColetadosDto[1]);
        displayDeColetado[2] = new DisplayDeColetado(singlesDisplayColetadosDto[2]);
    }

    private void acionarPowerUp(PowerUpInteracaoDisplayColetado interacaoDisplayColetado)
    {
        powerUpAcionado = true;
        displayArcoIris.setarEstadoPowerUp(powerUpAcionado);
        displayDeColetado[0].mostrarAlvo(monoBehaviour);
        displayDeColetado[1].mostrarAlvo(monoBehaviour);
        displayDeColetado[2].mostrarAlvo(monoBehaviour);

        interacaoDisplayColetado.iniciar(this);
        interacaoDisplayColetado.resetImediato(isTodosDisplaysDesocupados());
    }

    private IEnumerator mostrarSprite(InformacoesColetadoDto evento, ArcoIrisEfeito arcoIris, Executor executorPosEvento)
    {
        displayColetando = true;
        int indiceDesocupado = getIndicePrimeiroDisplayDesocupado();
        yield return monoBehaviour.StartCoroutine(displayDeColetado[indiceDesocupado].subirSlotBaixo(evento.sprite));

        if (possuiAgendamentoDePowerUp())
        {
            acionarPowerUp(interacaoDisplayColetadoAgendado);
        }
        else if (isTodosDisplayOcupados())
        {
            if (evento.resultCombinacao)
            {
                arcoIris.ligarBlinkVerde();
            }
            else
            {
                arcoIris.ligarBlinkRed();
            }

            yield return monoBehaviour.StartCoroutine(displayDeColetado[0].descerSlotBaixo());
            yield return monoBehaviour.StartCoroutine(displayDeColetado[1].descerSlotBaixo());
            yield return monoBehaviour.StartCoroutine(displayDeColetado[2].descerSlotBaixo());
            yield return new WaitForSeconds(displayColetadoDto.FimDelay);

            arcoIris.desligarEfeito();
            produtorDeEventoFimColetagem.produziuEvento(new ColetadoFim(true, true, true));
        }
        else
        {
            produtorDeEventoFimColetagem.produziuEvento(new ColetadoFim(false, false, false));
        }

        executorPosEvento.execute();
        displayColetando = false;
    }   

    private IEnumerator descartarColetado(int indice)
    {
        Debug.Log("Acertou display indice " + indice);
        displayDeColetado[indice].mostrarAlvoSelecionado();
        yield return displayDeColetado[indice].descerSlotBaixo();

        bool[] result = new bool[3]{ false, false, false };
        result[indice] = true;
        produtorDeEventoFimColetagem.produziuEvento(new ColetadoFim(result));
    }

    private int getIndicePrimeiroDisplayDesocupado()
    {
        if (displayDeColetado[0].isDesocupado()) return 0;
        if (displayDeColetado[1].isDesocupado()) return 1;
        return 2;
    }

    private bool isTodosDisplayOcupados()
    {
        return displayDeColetado[0].isOcupado() && displayDeColetado[1].isOcupado() && displayDeColetado[2].isOcupado();
    }            

    private bool isTodosDisplaysDesocupados()
    {
        return displayDeColetado[0].isDesocupado() && displayDeColetado[1].isDesocupado() && displayDeColetado[2].isDesocupado();
    }

    private bool possuiAgendamentoDePowerUp()
    {
        return interacaoDisplayColetadoAgendado != null;
    }

    ProdutorDeEvento<ColetadoFim> AcaoColetadoFim.ProdutorEvento.getProdutorDeEventoColetado()
    {
        return produtorDeEventoFimColetagem;
    }   
}
