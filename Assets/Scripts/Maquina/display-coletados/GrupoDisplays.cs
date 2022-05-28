using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class GrupoDisplays 
{
    private bool powerUpDisplayColetado;

    public DisplaysColetadosDto displaysSlotsDto { get; private set; }
    public DisplayDeSlot[] displayDeSlot { get; private set; }

    public GrupoDisplays(DisplaysColetadosDto displaysSlotsDto)
    {
        this.displaysSlotsDto = displaysSlotsDto;

        SingleSlotColetadoDto[] singleSlotColetadoDto = displaysSlotsDto.SingleSlotColetadoDto;
        displayDeSlot = new DisplayDeSlot[singleSlotColetadoDto.Length];

        for(int contador = 0; contador < displayDeSlot.Length; contador++)
        {
            displayDeSlot[contador] = new DisplayDeSlot(singleSlotColetadoDto[contador]);
        }        
    }

    public void colorirDisplays(Dictionary<string, string> dicionarioDeCores)
    {
        ColoridorDisplaysColetadosV2 coloridor = new ColoridorDisplaysColetadosV2();
        coloridor.colorir(displaysSlotsDto.SprRendererPlacaGrupo, displayDeSlot, dicionarioDeCores);
    }

    public void setarEstadoPowerUp(bool estado)
    {
        powerUpDisplayColetado = estado;
    }      

    public void acionarMostrarAlvos(Executor executorFimMovimentacao)
    {
        Utils.MonoBehaviour.StartCoroutine(displayDeSlot[0].mostrarAlvo(displaysSlotsDto, executorFimMovimentacao));
        Utils.MonoBehaviour.StartCoroutine(displayDeSlot[1].mostrarAlvo(displaysSlotsDto, executorFimMovimentacao));
        Utils.MonoBehaviour.StartCoroutine(displayDeSlot[2].mostrarAlvo(displaysSlotsDto, executorFimMovimentacao));
    }

    public void desligarAlvos(Executor executorFimMovimentacao)
    {
        Utils.MonoBehaviour.StartCoroutine(displayDeSlot[0].desligarAlvo(displaysSlotsDto, executorFimMovimentacao));
        Utils.MonoBehaviour.StartCoroutine(displayDeSlot[1].desligarAlvo(displaysSlotsDto, executorFimMovimentacao));
        Utils.MonoBehaviour.StartCoroutine(displayDeSlot[2].desligarAlvo(displaysSlotsDto, executorFimMovimentacao));
    }

    public IEnumerator mostrarSprColetado(int indice, Sprite sprite, bool powerUpAcionado)
    {
        yield return displayDeSlot[indice].mostrarSprColetado(sprite, powerUpAcionado, displaysSlotsDto);
    }

    public IEnumerator limparSprColetado(int indice)
    {
        yield return displayDeSlot[indice].limparSprColetado(displaysSlotsDto);
    }

    public IEnumerator mostrarAlvoELimparSprColetado(int indice)
    {

        displayDeSlot[indice].mostrarAlvoSelecionado(displaysSlotsDto.SprMiraGrossa, displaysSlotsDto.MaterialAlvoSelecionado);
        yield return displayDeSlot[indice].limparSprColetado(displaysSlotsDto);
    }

    public int getIndicePrimeiroDisplayDesocupado()
    {
        if (displayDeSlot[0].isDesocupado) return 0;
        if (displayDeSlot[1].isDesocupado) return 1;
        return 2;
    }

    public bool isTodosDisplayOcupados()
    {
        return displayDeSlot[0].isOcupado && 
               displayDeSlot[1].isOcupado && 
               displayDeSlot[2].isOcupado;
    }

    public bool isTodosDisplaysDesocupados()
    {
        return displayDeSlot[0].isDesocupado && 
               displayDeSlot[1].isDesocupado && 
               displayDeSlot[2].isDesocupado;
    }   

    public int getQtdDisplaysOcupados()
    {
        int total = 0;
        if (displayDeSlot[0].isOcupado) total++;
        if (displayDeSlot[1].isOcupado) total++;
        if (displayDeSlot[2].isOcupado) total++;

        return total;
    }

    public void ligarGlowLuz()
    {
        displayDeSlot[0].ligarGlowLuz();
        displayDeSlot[1].ligarGlowLuz();
        displayDeSlot[2].ligarGlowLuz();
    }

    public void ligarCacaNiquel(Sprite[] sprSlot1, Sprite[] sprSlot2, Sprite[] sprSlot3)
    {
        displayDeSlot[0].ligarCacaNiquel(sprSlot1);
        //displayDeSlot[1].ligarCacaNiquel(sprSlot2);
        //displayDeSlot[2].ligarCacaNiquel(sprSlot3);
    }

    public void pararSlotCacaNiquel(int indice, Sprite[] sprSlots, Sprite sprSucesso)
    {
        displayDeSlot[indice].pararCacaNiquel(sprSlots, sprSucesso);
    }

    public Sprite[] getResultadosCacaNiquel()
    {
        return new Sprite[] {
            getResultadoCacaNiquel(0),
            getResultadoCacaNiquel(1),
            getResultadoCacaNiquel(2)            
        };
    }

    public Sprite getResultadoCacaNiquel(int indice)
    {
        return displayDeSlot[indice].getSprResultCacaNiquel();
    }

    public void ligarGlowFail()
    {
        displayDeSlot[0].ligarGlowFail();
        displayDeSlot[1].ligarGlowFail();
        displayDeSlot[2].ligarGlowFail();
    }   
}
