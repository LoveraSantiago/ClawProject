using UnityEngine;
using System.Collections;

public class DisplayDeSlot 
{
    public bool isOcupado { get; private set; }
    public bool isDesocupado { get { return !isOcupado; }}
    
    private MovimentadorDeSlots slots;
    private AnimacaoDisplayColetado animacao;

    private SingleDisplaySlotDto singleDisplaySlotDto;
    private SingleSlotColetadoDto singleSlotColetadoDto;

    private Coroutine coroutineCacaNiquel;

    public DisplayDeSlot(SingleDisplaySlotDto singleDisplaySlotDto, SingleSlotColetadoDto singleSlotColetadoDto)
    {
        this.singleDisplaySlotDto = singleDisplaySlotDto;
        this.singleSlotColetadoDto = singleSlotColetadoDto;

        animacao   = new AnimacaoDisplayColetado(singleSlotColetadoDto.Animator);        
        slots      = new MovimentadorDeSlots(singleDisplaySlotDto, singleSlotColetadoDto);
    }    

    public void configuradoPeloLevel(Color corDisplay)
    {
        singleSlotColetadoDto.SprRendererSlotColetado.color = corDisplay;
    }

    public IEnumerator mostrarAlvo(DisplaysColetadosDto displaysSlotsDto, Executor executorFimMovimentacao)
    {
        if (isOcupado)
        {
            animacao.ligarAnimacaoMira();
            if(executorFimMovimentacao != null)
            {
                executorFimMovimentacao.execute();
            }
        }
        else
        {
            yield return mostrarSprNone(displaysSlotsDto, executorFimMovimentacao);
        }
        ligarGlowLuz();
    }

    public void mostrarAlvoSelecionado()
    {
        animacao.ligarAnimacaoMiraSelecionado();
    }

    public IEnumerator desligarAlvo(DisplaysColetadosDto displaysSlotsDto, Executor executorFimMovimentacao)
    {
        if (animacao.isMiraLigado)
        {
            animacao.desligarAnimacao();
            executorFimMovimentacao.execute();
        }
        else{
            yield return limparSprNone(displaysSlotsDto, executorFimMovimentacao);
        }
        desligarGlow();
    }

    public IEnumerator mostrarSprColetado(
        Sprite sprite, bool mostrarMira, DisplaysColetadosDto displaysSlotsDto)
    {        
        yield return limparSprNoneCasoOcupado(displaysSlotsDto);
        //singleDisplaySlotDto.SlotSpriteBaixo.sprite = sprite;
        singleSlotColetadoDto.SprRendererSlotBaixo.sprite = sprite;
        isOcupado = true;
        //yield return slots.subirSlotColetado(singleDisplaySlotDto.GoSlotBaixo, displaysSlotsDto);        
        yield return slots.subirSlotColetado(singleSlotColetadoDto.GoSlotBaixo, displaysSlotsDto);        
        desligarGlow();

        if (mostrarMira)
        {
            yield return mostrarAlvo(displaysSlotsDto, null);
            ligarGlowLuz();
        }        
    }      

    public IEnumerator limparSprColetado(DisplaysColetadosDto displaysSlotsDto)
    {
        isOcupado = false;
        //yield return slots.descerSlotColetado(singleDisplaySlotDto.GoSlotBaixo, displaysSlotsDto);        
        yield return slots.descerSlotColetado(singleSlotColetadoDto.GoSlotBaixo, displaysSlotsDto);        
    }     
    
    public IEnumerator mostrarSprNone(DisplaysColetadosDto displaysSlotsDto, Executor executor)
    {
        //singleDisplaySlotDto.SlotSpriteCima.sprite = displaysSlotsDto.SprNone;
        //singleDisplaySlotDto.SlotSpriteCima.color = Color.red;
        singleSlotColetadoDto.SprRendererSlotCima.sprite = displaysSlotsDto.SprNone;
        singleSlotColetadoDto.SprRendererSlotCima.color = Color.red;
        //yield return slots.descerSlotNone(singleDisplaySlotDto.GoSlotCima, displaysSlotsDto, executor);
        yield return slots.descerSlotNone(singleSlotColetadoDto.GoSlotCima, displaysSlotsDto, executor);
        Debug.Log("Finalizado mostrado none");
    }    

    public IEnumerator limparSprNone(DisplaysColetadosDto displaysSlotsDto, Executor executor)
    {
        //yield return slots.subirSlotNone(singleDisplaySlotDto.GoSlotCima, displaysSlotsDto, executor);        
        yield return slots.subirSlotNone(singleSlotColetadoDto.GoSlotCima, displaysSlotsDto, executor);        
        //singleDisplaySlotDto.SlotSpriteCima.sprite = null;
        singleSlotColetadoDto.SprRendererSlotCima.sprite = null;
    }

    public void ligarCacaNiquel(Sprite[] sprites)
    {
        singleDisplaySlotDto.SlotSpriteMeio.gameObject.SetActive(true);
        coroutineCacaNiquel = Utils.MonoBehaviour.StartCoroutine(ligarCacaNiquelCoroutine(sprites));
    } 
    
    public void pararCacaNiquel(Sprite[] sprites, Sprite sprSucesso)
    {
        int indiceEscolhido = MathUtils.escolherDeZeroAteLimite(sprites.Length);
        Utils.MonoBehaviour.StopCoroutine(coroutineCacaNiquel);
        singleDisplaySlotDto.SlotSpriteMeio.sprite = sprites[indiceEscolhido];

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
        return singleDisplaySlotDto.SlotSpriteMeio.sprite;
    }

    public void desligarSprsSlotMeio()
    {
        singleDisplaySlotDto.SlotSpriteMeio.gameObject.SetActive(false);
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

    private IEnumerator limparSprNoneCasoOcupado(DisplaysColetadosDto displaysSlotsDto)
    {
        slots.cancelarMovimentacaoDeSlot();
        yield return limparSprNone(displaysSlotsDto, null);
        //Debug.Log("Pos Cancelado limpando spr none");
    }

    private IEnumerator ligarCacaNiquelCoroutine(Sprite[] sprites)
    {
        int indiceAtual = 0;
        while (true)
        {
            singleDisplaySlotDto.SlotSpriteMeio.sprite = sprites[indiceAtual];
            if (indiceAtual < sprites.Length - 1)
            {
                indiceAtual++;
            }
            else
            {
                indiceAtual = 0;
            }
            yield return null;
        }
    }
}
