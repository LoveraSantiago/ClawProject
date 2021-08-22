using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class GrupoDisplays : ArcoIrisConjunto
{
    private bool powerUpDisplayColetado;
    public DisplayDeColetado[] displayDeColetado { get; private set; }

    public GrupoDisplays(SingleDisplayColetadoDto[] singlesDisplayColetadosDto)
    {
        displayDeColetado = new DisplayDeColetado[singlesDisplayColetadosDto.Length];
        displayDeColetado[0] = new DisplayDeColetado(singlesDisplayColetadosDto[0]);
        displayDeColetado[1] = new DisplayDeColetado(singlesDisplayColetadosDto[1]);
        displayDeColetado[2] = new DisplayDeColetado(singlesDisplayColetadosDto[2]);
    }

    public void colorirDisplays(Dictionary<string, string> dicionarioDeCores)
    {
        new ColoridorDisplaysColetados().colorir(displayDeColetado, dicionarioDeCores);
    }

    public void setarEstadoPowerUp(bool estado)
    {
        powerUpDisplayColetado = estado;
    }   

    public void desligar()
    {
        displayDeColetado[0].desligarGlow();
        displayDeColetado[1].desligarGlow();
        displayDeColetado[2].desligarGlow();
    }

    public void acionarMostrarAlvos(MonoBehaviour monoBehaviour)
    {
        monoBehaviour.StartCoroutine(displayDeColetado[0].mostrarAlvo());
        monoBehaviour.StartCoroutine(displayDeColetado[1].mostrarAlvo());
        monoBehaviour.StartCoroutine(displayDeColetado[2].mostrarAlvo());
    }

    public void desligarAlvos(MonoBehaviour monoBehaviour)
    {
        monoBehaviour.StartCoroutine(displayDeColetado[0].desligarAlvo());
        monoBehaviour.StartCoroutine(displayDeColetado[1].desligarAlvo());
        monoBehaviour.StartCoroutine(displayDeColetado[2].desligarAlvo());
    }

    public IEnumerator mostrarSprColetado(int indice, Sprite sprite, bool powerUpAcionado)
    {
        yield return displayDeColetado[indice].mostrarSprColetado(sprite, powerUpAcionado);
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

    public void passarCor(Color cor)
    {
        if (!powerUpDisplayColetado)
        {
            displayDeColetado[0].getMaterialGlow().setCorNoMaterial(cor);
        }
    }
}
