using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class GrupoDisplays : ArcoIrisConjunto
{
    private bool powerUpDisplayColetado;

    private DisplaysSlotsDto displaysSlotsDto;
    public DisplayDeSlot[] displayDeSlot { get; private set; }

    public GrupoDisplays(DisplaysSlotsDto displaysSlotsDto, SingleDisplaySlotDto[] singleDisplaySlotDto, Material materialGlowDisplay)
    {
        this.displaysSlotsDto = displaysSlotsDto;
        displayDeSlot = new DisplayDeSlot[singleDisplaySlotDto.Length];
        displayDeSlot[0] = new DisplayDeSlot(singleDisplaySlotDto[0], materialGlowDisplay);
        displayDeSlot[1] = new DisplayDeSlot(singleDisplaySlotDto[1], materialGlowDisplay);
        displayDeSlot[2] = new DisplayDeSlot(singleDisplaySlotDto[2], materialGlowDisplay);
    }

    public void colorirDisplays(Dictionary<string, string> dicionarioDeCores)
    {
        new ColoridorDisplaysColetados().colorir(displayDeSlot, dicionarioDeCores);
    }

    public void setarEstadoPowerUp(bool estado)
    {
        powerUpDisplayColetado = estado;
    }      

    public void acionarMostrarAlvos()
    {
        Utils.MonoBehaviour.StartCoroutine(displayDeSlot[0].mostrarAlvo(displaysSlotsDto));
        Utils.MonoBehaviour.StartCoroutine(displayDeSlot[1].mostrarAlvo(displaysSlotsDto));
        Utils.MonoBehaviour.StartCoroutine(displayDeSlot[2].mostrarAlvo(displaysSlotsDto));
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

    public float getFimDelay()
    {
        return displaysSlotsDto.FimDelay;
    }

    public void ligarGlowLuz()
    {
        displayDeSlot[0].ligarGlowLuz();
        displayDeSlot[1].ligarGlowLuz();
        displayDeSlot[2].ligarGlowLuz();
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
        }
    }
    //***** FIM IMPLEMENTACAO INTERFACE ARCO IRIS CONJUNTO *****
}
