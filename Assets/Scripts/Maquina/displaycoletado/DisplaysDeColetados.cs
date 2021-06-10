using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class DisplaysDeColetados 
{
    private int indiceEspaco;    

    private DisplayDeColetadoDto displayColetadoDto;    
    private DisplayDeColetado[] displayDeColetado;

    private Coroutine coroutineArcoIris;
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
        displayDeColetado[0].configuradoPeloLevel(corDisplay, Utils.getCorByHex(hexCorDisplay));

        hexCorDentro = dicionarioDeCores[ConstantesCoresMaquina.PLACA_COLETADO2];        
        displayDeColetado[1].configuradoPeloLevel(corDisplay, Utils.getCorByHex(hexCorDisplay));

        hexCorDentro = dicionarioDeCores[ConstantesCoresMaquina.PLACA_COLETADO3];        
        displayDeColetado[2].configuradoPeloLevel(corDisplay, Utils.getCorByHex(hexCorDisplay));
    }

    public void adicionarSpriteAoDisplay(Sprite spriteColetado, bool result)
    {
        if(indiceEspaco + 1 >= 3)
        {
            monoBehaviour.StartCoroutine(mostrarTerceiroSprite(spriteColetado, result));
            indiceEspaco = 0;
        }
        else
        {
            monoBehaviour.StartCoroutine(displayDeColetado[indiceEspaco].mostrarSprite(spriteColetado));
            indiceEspaco++;
        }        
    }    

    public void acionadoPeloPowerUp()
    {
        ligarGlowsSucesso();
        coroutineArcoIris = monoBehaviour.StartCoroutine(ligarGlowArcoIris());        
    }

    public void acionadoFimPowerUp()
    {
        desligarGlows();
        monoBehaviour.StopCoroutine(coroutineArcoIris);
    }

    private IEnumerator mostrarTerceiroSprite(Sprite spriteColetado, bool result)
    {
        yield return monoBehaviour.StartCoroutine(displayDeColetado[2].mostrarSprite(spriteColetado));

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

    private IEnumerator ligarGlowArcoIris()
    {
        while (true)
        {            
            displayDeColetado[0].atualizarCorMaterial();            
            yield return null;
        }
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
}
