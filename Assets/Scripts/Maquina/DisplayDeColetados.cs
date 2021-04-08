using System.Collections;
using UnityEngine;

public class DisplayDeColetados : ConsumidorDeEvento<InformacoesColetado>
{
    private int indiceEspaco;
    private DisplayDeColetado[] displayDeColetado;

    private WaitForSeconds tempoReset;
    private bool coroutineEmAndamento;

    private Coroutine coroutineLimpeza;
    private MonoBehaviour monoBehaviour;

    private float velocidade;

    public DisplayDeColetados(SpriteRenderer[] espacoImgs, float velocidade, float tempoReset, MonoBehaviour monoBehaviour)
    {
        inicializarDisplayDeColetado(espacoImgs);
        this.tempoReset = new WaitForSeconds(tempoReset);
        this.monoBehaviour = monoBehaviour;
        this.velocidade = velocidade;
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
        displayDeColetado[indiceEspaco].mostrarSprite(spriteColetado, velocidade, monoBehaviour);
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
        yield return tempoReset;
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
