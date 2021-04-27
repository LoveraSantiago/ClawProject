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
    }

    private void inicializarDisplayDeColetado(GameObject[] arrayDisplayColetado)
    {
        displayDeColetado    = new DisplayDeColetado[arrayDisplayColetado.Length];
        displayDeColetado[0] = new DisplayDeColetado(arrayDisplayColetado[0]);
        displayDeColetado[1] = new DisplayDeColetado(arrayDisplayColetado[1]);
        displayDeColetado[2] = new DisplayDeColetado(arrayDisplayColetado[2]);
    }

    public void adicionarSpriteAoDisplay(Sprite spriteColetado, bool resetDisplay)
    {
        computarIndiceAntesAdicaoSprite();

        displayDeColetado[indiceEspaco].mostrarSprite(
            spriteColetado, displayColetadoDto.InicialDelay, displayColetadoDto.VelocImg,
            displayColetadoDto.MaterialGlowDisplay,
            monoBehaviour);

        computarIndicePosAdicaoSprite(resetDisplay);        
    }

    private void computarIndiceAntesAdicaoSprite()
    {
        if(indiceEspaco == 0 && coroutineEmAndamento)
        {
            monoBehaviour.StopCoroutine(coroutineLimpeza);
            limparTodosOsIndices();
        }
    }

    private void computarIndicePosAdicaoSprite(bool forceResetDisplay)
    {   
        if(forceResetDisplay || (indiceEspaco + 1 >= 3))
        {
            indiceEspaco = 0;            
            coroutineLimpeza = monoBehaviour.StartCoroutine(limpezaDeEspacos());
        }
        else
        {
            indiceEspaco++;
        }
    }    

    private IEnumerator limpezaDeEspacos()
    {
        coroutineEmAndamento = true;
        yield return new WaitForSeconds(displayColetadoDto.TempoReset);
        limparTodosOsIndices();
        
        coroutineEmAndamento = false;
        yield return null;
    }

    private void limparTodosOsIndices()
    {
        displayDeColetado[0].limparSprite(displayColetadoDto.FimDelay, displayColetadoDto.VelocImg, monoBehaviour);
        displayDeColetado[1].limparSprite(displayColetadoDto.FimDelay * 2, displayColetadoDto.VelocImg, monoBehaviour);
        displayDeColetado[2].limparSprite(displayColetadoDto.FimDelay * 3, displayColetadoDto.VelocImg, monoBehaviour);
    }

    public void consumirEvento(Sprite spriteColetado, bool resetDisplay)
    {
        adicionarSpriteAoDisplay(spriteColetado, resetDisplay);
    }
}
