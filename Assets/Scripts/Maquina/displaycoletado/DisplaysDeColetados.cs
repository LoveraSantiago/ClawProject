using System.Collections;
using UnityEngine;

public class DisplaysDeColetados 
{
    private int indiceEspaco;
    private bool coroutineEmAndamento;

    private DisplayDeColetadoDto displayColetadoDto;    
    private DisplayDeColetado[] displayDeColetado;    

    private Coroutine coroutineLimpeza;
    private MonoBehaviour monoBehaviour;

    public DisplaysDeColetados(DisplayDeColetadoDto displayColetadoDto, MonoBehaviour monoBehaviour)
    {
        inicializarDisplayDeColetado(displayColetadoDto.GosDisplayColetados);
        this.displayColetadoDto = displayColetadoDto;

        this.monoBehaviour = monoBehaviour;
        DisplayDeColetado.configurarDisplay(displayColetadoDto.MaterialGlowDisplay);
    }

    private void inicializarDisplayDeColetado(GameObject[] arrayDisplayColetado)
    {
        displayDeColetado    = new DisplayDeColetado[arrayDisplayColetado.Length];
        displayDeColetado[0] = new DisplayDeColetado(arrayDisplayColetado[0]);
        displayDeColetado[1] = new DisplayDeColetado(arrayDisplayColetado[1]);
        displayDeColetado[2] = new DisplayDeColetado(arrayDisplayColetado[2]);
    }

    public void adicionarSpriteAoDisplay(Sprite spriteColetado, bool resetDisplay, bool result)
    {
        computarIndiceAntesAdicaoSprite();

        monoBehaviour.StartCoroutine(
            displayDeColetado[indiceEspaco].mostrarSprite(spriteColetado, displayColetadoDto.InicialDelay, displayColetadoDto.VelocImg));

        computarIndicePosAdicaoSprite(resetDisplay, result);        
    }

    private void computarIndiceAntesAdicaoSprite()
    {
        if(indiceEspaco == 0 && coroutineEmAndamento)
        {
            monoBehaviour.StopCoroutine(coroutineLimpeza);
            limparTodosOsIndices();
        }
    }

    private void computarIndicePosAdicaoSprite(bool forceResetDisplay, bool result)
    {   
        if(forceResetDisplay || (indiceEspaco + 1 >= 3))
        {
            indiceEspaco = 0;            
            coroutineLimpeza = monoBehaviour.StartCoroutine(limpezaDeEspacos(result));
        }
        else
        {
            indiceEspaco++;
        }
    }    

    private IEnumerator limpezaDeEspacos(bool result)
    {
        if (result)
        {
            ligarGlowsSucesso();
        }
        else
        {
            ligarGlowsFail();
        }

        coroutineEmAndamento = true;

        yield return new WaitForSeconds(displayColetadoDto.TempoReset);
        limparTodosOsIndices();
        
        coroutineEmAndamento = false;        
        yield return null;
    }

    private void limparTodosOsIndices()
    {
        monoBehaviour.StartCoroutine(displayDeColetado[0].limparSprite(displayColetadoDto.FimDelay, displayColetadoDto.VelocImg));
        monoBehaviour.StartCoroutine(displayDeColetado[1].limparSprite(displayColetadoDto.FimDelay * 2, displayColetadoDto.VelocImg));
        monoBehaviour.StartCoroutine(displayDeColetado[2].limparSprite(displayColetadoDto.FimDelay * 3, displayColetadoDto.VelocImg));
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

    public void passarInformacao(Sprite spriteColetado, bool resetDisplay, bool result)
    {
        adicionarSpriteAoDisplay(spriteColetado, resetDisplay, result);
    }
}
