using System.Collections;
using UnityEngine;

public class DisplayDeImagens : ConsumidorDeEvento<InformacoesColetado>
{
    private int indiceEspaco;
    private SpriteRenderer[] espacoImgs;

    private WaitForSeconds tempoReset;
    private bool coroutineEmAndamento;

    private Coroutine coroutineLimpeza;
    private MonoBehaviour monoBehaviour;

    public DisplayDeImagens(SpriteRenderer[] espacoImgs, float tempoReset, MonoBehaviour monoBehaviour)
    {
        this.espacoImgs = espacoImgs;
        this.tempoReset = new WaitForSeconds(tempoReset);
        this.monoBehaviour = monoBehaviour;
    }

    private void adicionarSpriteAoDisplay(Sprite spriteColetado, bool resetDisplay)
    {
        computarIndiceAntesAdicaoSprite();
        espacoImgs[indiceEspaco].sprite = spriteColetado;
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
        espacoImgs[0].sprite = null;
        espacoImgs[1].sprite = null;
        espacoImgs[2].sprite = null;
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
