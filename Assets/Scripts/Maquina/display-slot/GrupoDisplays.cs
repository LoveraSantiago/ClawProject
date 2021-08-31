using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class GrupoDisplays : ArcoIrisConjunto
{
    private bool powerUpDisplayColetado;
    public DisplayDeColetado[] displayDeColetado { get; private set; }

    public GrupoDisplays(SingleDisplaySlotDto[] singleDisplaySlotDto, Material materialGlowDisplay)
    {
        displayDeColetado = new DisplayDeColetado[singleDisplaySlotDto.Length];
        displayDeColetado[0] = new DisplayDeColetado(singleDisplaySlotDto[0], materialGlowDisplay);
        displayDeColetado[1] = new DisplayDeColetado(singleDisplaySlotDto[1], materialGlowDisplay);
        displayDeColetado[2] = new DisplayDeColetado(singleDisplaySlotDto[2], materialGlowDisplay);
    }

    public void colorirDisplays(Dictionary<string, string> dicionarioDeCores)
    {
        new ColoridorDisplaysColetados().colorir(displayDeColetado, dicionarioDeCores);
    }

    public void setarEstadoPowerUp(bool estado)
    {
        powerUpDisplayColetado = estado;
    }      

    public void acionarMostrarAlvos(DisplaysSlotsDto displaysSlotsDto, MonoBehaviour monoBehaviour)
    {
        monoBehaviour.StartCoroutine(displayDeColetado[0].mostrarAlvo(displaysSlotsDto));
        monoBehaviour.StartCoroutine(displayDeColetado[1].mostrarAlvo(displaysSlotsDto));
        monoBehaviour.StartCoroutine(displayDeColetado[2].mostrarAlvo(displaysSlotsDto));
    }

    public void desligarAlvos(DisplaysSlotsDto displaysSlotsDto, MonoBehaviour monoBehaviour)
    {
        monoBehaviour.StartCoroutine(displayDeColetado[0].desligarAlvo(displaysSlotsDto));
        monoBehaviour.StartCoroutine(displayDeColetado[1].desligarAlvo(displaysSlotsDto));
        monoBehaviour.StartCoroutine(displayDeColetado[2].desligarAlvo(displaysSlotsDto));
    }

    public IEnumerator mostrarSprColetado(int indice, Sprite sprite, bool powerUpAcionado, DisplaysSlotsDto displaysSlotsDto)
    {
        yield return displayDeColetado[indice].mostrarSprColetado(sprite, powerUpAcionado, displaysSlotsDto);
    }

    public int getIndicePrimeiroDisplayDesocupado()
    {
        if (displayDeColetado[0].isDesocupado()) return 0;
        if (displayDeColetado[1].isDesocupado()) return 1;
        return 2;
    }

    public bool isTodosDisplayOcupados()
    {
        return displayDeColetado[0].isOcupadoColetado() && displayDeColetado[1].isOcupadoColetado() && displayDeColetado[2].isOcupadoColetado();
    }

    public bool isTodosDisplaysDesocupados()
    {
        return displayDeColetado[0].isDesocupado() && displayDeColetado[1].isDesocupado() && displayDeColetado[2].isDesocupado();
    }

    public void ligar()
    {
        if (!powerUpDisplayColetado)
        {
            displayDeColetado[0].ligarGlowSucesso();
            displayDeColetado[1].ligarGlowSucesso();
            displayDeColetado[2].ligarGlowSucesso();
        }
    }

    public void desligar()
    {
        displayDeColetado[0].desligarGlow();
        displayDeColetado[1].desligarGlow();
        displayDeColetado[2].desligarGlow();
    }

    public void passarCor(Color cor)
    {
        if (!powerUpDisplayColetado)
        {
            displayDeColetado[0].getMaterialGlow().setCorNoMaterial(cor);
        }
    }
}
