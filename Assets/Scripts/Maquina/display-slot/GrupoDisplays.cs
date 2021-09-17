using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class GrupoDisplays : ArcoIrisConjunto
{
    private bool powerUpDisplayColetado;

    public DisplaysSlotsDto displaysSlotsDto { get; private set; }
    public DisplayDeSlot[] displayDeSlot { get; private set; }

    public GrupoDisplays(DisplaysSlotsDto displaysSlotsDto, SingleDisplaySlotDto[] singleDisplaySlotDto)
    {
        this.displaysSlotsDto = displaysSlotsDto;
        displayDeSlot = new DisplayDeSlot[singleDisplaySlotDto.Length];
        displayDeSlot[0] = new DisplayDeSlot(singleDisplaySlotDto[0]);
        displayDeSlot[1] = new DisplayDeSlot(singleDisplaySlotDto[1]);
        displayDeSlot[2] = new DisplayDeSlot(singleDisplaySlotDto[2]);
    }

    public void colorirDisplays(Dictionary<string, string> dicionarioDeCores)
    {
        new ColoridorDisplaysColetados().colorir(displayDeSlot, dicionarioDeCores);
    }

    public void setarEstadoPowerUp(bool estado)
    {
        powerUpDisplayColetado = estado;
    }      

    public void acionarMostrarAlvos(Executor executor)
    {
        Utils.MonoBehaviour.StartCoroutine(displayDeSlot[0].mostrarAlvo(displaysSlotsDto, executor));
        Utils.MonoBehaviour.StartCoroutine(displayDeSlot[1].mostrarAlvo(displaysSlotsDto, executor));
        Utils.MonoBehaviour.StartCoroutine(displayDeSlot[2].mostrarAlvo(displaysSlotsDto, executor));
    }

    public void desligarAlvos()
    {
        Utils.MonoBehaviour.StartCoroutine(displayDeSlot[0].desligarAlvo(displaysSlotsDto));
        Utils.MonoBehaviour.StartCoroutine(displayDeSlot[1].desligarAlvo(displaysSlotsDto));
        Utils.MonoBehaviour.StartCoroutine(displayDeSlot[2].desligarAlvo(displaysSlotsDto));
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
        displayDeSlot[indice].mostrarAlvoSelecionado();
        yield return displayDeSlot[indice].limparSprColetado(displaysSlotsDto);
    }

    public int getIndicePrimeiroDisplayDesocupado()
    {
        if (displayDeSlot[0].isDesocupado()) return 0;
        if (displayDeSlot[1].isDesocupado()) return 1;
        return 2;
    }

    public bool isTodosDisplayOcupados()
    {
        return displayDeSlot[0].isOcupadoColetado() && displayDeSlot[1].isOcupadoColetado() && displayDeSlot[2].isOcupadoColetado();
    }

    public bool isTodosDisplaysDesocupados()
    {
        return displayDeSlot[0].isDesocupado() && displayDeSlot[1].isDesocupado() && displayDeSlot[2].isDesocupado();
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
        displayDeSlot[1].ligarCacaNiquel(sprSlot2);
        displayDeSlot[2].ligarCacaNiquel(sprSlot3);
    }

    public void pararCacaNiquel(int indice, Sprite[] sprSlots, Sprite sprSucesso)
    {
        displayDeSlot[indice].pararCacaNiquel(sprSlots, sprSucesso);
    }

    public Sprite[] getResultadosCacaNiquel()
    {
        return new Sprite[] {
            displayDeSlot[0].getSprResultCacaNiquel(),
            displayDeSlot[1].getSprResultCacaNiquel(),
            displayDeSlot[2].getSprResultCacaNiquel()
        };
    }

    public void ligarGlowFail()
    {
        displayDeSlot[0].ligarGlowFail();
        displayDeSlot[1].ligarGlowFail();
        displayDeSlot[2].ligarGlowFail();
    }

    //***** INICIO IMPLEMENTACAO INTERFACE ARCO IRIS CONJUNTO *****
    public void ligar()
    {
        if (!powerUpDisplayColetado)
        {
            displayDeSlot[0].ligarGlowSucesso();
            displayDeSlot[1].ligarGlowSucesso();
            displayDeSlot[2].ligarGlowSucesso();
        }
    }

    public void desligar()
    {
        displayDeSlot[0].desligarGlow();
        displayDeSlot[1].desligarGlow();
        displayDeSlot[2].desligarGlow();
    }

    public void passarCor(Color cor)
    {
        if (!powerUpDisplayColetado)
        {
            displayDeSlot[0].getMaterialGlow().setCorNoMaterial(cor);
            displayDeSlot[1].getMaterialGlow().setCorNoMaterial(cor);
            displayDeSlot[2].getMaterialGlow().setCorNoMaterial(cor);
        }
    }
    //***** FIM IMPLEMENTACAO INTERFACE ARCO IRIS CONJUNTO *****
}
