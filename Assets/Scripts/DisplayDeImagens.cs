using System.Collections;
using UnityEngine;

public class DisplayDeImagens : ConsumidorDeEvento<Sprite>
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

    private void adicionarSpriteAoDisplay(Sprite spriteColetado)
    {
        computarIndiceAntesAdicaoSprite();
        espacoImgs[indiceEspaco].sprite = spriteColetado;
        computarIndicePosAdicaoSprite();        
    }

    private void computarIndiceAntesAdicaoSprite()
    {
        if(indiceEspaco == 0 && coroutineEmAndamento)
        {
            monoBehaviour.StopCoroutine(coroutineLimpeza);
            limparTodosOsIndices();
        }
    }

    private void computarIndicePosAdicaoSprite()
    {
        if(indiceEspaco + 1 >= 3)
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

    //IMPLEMENTANDO INTERFACE ConsumidorDeEvento<Sprite> INICIO
    //ACIONADO COMO SEGUNDO STEP PELO PIPELINE DE COLETAVEL COLETADO
    //RECEBENDO O SPRITE DO COLETADO
    public void consumirEvento(Sprite spriteColetado)
    {
        adicionarSpriteAoDisplay(spriteColetado);
    }
    //IMPLEMENTANDO INTERFACE ConsumidorDeEvento<Sprite> FIM

    public ConsumidorDeEvento<Sprite> getConsumidorDeColetado()
    {
        return this;
    }
}
