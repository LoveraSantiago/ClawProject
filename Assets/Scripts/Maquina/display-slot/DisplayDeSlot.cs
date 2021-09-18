using UnityEngine;
using System.Collections;

public class DisplayDeSlot 
{
    public bool isOcupado { get; private set; }
    public bool isDesocupado { get { return !isOcupado; }}
    
    private GlowEfeito glowEfeito;    
    private MovimentadorDeSlots slots;
    private AnimacaoDisplayColetado animacao;

    private SingleDisplaySlotDto singleDisplaySlotDto;

    private Coroutine coroutineCacaNiquel;

    public DisplayDeSlot(SingleDisplaySlotDto singleDisplaySlotDto)
    {
        this.singleDisplaySlotDto = singleDisplaySlotDto;

        animacao = new AnimacaoDisplayColetado(singleDisplaySlotDto.Animator);

        MaterialGlow materialGlow = new MaterialGlow(singleDisplaySlotDto.SprRendererDentroEfeito.material);
        glowEfeito = new GlowEfeito(singleDisplaySlotDto.SprRendererDentroEfeito.gameObject, materialGlow);
                
        slots = new MovimentadorDeSlots(singleDisplaySlotDto);
    }    

    public void configuradoPeloLevel(Color corDisplay, Color corDentro)
    {
        singleDisplaySlotDto.SprDisplay.color = corDisplay;
        singleDisplaySlotDto.SprRendererDentro.color = corDentro;
    }   

    public IEnumerator mostrarAlvo(DisplaysSlotsDto displaysSlotsDto, Executor executorFimMovimentacao)
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

    public IEnumerator desligarAlvo(DisplaysSlotsDto displaysSlotsDto, Executor executorFimMovimentacao)
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
        Sprite sprite, bool mostrarMira, DisplaysSlotsDto displaysSlotsDto)
    {        
        yield return limparSprNoneCasoOcupado(displaysSlotsDto);
        singleDisplaySlotDto.SlotSpriteBaixo.sprite = sprite;
        isOcupado = true;
        yield return slots.subirSlotColetado(singleDisplaySlotDto.GoSlotBaixo, displaysSlotsDto);        
        desligarGlow();

        if (mostrarMira)
        {
            yield return mostrarAlvo(displaysSlotsDto, null);
            ligarGlowLuz();
        }        
    }      

    public IEnumerator limparSprColetado(DisplaysSlotsDto displaysSlotsDto)
    {
        isOcupado = false;
        yield return slots.descerSlotColetado(singleDisplaySlotDto.GoSlotBaixo, displaysSlotsDto);        
    }     
    
    public IEnumerator mostrarSprNone(DisplaysSlotsDto displaysSlotsDto, Executor executor)
    {
        singleDisplaySlotDto.SlotSpriteCima.sprite = displaysSlotsDto.SprVazio;
        singleDisplaySlotDto.SlotSpriteCima.color = Color.red;
        yield return slots.descerSlotNone(singleDisplaySlotDto.GoSlotCima, displaysSlotsDto, executor);
        Debug.Log("Finalizado mostrado none");
    }    

    public IEnumerator limparSprNone(DisplaysSlotsDto displaysSlotsDto, Executor executor)
    {
        yield return slots.subirSlotNone(singleDisplaySlotDto.GoSlotCima, displaysSlotsDto, executor);        
        singleDisplaySlotDto.SlotSpriteCima.sprite = null;
    }

    public void ligarCacaNiquel(Sprite[] sprites)
    {
        singleDisplaySlotDto.SlotSpriteMeio.gameObject.SetActive(true);
        coroutineCacaNiquel = Utils.MonoBehaviour.StartCoroutine(ligarCacaNiquelCoroutine(sprites));
    } 
    
    public void pararCacaNiquel(Sprite[] sprites, Sprite sprSucesso)
    {
        int indiceEscolhido = UtilsMath.escolherDeZeroAteLimiteArray(sprites.Length);
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
        glowEfeito.ligarGlowSucesso();        
    }

    public void ligarGlowFail()
    {
        glowEfeito.ligarGlowFail();
    }

    public void ligarGlowLuz()
    {
        glowEfeito.ligarGlowLuz();        
    }    

    public void desligarGlow()
    {
        glowEfeito.desligarGlow();
    }

    public bool isCliqueDentroArea(Vector2 posicao)
    {
        return isOcupado && singleDisplaySlotDto.SprRendererDentro.bounds.Contains(posicao);
    }    

    public MaterialGlow getMaterialGlow()
    {
        return glowEfeito.materialGlow;
    }

    private IEnumerator limparSprNoneCasoOcupado(DisplaysSlotsDto displaysSlotsDto)
    {
        slots.cancelarMovimentacaoDeSlot();
        yield return limparSprNone(displaysSlotsDto, null);
        Debug.Log("Pos Cancelado limpando spr none");
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
