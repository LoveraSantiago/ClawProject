using System.Collections;
using UnityEngine;

public class DisplayDeColetados : ConsumidorDeEvento<InformacoesColetado>
{
    private int indiceEspaco;
    private DisplayDeColetado[] displayDeColetado;
    
    private bool coroutineEmAndamento;

    private Coroutine coroutineLimpeza;
    private MonoBehaviour monoBehaviour;

    private DisplayDeColetadoDto displayColetadoDto;    

    public DisplayDeColetados(DisplayDeColetadoDto displayColetadoDto, MonoBehaviour monoBehaviour)
    {
        inicializarDisplayDeColetado(displayColetadoDto.SpritesDisplayColetados);
        this.displayColetadoDto = displayColetadoDto;

        this.monoBehaviour = monoBehaviour;        
    }

    private void inicializarDisplayDeColetado(SpriteRenderer[] espacoImgs)
    {
        displayDeColetado = new DisplayDeColetado[espacoImgs.Length];
        displayDeColetado[0] = new DisplayDeColetado(espacoImgs[0]);
        displayDeColetado[1] = new DisplayDeColetado(espacoImgs[1]);
        displayDeColetado[2] = new DisplayDeColetado(espacoImgs[2]);
    }

    private void adicionarSpriteAoDisplay(Sprite spriteColetado, bool resetDisplay)
    {
        computarIndiceAntesAdicaoSprite();

        displayDeColetado[indiceEspaco].mostrarSprite(
            spriteColetado, displayColetadoDto.InicialDelay, displayColetadoDto.VelocSubidaImg, monoBehaviour);

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
        displayDeColetado[0].limparSprite();
        displayDeColetado[1].limparSprite();
        displayDeColetado[2].limparSprite();
    }

    public void consumirEvento(Sprite spriteColetado, bool resetDisplay)
    {
        adicionarSpriteAoDisplay(spriteColetado, resetDisplay);
    }

    //IMPLEMENTANDO INTERFACE ConsumidorDeEvento<InformacoesColetado> INICIO
    //CONSOME EVENTO DISPARADO PELO COLETAVEIS MANAGER AO COLETAR UM COLETAVEL
    public void consumirEvento(InformacoesColetado infoColetado)
    {
        adicionarSpriteAoDisplay(infoColetado.sprite, infoColetado.resetDisplay);
    }
    //IMPLEMENTANDO INTERFACE ConsumidorDeEvento<InformacoesColetado> FIM

    public ConsumidorDeEvento<InformacoesColetado> getDisplayImagensConsumidor()
    {
        return this;
    }
}
