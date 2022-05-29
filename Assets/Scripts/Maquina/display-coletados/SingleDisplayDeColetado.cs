using UnityEngine;
using System.Collections;

public class SingleDisplayDeColetado : ComponenteDtoDeSingleDisplayDeColetado
{
    public bool isOcupado { get; private set; }
    public bool isDesocupado { get { return !isOcupado; }}
    
    private MovimentadorDeSlots slots;    
    private SingleSlotColetadoDto singleSlotColetadoDto;
    private Coroutine coroutineCacaNiquel;

    public SingleDisplayDeColetado(SingleSlotColetadoDto singleSlotColetadoDto)
    {
        this.singleSlotColetadoDto = singleSlotColetadoDto;
        slots = new MovimentadorDeSlots();
    }    

    public void configuradoPeloLevel(Color corDisplay)
    {
        singleSlotColetadoDto.SprRendererSlotColetado.color = corDisplay;
    }

    public IEnumerator mostrarAlvo(Executor executorFimMovimentacao)
    {
        if (isOcupado)
        {   
            singleSlotColetadoDto.SprRendererSlotMeio.sprite = displaysColetadosDto.SprMiraGrossa;
            singleSlotColetadoDto.SprRendererSlotMeio.sharedMaterial = displaysColetadosDto.MaterialAlvoPiscando;
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

    public void mostrarAlvoSelecionado()
    {
        singleSlotColetadoDto.SprRendererSlotMeio.sprite = displaysColetadosDto.SprMiraGrossa;
        singleSlotColetadoDto.SprRendererSlotMeio.sharedMaterial = displaysColetadosDto.MaterialAlvoSelecionado;
    }

    public IEnumerator desligarAlvo(Executor executorFimMovimentacao)
    {
        if (isMiraSelecionado())
        {
            yield return new WaitForSeconds(displaysColetadosDto.InicialDelay * 2);
            singleSlotColetadoDto.SprRendererSlotMeio.sprite = null;
            singleSlotColetadoDto.SprRendererSlotMeio.sharedMaterial = MaterialSprUnlitDefault.getMaterial();
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
        singleSlotColetadoDto.SprRendererSlotBaixo.sprite = sprite;
        isOcupado = true;
        yield return slots.subirSlotColetado(singleSlotColetadoDto.GoSlotBaixo, displaysColetadosDto);        
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
        yield return slots.descerSlotColetado(singleSlotColetadoDto.GoSlotBaixo, displaysColetadosDto);        
    }     
    
    public IEnumerator mostrarSprNone(Executor executor)
    {
        singleSlotColetadoDto.SprRendererSlotCima.sprite = displaysColetadosDto.SprNone;
        singleSlotColetadoDto.SprRendererSlotCima.color = Color.red;
        yield return slots.descerSlotNone(singleSlotColetadoDto.GoSlotCima, displaysColetadosDto, executor);
    }    

    public IEnumerator limparSprNone(Executor executor)
    {
        yield return slots.subirSlotNone(singleSlotColetadoDto.GoSlotCima, displaysColetadosDto, executor);        
        singleSlotColetadoDto.SprRendererSlotCima.sprite = null;
    }

    public void ligarCacaNiquel(Sprite[] sprites)
    {   
        coroutineCacaNiquel = Utils.MonoBehaviour.StartCoroutine(ligarCacaNiquelCoroutine(sprites));
    } 
    
    public void pararCacaNiquel(Sprite[] sprites, Sprite sprSucesso)
    {
        int indiceEscolhido = MathUtils.escolherDeZeroAteLimite(sprites.Length);
        Utils.MonoBehaviour.StopCoroutine(coroutineCacaNiquel);
        singleSlotColetadoDto.SprRendererSlotMeio.sprite = sprites[indiceEscolhido];

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
        return singleSlotColetadoDto.SprRendererSlotMeio.sprite;
    }

    public void desligarSprsSlotMeio()
    {
        Debug.Log("desligarSprsSlotMeio");
        singleSlotColetadoDto.SprRendererSlotMeio.sprite = null;
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
        return isOcupado && singleSlotColetadoDto.SprRendererSlotColetado.bounds.Contains(posicao);
    }

    private bool isMiraSelecionado()
    {
        return singleSlotColetadoDto.SprRendererSlotMeio.sharedMaterial == displaysColetadosDto.MaterialAlvoPiscando ||
               singleSlotColetadoDto.SprRendererSlotMeio.sharedMaterial == displaysColetadosDto.MaterialAlvoSelecionado;
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

        singleSlotColetadoDto.SprRendererSlotBaixo.transform.localPosition = new Vector3(0, 0, 0);
        singleSlotColetadoDto.SprRendererSlotBaixo.sprite = sprites[indiceAtual++ % sprites.Length];

        singleSlotColetadoDto.SprRendererSlotMeio.transform.localPosition  = new Vector3(0, 0.6f, 0);
        singleSlotColetadoDto.SprRendererSlotMeio.sprite = sprites[indiceAtual++ % sprites.Length];

        singleSlotColetadoDto.SprRendererSlotCima.transform.localPosition  = new Vector3(0, 1.2f, 0);
        singleSlotColetadoDto.SprRendererSlotCima.sprite = sprites[indiceAtual++ % sprites.Length];

        SpriteRenderer[] sprRenderers = new SpriteRenderer[] {
            singleSlotColetadoDto.SprRendererSlotBaixo,
            singleSlotColetadoDto.SprRendererSlotMeio,
            singleSlotColetadoDto.SprRendererSlotCima
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
