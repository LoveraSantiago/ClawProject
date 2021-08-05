using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class DisplaysDeColetados : ArcoIrisConjunto
{
    private DisplayDeColetadoDto displayColetadoDto;    
    private DisplayDeColetado[] displayDeColetado;

    private MonoBehaviour monoBehaviour;

    public DisplaysDeColetados(DisplayDeColetadoDto displayColetadoDto, MonoBehaviour monoBehaviour)
    {
        DisplayDeColetado.configurarDisplay(displayColetadoDto);
        inicializarDisplayDeColetado(displayColetadoDto.SingleDisplaysColetadoDto);
        this.displayColetadoDto = displayColetadoDto;

        this.monoBehaviour = monoBehaviour;
    }

    private void inicializarDisplayDeColetado(SingleDisplayColetadoDto[] singlesDisplayColetadosDto)
    {
        displayDeColetado    = new DisplayDeColetado[singlesDisplayColetadosDto.Length];
        displayDeColetado[0] = new DisplayDeColetado(singlesDisplayColetadosDto[0]);
        displayDeColetado[1] = new DisplayDeColetado(singlesDisplayColetadosDto[1]);
        displayDeColetado[2] = new DisplayDeColetado(singlesDisplayColetadosDto[2]);
    }

    public void configuradoPeloLevel(Dictionary<string, string> dicionarioDeCores)
    {
        string hexCorDisplay = dicionarioDeCores[ConstantesCoresMaquina.DISPLAY_COLETADOS];
        Color corDisplay = Utils.getCorByHex(hexCorDisplay);

        string hexCorDentro = dicionarioDeCores[ConstantesCoresMaquina.PLACA_COLETADO1];        
        displayDeColetado[0].configuradoPeloLevel(corDisplay, Utils.getCorByHex(hexCorDentro));

        hexCorDentro = dicionarioDeCores[ConstantesCoresMaquina.PLACA_COLETADO2];        
        displayDeColetado[1].configuradoPeloLevel(corDisplay, Utils.getCorByHex(hexCorDentro));

        hexCorDentro = dicionarioDeCores[ConstantesCoresMaquina.PLACA_COLETADO3];        
        displayDeColetado[2].configuradoPeloLevel(corDisplay, Utils.getCorByHex(hexCorDentro));
    }

    public void adicionarSpriteAoDisplay(Sprite spriteColetado, bool result)
    {
        int indiceDesocupado = getIndicePrimeiroDisplayDesocupado();
        monoBehaviour.StartCoroutine(displayDeColetado[indiceDesocupado].mostrarSprite(spriteColetado));        
    }       

    private IEnumerator mostrarSprite(int indiceDesocupado, Sprite spriteColetado, bool result)
    {
        yield return monoBehaviour.StartCoroutine(displayDeColetado[indiceDesocupado].mostrarSprite(spriteColetado));

        if (isTodosDisplayOcupados())
        {
            if (result)
            {
                ligarGlowsSucesso();
            }
            else
            {
                ligarGlowsFail();
            }
        
            monoBehaviour.StartCoroutine(displayDeColetado[0].limparSprite(displayColetadoDto.FimDelay));
            monoBehaviour.StartCoroutine(displayDeColetado[1].limparSprite(displayColetadoDto.FimDelay * 2));
            yield return monoBehaviour.StartCoroutine(displayDeColetado[2].limparSprite(displayColetadoDto.FimDelay * 3));
            yield return new WaitForSeconds(displayColetadoDto.FimDelay);
            desligarGlows();
        }
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

    private void ligarGlowsSucesso()
    {
        displayDeColetado[0].ligarGlowSucesso();
        displayDeColetado[1].ligarGlowSucesso();
        displayDeColetado[2].ligarGlowSucesso();
    }

    private void ligarGlowsFail()
    {
        displayDeColetado[0].ligarGlowFail();
        displayDeColetado[1].ligarGlowFail();
        displayDeColetado[2].ligarGlowFail();
    }

    private void desligarGlows()
    {
        displayDeColetado[0].desligarGlow();
        displayDeColetado[1].desligarGlow();
        displayDeColetado[2].desligarGlow();
    }

    public void ligar()
    {
        ligarGlowsSucesso();
    }

    public void desligar()
    {
        desligarGlows();
    }

    public void passarCor(Color cor)
    {
        displayDeColetado[0].getMaterialGlow().setCorNoMaterial(cor);
    }
}
