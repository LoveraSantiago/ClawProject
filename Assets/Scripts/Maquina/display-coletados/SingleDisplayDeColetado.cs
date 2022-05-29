using UnityEngine;
using System.Collections;

public class SingleDisplayDeColetado : ComponenteDtoDeSingleDisplayDeColetado
{
    public bool isOcupado { get; private set; }
    public bool isDesocupado { get { return !isOcupado; }}
    
    private MovimentadorDeSlots slots;        
    private Coroutine coroutineCacaNiquel;

    public SingleDisplayDeColetado(SingleSlotColetadoDto singleSlotColetadoDto)
        :base(singleSlotColetadoDto)
    {   
        slots = new MovimentadorDeSlots();
    }    

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
        yield return slots.subirSlotColetado(getSingleSlotColetadoDto().GoSlotBaixo, getDisplaysColetadosDto());        
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
        yield return slots.descerSlotColetado(getSingleSlotColetadoDto().GoSlotBaixo, getDisplaysColetadosDto());        
    }     
    
    public IEnumerator mostrarSprNone(Executor executor)
    {
        mostrarNone();
        yield return slots.descerSlotNone(getSingleSlotColetadoDto().GoSlotCima, getDisplaysColetadosDto(), executor);
    }    

    public IEnumerator limparSprNone(Executor executor)
    {
        yield return slots.subirSlotNone(getSingleSlotColetadoDto().GoSlotCima, getDisplaysColetadosDto(), executor);
        limparNone();
    }

    public void ligarCacaNiquel(Sprite[] sprites)
    {   
        coroutineCacaNiquel = Utils.MonoBehaviour.StartCoroutine(ligarCacaNiquelCoroutine(sprites));
    } 
    
    public void pararCacaNiquel(Sprite[] sprites, Sprite sprSucesso)
    {
        int indiceEscolhido = MathUtils.escolherDeZeroAteLimite(sprites.Length);
        Utils.MonoBehaviour.StopCoroutine(coroutineCacaNiquel);
        getSingleSlotColetadoDto().SprRendererSlotMeio.sprite = sprites[indiceEscolhido];

        if(sprSucesso == null)
        {
            ligarGlowSucesso();
        }
        else if(sprSucesso == sprites[indiceEscolhido])
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
        return getSingleSlotColetadoDto().SprRendererSlotMeio.sprite;
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
        slots.cancelarMovimentacaoDeSlot();
        yield return limparSprNone(null);
        //Debug.Log("Pos Cancelado limpando spr none");
    }

    private IEnumerator ligarCacaNiquelCoroutine(Sprite[] sprites)
    {
        int indiceAtual = 0;
        Debug.Log("caca niquel ligado");

        getSingleSlotColetadoDto().SprRendererSlotBaixo.transform.localPosition = new Vector3(0, 0, 0);
        getSingleSlotColetadoDto().SprRendererSlotBaixo.sprite = sprites[indiceAtual++ % sprites.Length];

        getSingleSlotColetadoDto().SprRendererSlotMeio.transform.localPosition  = new Vector3(0, 0.6f, 0);
        getSingleSlotColetadoDto().SprRendererSlotMeio.sprite = sprites[indiceAtual++ % sprites.Length];

        getSingleSlotColetadoDto().SprRendererSlotCima.transform.localPosition  = new Vector3(0, 1.2f, 0);
        getSingleSlotColetadoDto().SprRendererSlotCima.sprite = sprites[indiceAtual++ % sprites.Length];

        SpriteRenderer[] sprRenderers = new SpriteRenderer[] {
            getSingleSlotColetadoDto().SprRendererSlotBaixo,
            getSingleSlotColetadoDto().SprRendererSlotMeio,
            getSingleSlotColetadoDto().SprRendererSlotCima
        };

        while (true)
        {
            Vector3 deslocamento = new Vector3(0, -4f * Time.deltaTime, 0);
            for(int contador = 0; contador < sprRenderers.Length; contador++)
            {
                sprRenderers[contador].transform.localPosition += deslocamento;
            }
            if(sprRenderers[0].transform.localPosition.y < -0.6f)
            {
                SpriteRenderer tempSprRenderer = sprRenderers[0];
                tempSprRenderer.transform.localPosition = new Vector3(0, sprRenderers[2].transform.localPosition.y + 0.6f, 0);
                tempSprRenderer.sprite = sprites[indiceAtual++ % sprites.Length];
                sprRenderers[0] = sprRenderers[1];
                sprRenderers[1] = sprRenderers[2];
                sprRenderers[2] = tempSprRenderer;
            }
            yield return null;
        }
    }

    public new static void configurar(DisplaysColetadosDto displayColetadosDtoArg)
    {
        ComponenteDtoDeSingleDisplayDeColetado.configurar(displayColetadosDtoArg);
    }
}
