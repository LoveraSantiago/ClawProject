using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaysDeColetados : AcaoColetadoFim.ProdutorEvento
{
    private bool powerUpAcionado;
    private DisplayDeColetadoDto displayColetadoDto;    
    private DisplayDeColetado[] displayDeColetado;
    private DisplayDeColetadosArcoIris displayArcoIris;
    private MonoBehaviour monoBehaviour;
    private ProdutorDeEvento<ColetadoFim> produtorDeEventoFimColetagem;

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
    
    public void processarPowerUp(PowerUpInfo powerUpInfo)
    {
        PowerUpInteracaoDisplayColetado interacaoDisplayColetado = powerUpInfo.interacaoDisplayColetado;
        if (interacaoDisplayColetado != null)
        {
            powerUpAcionado = true;
            displayArcoIris.setarEstadoPowerUp(powerUpAcionado);
            displayDeColetado[0].mostrarAlvo(monoBehaviour);
            displayDeColetado[1].mostrarAlvo(monoBehaviour);
            displayDeColetado[2].mostrarAlvo(monoBehaviour);

            interacaoDisplayColetado.resetImediato(isTodosDisplaysDesocupados());
        }        
    }

    public void finalizarPowerUp()
    {
        if (powerUpAcionado)
        {
            powerUpAcionado = false;
            displayArcoIris.setarEstadoPowerUp(powerUpAcionado);
            displayDeColetado[0].desligarAlvo(monoBehaviour);
            displayDeColetado[1].desligarAlvo(monoBehaviour);
            displayDeColetado[2].desligarAlvo(monoBehaviour);
        }
    }
    
    public ArcoIrisConjunto getDisplayColetadoGlow()
    {
        return displayArcoIris;
    }

    private void inicializarDisplayDeColetado(SingleDisplayColetadoDto[] singlesDisplayColetadosDto)
    {
        displayDeColetado = new DisplayDeColetado[singlesDisplayColetadosDto.Length];
        displayDeColetado[0] = new DisplayDeColetado(singlesDisplayColetadosDto[0]);
        displayDeColetado[1] = new DisplayDeColetado(singlesDisplayColetadosDto[1]);
        displayDeColetado[2] = new DisplayDeColetado(singlesDisplayColetadosDto[2]);
    }

    private IEnumerator mostrarSprite(InformacoesColetadoDto evento, ArcoIrisEfeito arcoIris, Executor executorPosEvento)
    {        
        int indiceDesocupado = getIndicePrimeiroDisplayDesocupado();
        yield return monoBehaviour.StartCoroutine(displayDeColetado[indiceDesocupado].subirSlotBaixo(evento.sprite));

        if (isTodosDisplayOcupados())
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
            produtorDeEventoFimColetagem.produziuEvento(new ColetadoFim(true));
        }
        else
        {
            produtorDeEventoFimColetagem.produziuEvento(new ColetadoFim(false));
        }

        executorPosEvento.execute();        
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

    ProdutorDeEvento<ColetadoFim> AcaoColetadoFim.ProdutorEvento.getProdutorDeEventoColetado()
    {
        return produtorDeEventoFimColetagem;
    }
}
