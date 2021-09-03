using UnityEngine;
using System.Collections;

public class DisplayDeSlot 
{
    private static readonly int ESTADO_VAZIO            = 0;
    private static readonly int ESTADO_OCUPADO_COLETADO = 1;
    private static readonly int ESTADO_OCUPADO_NONE     = 2;

    private int estadoAtual; 
    
    private GlowEfeito glowEfeito;
    private PosicoesSlots posicoes;
    private MovimentadorDeSlots slots;
    private AnimacaoDisplayColetado animacao;

    private SingleDisplaySlotDto singleDisplaySlotDto;

    private Coroutine coroutineCacaNiquel;

    public DisplayDeSlot(
        SingleDisplaySlotDto singleDisplaySlotDto)
    {
        this.singleDisplaySlotDto = singleDisplaySlotDto;

        animacao = new AnimacaoDisplayColetado(singleDisplaySlotDto.Animator);

        MaterialGlow materialGlow = new MaterialGlow(singleDisplaySlotDto.SprRendererDentroEfeito.material);
        glowEfeito = new GlowEfeito(singleDisplaySlotDto.SprRendererDentroEfeito.gameObject, materialGlow);

        posicoes = new PosicoesSlots(singleDisplaySlotDto);
        slots = new MovimentadorDeSlots();
    }    

    public void configuradoPeloLevel(Color corDisplay, Color corDentro)
    {
        singleDisplaySlotDto.SprDisplay.color = corDisplay;
        singleDisplaySlotDto.SprRendererDentro.color = corDentro;
    }   

    public IEnumerator mostrarAlvo(DisplaysSlotsDto displaysSlotsDto)
    {
        if (isOcupadoColetado())
        {
            animacao.ligarAnimacaoMira();            
        }
        else
        {
            yield return mostrarSprNone(displaysSlotsDto);
        }
        ligarGlowLuz();
    }

    public void mostrarAlvoSelecionado()
    {
        animacao.ligarAnimacaoMiraSelecionado();
    }

    public IEnumerator desligarAlvo(DisplaysSlotsDto displaysSlotsDto)
    {
        if (animacao.isMiraLigado)
        {
            animacao.desligarAnimacao();
        }
        else{
            yield return limparSprNone(displaysSlotsDto);
        }
    }

    public IEnumerator mostrarSprColetado(
        Sprite sprite, bool mostrarMira, DisplaysSlotsDto displaysSlotsDto)
    {
        if (isOcupadoNone())
        {
            slots.cancelarMovimentacaoDeSlot();
            yield return limparSprNone(displaysSlotsDto);
        }
        estadoAtual = ESTADO_OCUPADO_COLETADO;
        singleDisplaySlotDto.SlotSpriteBaixo.sprite = sprite;
        ligarGlowLuz();
        yield return slots.subirSlotBaixo(singleDisplaySlotDto.GoSlotBaixo, posicoes.posFinal, displaysSlotsDto);        
        desligarGlow();

        if (mostrarMira)
        {
            yield return mostrarAlvo(displaysSlotsDto);
        }
    }   

    public IEnumerator limparSprColetado(DisplaysSlotsDto displaysSlotsDto)
    {
        estadoAtual = ESTADO_VAZIO;
        yield return slots.descerSlotBaixo(singleDisplaySlotDto.GoSlotBaixo, posicoes.posSlotBaixoInicial, displaysSlotsDto);        
    }     
    
    public IEnumerator mostrarSprNone(DisplaysSlotsDto displaysSlotsDto)
    {
        estadoAtual = ESTADO_OCUPADO_NONE;
        singleDisplaySlotDto.SlotSpriteCima.sprite = displaysSlotsDto.SprVazio;
        singleDisplaySlotDto.SlotSpriteCima.color = Color.red;
        yield return slots.descerSlotCima(singleDisplaySlotDto.GoSlotCima, posicoes.posFinal, displaysSlotsDto);        
    }    

    public IEnumerator limparSprNone(DisplaysSlotsDto displaysSlotsDto)
    {
        estadoAtual = ESTADO_VAZIO;
        yield return slots.subirSlotCima(singleDisplaySlotDto.GoSlotCima, posicoes.posSlotCimaInicial, displaysSlotsDto);
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
        if(sprSucesso == sprites[indiceEscolhido])
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

    public bool isOcupadoColetado()
    {
        return estadoAtual == ESTADO_OCUPADO_COLETADO;
    }

    public bool isOcupadoNone()
    {
        return estadoAtual == ESTADO_OCUPADO_NONE;
    }

    public bool isDesocupado()
    {
        return !isOcupadoColetado();
    }

    public bool isCliqueDentroArea(Vector2 posicao)
    {
        return isOcupadoColetado() && singleDisplaySlotDto.SprRendererDentro.bounds.Contains(posicao);
    }    

    public MaterialGlow getMaterialGlow()
    {
        return glowEfeito.materialGlow;
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
