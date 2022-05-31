using UnityEngine;
using System.Collections;

public class SingleDisplayDeColetado : ComponenteMovimentadorDeSingleDisplayDeColetado
{
    public bool isOcupado { get; private set; }
    public bool isDesocupado { get { return !isOcupado; }}    
        
    private Coroutine coroutineCacaNiquel;

    public SingleDisplayDeColetado(SingleSlotColetadoDto singleSlotColetadoDto)
        :base(singleSlotColetadoDto){}    

    public IEnumerator mostrarAlvo(Executor executorFimMovimentacao)
    {
        if (isOcupado)
        {
            mostrarAlvo();            
            if (executorFimMovimentacao != null)
            {
                executorFimMovimentacao.execute();
            }
        }
        else
        {
            yield return mostrarSprNone(executorFimMovimentacao);
        }
        ligarGlowLuz();
    }    

    public IEnumerator desligarAlvo(Executor executorFimMovimentacao)
    {
        if (isMiraSelecionado())
        {
            yield return new WaitForSeconds(getDisplaysColetadosDto().InicialDelay * 2);
            desligarAlvo();            
            executorFimMovimentacao.execute();
        }
        else{
            yield return limparSprNone(executorFimMovimentacao);
        }
        desligarGlow();
    }

    public IEnumerator mostrarSprColetado(Sprite sprite, bool mostrarMira)
    {        
        yield return limparSprNoneCasoOcupado();
        mostrarColetado(sprite);
        isOcupado = true;
        yield return subirSlotColetado();        
        desligarGlow();

        if (mostrarMira)
        {
            yield return mostrarAlvo(null);
            ligarGlowLuz();
        }        
    }      

    public IEnumerator limparSprColetado()
    {
        isOcupado = false;
        yield return descerSlotColetado();        
    }     
    
    public IEnumerator mostrarSprNone(Executor executor)
    {
        mostrarNone();
        yield return descerSlotNone(executor);
    }    

    public IEnumerator limparSprNone(Executor executor)
    {
        yield return subirSlotNone(executor);
        limparNone();
    }

    public void ligarCacaNiquel(Sprite[] sprites)
    {   
        coroutineCacaNiquel = Utils.MonoBehaviour.StartCoroutine(ligarCacaNiquelCoroutine(sprites));
    } 
    
    public void pararCacaNiquel(Sprite[] sprites, Sprite sprSucesso)
    {
        SpriteRenderer sprRendererEscolhido = getSprRendererMaisProximo();
        Sprite sprEscolhido = sprRendererEscolhido.sprite;
        Utils.MonoBehaviour.StopCoroutine(coroutineCacaNiquel);
        Utils.MonoBehaviour.StartCoroutine(reposicionarCacaNiquel());        
        if(sprSucesso == null)
        {
            ligarGlowSucesso();
        }
        else if(sprSucesso == sprEscolhido)
        {
            ligarGlowSucesso();
        }
        else
        {
            ligarGlowFail();
        }
    }

    public Sprite getSprResultCacaNiquel()
    {
        return getSprRendererMaisProximo().sprite;
    }    

    public void ligarGlowSucesso()
    {
    }

    public void ligarGlowFail()
    {
    }

    public void ligarGlowLuz()
    {
    }    

    public void desligarGlow()
    {
    }

    public bool isCliqueDentroArea(Vector2 posicao)
    {   
        return isOcupado && getSingleSlotColetadoDto().SprRendererSlotColetado.bounds.Contains(posicao);
    }   

    private IEnumerator limparSprNoneCasoOcupado()
    {
        cancelarMovimentacaoDeSlot();
        yield return limparSprNone(null);
        //Debug.Log("Pos Cancelado limpando spr none");
    }

    private IEnumerator ligarCacaNiquelCoroutine(Sprite[] sprites)
    {
        int indiceAtual = 0;
        configSlotBaixo(getDisplaysColetadosDto().PosYSlot, sprites[indiceAtual++ % sprites.Length]);
        configSlotMeio(getDisplaysColetadosDto().PosYSlotAcrescimo, sprites[indiceAtual++ % sprites.Length]);
        configSlotCima(getDisplaysColetadosDto().PosYSlotAcrescimo * 2, sprites[indiceAtual++ % sprites.Length]);        

        SpriteRenderer[] sprRenderers = getSlotsSprRenderers();

        while (true)
        {
            float velocidade = getSingleSlotColetadoDto().VelocidadeSlot * Time.deltaTime;
            Vector3 deslocamento = new Vector3(0, -velocidade, 0);
            for(int contador = 0; contador < sprRenderers.Length; contador++)
            {
                sprRenderers[contador].transform.localPosition += deslocamento;
            }
            if(isSlot0AbaixoLimite(sprRenderers[0]))
            {
                float yPosMaisAlta = sprRenderers[2].transform.localPosition.y + getDisplaysColetadosDto().PosYSlotAcrescimo;
                sprRenderers[0].transform.localPosition = new Vector3(0, yPosMaisAlta, 0);
                sprRenderers[0].sprite = sprites[indiceAtual++ % sprites.Length];
                rotacionarArray(sprRenderers);
            }
            yield return null;
        }
    }

    private IEnumerator reposicionarCacaNiquel()
    {
        SpriteRenderer sprRenderer = getSprRendererMaisProximo();
        float diferenca = 0 + sprRenderer.transform.localPosition.y;
        float velocidade = diferenca > 0 ? -getSingleSlotColetadoDto().VelocidadeSlot : getSingleSlotColetadoDto().VelocidadeSlot;
        float contadorStep = 0;

        SpriteRenderer[] sprRenderers = getSlotsSprRenderers();

        while (contadorStep < Mathf.Abs(diferenca))
        {
            float deslocamentoY = (velocidade * Time.deltaTime) / 10;
            Vector3 deslocamento = new Vector3(0, deslocamentoY, 0);
            for (int contador = 0; contador < sprRenderers.Length; contador++)
            {
                sprRenderers[contador].transform.localPosition += deslocamento;
            }
            yield return null;            
            contadorStep += Mathf.Abs(deslocamentoY);
        }
        sprRenderer.transform.localPosition = new Vector3(0, getDisplaysColetadosDto().PosYSlot, 0);
        yield return null;        
    }

    private bool isSlot0AbaixoLimite(SpriteRenderer sprRenderer)
    {
        return sprRenderer.transform.localPosition.y < getDisplaysColetadosDto().PosYSlotAcrescimoNeg;
    }

    private void rotacionarArray(SpriteRenderer[] sprRenderers)
    {
        SpriteRenderer tempSprRenderer = sprRenderers[0];
        sprRenderers[0] = sprRenderers[1];
        sprRenderers[1] = sprRenderers[2];
        sprRenderers[2] = tempSprRenderer;
    }

    public new static void configurar(DisplaysColetadosDto displayColetadosDtoArg)
    {
        ComponenteDtoDeSingleDisplayDeColetado.configurar(displayColetadosDtoArg);
    }
}
