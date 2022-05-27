using UnityEngine;
using System.Collections;

public class DisplayDeSlot 
{
    public bool isOcupado { get; private set; }
    public bool isDesocupado { get { return !isOcupado; }}
    
    private MovimentadorDeSlots slots;
    private AnimacaoDisplayColetado animacao;

    private SingleSlotColetadoDto singleSlotColetadoDto;

    private Coroutine coroutineCacaNiquel;

    public DisplayDeSlot(SingleSlotColetadoDto singleSlotColetadoDto)
    {
        this.singleSlotColetadoDto = singleSlotColetadoDto;

        animacao   = new AnimacaoDisplayColetado(singleSlotColetadoDto.Animator);        
        slots      = new MovimentadorDeSlots(singleSlotColetadoDto);
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

    public void mostrarAlvoSelecionado(Material materialAlvoSelecionado)
    {
        singleSlotColetadoDto.SprRendererSlotMeio.sharedMaterial = materialAlvoSelecionado;
        //animacao.ligarAnimacaoMiraSelecionado();
    }

    public IEnumerator desligarAlvo(DisplaysColetadosDto displaysSlotsDto, Executor executorFimMovimentacao)
    {
        if (animacao.isMiraLigado)
        {
            yield return new WaitForSeconds(displaysSlotsDto.InicialDelay * 2);
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
        singleSlotColetadoDto.SprRendererSlotBaixo.sprite = sprite;
        isOcupado = true;
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
        yield return slots.descerSlotColetado(singleSlotColetadoDto.GoSlotBaixo, displaysSlotsDto);        
    }     
    
    public IEnumerator mostrarSprNone(DisplaysColetadosDto displaysSlotsDto, Executor executor)
    {
        singleSlotColetadoDto.SprRendererSlotCima.sprite = displaysSlotsDto.SprNone;
        singleSlotColetadoDto.SprRendererSlotCima.color = Color.red;
        yield return slots.descerSlotNone(singleSlotColetadoDto.GoSlotCima, displaysSlotsDto, executor);
    }    

    public IEnumerator limparSprNone(DisplaysColetadosDto displaysSlotsDto, Executor executor)
    {
        yield return slots.subirSlotNone(singleSlotColetadoDto.GoSlotCima, displaysSlotsDto, executor);        
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

    private IEnumerator limparSprNoneCasoOcupado(DisplaysColetadosDto displaysSlotsDto)
    {
        slots.cancelarMovimentacaoDeSlot();
        yield return limparSprNone(displaysSlotsDto, null);
        //Debug.Log("Pos Cancelado limpando spr none");
    }

    private IEnumerator ligarCacaNiquelCoroutine(Sprite[] sprites)
    {
        int indiceAtual = 0;
        Debug.Log("caca niquel ligado");
        while (true)
        {
            Sprite spriteAtual = sprites[indiceAtual];
            Debug.Log("Passado sprite " + spriteAtual.name);
            singleSlotColetadoDto.SprRendererSlotMeio.sprite = sprites[indiceAtual];
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
