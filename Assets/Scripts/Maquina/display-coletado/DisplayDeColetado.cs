using UnityEngine;
using System.Collections;

public class DisplayDeColetado 
{
    private static DisplayDeColetadoDto displayColetadoDto;

    private static readonly int ESTADO_VAZIO            = 0;
    private static readonly int ESTADO_OCUPADO_COLETADO = 1;
    private static readonly int ESTADO_OCUPADO_NONE     = 2;

    private int estadoAtual;

    private Vector3 posicaoDesejada;
    private Vector3 posicaoSlotBaixoInicial;
    private Vector3 posicaoSlotCimaInicial;
      
    private GlowEfeito glowEfeito;
    private AnimacaoDisplayColetado animacao;
    private MovimentadorDeSlots slots;

    private SingleDisplayColetadoDto sDisplayDto;

    public DisplayDeColetado(SingleDisplayColetadoDto singleDisplayColetadoDto)
    {
        sDisplayDto = singleDisplayColetadoDto;

        animacao = new AnimacaoDisplayColetado(singleDisplayColetadoDto.Animator);

        MaterialGlow materialGlow = new MaterialGlow(displayColetadoDto.MaterialGlowDisplay);
        glowEfeito = new GlowEfeito(singleDisplayColetadoDto.SprRendererDentroEfeito.gameObject, materialGlow);        

        posicaoSlotBaixoInicial = sDisplayDto.GoSlotBaixo.transform.localPosition;
        posicaoSlotCimaInicial  = sDisplayDto.GoSlotCima.transform.localPosition;

        Vector3 localPosition = sDisplayDto.GoSlotBaixo.transform.localPosition;
        posicaoDesejada = new Vector3(localPosition.x, 0.5f, localPosition.z);

        slots = new MovimentadorDeSlots();
    }    

    public void configuradoPeloLevel(Color corDisplay, Color corDentro)
    {
        sDisplayDto.SprDisplay.color = corDisplay;
        sDisplayDto.SprRendererDentro.color = corDentro;
    }   

    public IEnumerator mostrarAlvo()
    {
        if (isOcupadoColetado())
        {
            animacao.ligarAnimacaoMira();            
        }
        else
        {
            yield return mostrarSprNone(displayColetadoDto.SprVazio);
        }
        ligarGlowLuz();
    }

    public void mostrarAlvoSelecionado()
    {
        animacao.ligarAnimacaoMiraSelecionado();
    }

    public IEnumerator desligarAlvo()
    {
        if (animacao.isMiraLigado)
        {
            animacao.desligarAnimacao();
        }
        else{
            yield return limparSprNone();
        }
    }

    public IEnumerator mostrarSprColetado(Sprite sprite)
    {
        if (isOcupadoNone())
        {
            slots.cancelarMovimentacaoDeSlot();
            yield return limparSprNone();
        }
        estadoAtual = ESTADO_OCUPADO_COLETADO;
        sDisplayDto.SlotSpriteBaixo.sprite = sprite;
        ligarGlowLuz();
        yield return slots.subirSlotBaixo(sDisplayDto.GoSlotBaixo, posicaoDesejada, displayColetadoDto);        
        desligarGlow();        
    }   

    public IEnumerator limparSprColetado()
    {
        estadoAtual = ESTADO_VAZIO;
        yield return slots.descerSlotBaixo(sDisplayDto.GoSlotBaixo, posicaoSlotBaixoInicial, displayColetadoDto);        
    }     
    
    public IEnumerator mostrarSprNone(Sprite sprite)
    {
        estadoAtual = ESTADO_OCUPADO_NONE;
        sDisplayDto.SlotSpriteCima.sprite = sprite;
        sDisplayDto.SlotSpriteCima.color = Color.red;
        yield return slots.descerSlotCima(sDisplayDto.GoSlotCima, posicaoDesejada, displayColetadoDto);        
    }    

    public IEnumerator limparSprNone()
    {
        estadoAtual = ESTADO_VAZIO;
        yield return slots.subirSlotCima(sDisplayDto.GoSlotCima, posicaoSlotCimaInicial, displayColetadoDto);
        sDisplayDto.SlotSpriteCima.sprite = null;
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
        return isOcupadoColetado() && sDisplayDto.SprRendererDentro.bounds.Contains(posicao);
    }    

    public MaterialGlow getMaterialGlow()
    {
        return glowEfeito.getMaterialGlow();
    }

    public static void configurarDisplay(DisplayDeColetadoDto displayColetadoDtoArg)
    {
        displayColetadoDto = displayColetadoDtoArg;
    }  
}
