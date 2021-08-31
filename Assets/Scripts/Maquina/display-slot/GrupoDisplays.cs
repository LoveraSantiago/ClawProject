using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class GrupoDisplays : ArcoIrisConjunto
{
    private bool powerUpDisplayColetado;
    public DisplayDeSlot[] displayDeSlot { get; private set; }

    public GrupoDisplays(SingleDisplaySlotDto[] singleDisplaySlotDto, Material materialGlowDisplay)
    {
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

    public void acionarMostrarAlvos(DisplaysSlotsDto displaysSlotsDto, MonoBehaviour monoBehaviour)
    {
        monoBehaviour.StartCoroutine(displayDeSlot[0].mostrarAlvo(displaysSlotsDto));
        monoBehaviour.StartCoroutine(displayDeSlot[1].mostrarAlvo(displaysSlotsDto));
        monoBehaviour.StartCoroutine(displayDeSlot[2].mostrarAlvo(displaysSlotsDto));
    }

    public void desligarAlvos(DisplaysSlotsDto displaysSlotsDto, MonoBehaviour monoBehaviour)
    {
        monoBehaviour.StartCoroutine(displayDeSlot[0].desligarAlvo(displaysSlotsDto));
        monoBehaviour.StartCoroutine(displayDeSlot[1].desligarAlvo(displaysSlotsDto));
        monoBehaviour.StartCoroutine(displayDeSlot[2].desligarAlvo(displaysSlotsDto));
    }

    public IEnumerator mostrarSprColetado(int indice, Sprite sprite, bool powerUpAcionado, DisplaysSlotsDto displaysSlotsDto)
    {
        yield return displayDeSlot[indice].mostrarSprColetado(sprite, powerUpAcionado, displaysSlotsDto);
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
}
