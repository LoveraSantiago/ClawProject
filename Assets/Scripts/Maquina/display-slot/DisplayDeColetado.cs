using UnityEngine;
using System.Collections;

public class DisplayDeColetado 
{
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

    private SingleDisplaySlotDto singleDisplaySlotDto;

    public DisplayDeColetado(SingleDisplaySlotDto singleDisplaySlotDto, Material materialGlowDisplay)
    {
        this.singleDisplaySlotDto = singleDisplaySlotDto;

        animacao = new AnimacaoDisplayColetado(singleDisplaySlotDto.Animator);

        MaterialGlow materialGlow = new MaterialGlow(materialGlowDisplay);
        glowEfeito = new GlowEfeito(singleDisplaySlotDto.SprRendererDentroEfeito.gameObject, materialGlow);

        posicaoSlotBaixoInicial = this.singleDisplaySlotDto.GoSlotBaixo.transform.localPosition;
        posicaoSlotCimaInicial = this.singleDisplaySlotDto.GoSlotCima.transform.localPosition;

        Vector3 localPosition = this.singleDisplaySlotDto.GoSlotBaixo.transform.localPosition;
        posicaoDesejada = new Vector3(localPosition.x, 0.5f, localPosition.z);

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
        yield return slots.subirSlotBaixo(singleDisplaySlotDto.GoSlotBaixo, posicaoDesejada, displaysSlotsDto);        
        desligarGlow();

        if (mostrarMira)
        {
            yield return mostrarAlvo(displaysSlotsDto);
        }
    }   

    public IEnumerator limparSprColetado(DisplaysSlotsDto displaysSlotsDto)
    {
        estadoAtual = ESTADO_VAZIO;
        yield return slots.descerSlotBaixo(singleDisplaySlotDto.GoSlotBaixo, posicaoSlotBaixoInicial, displaysSlotsDto);        
    }     
    
    public IEnumerator mostrarSprNone(DisplaysSlotsDto displaysSlotsDto)
    {
        estadoAtual = ESTADO_OCUPADO_NONE;
        singleDisplaySlotDto.SlotSpriteCima.sprite = displaysSlotsDto.SprVazio;
        singleDisplaySlotDto.SlotSpriteCima.color = Color.red;
        yield return slots.descerSlotCima(singleDisplaySlotDto.GoSlotCima, posicaoDesejada, displaysSlotsDto);        
    }    

    public IEnumerator limparSprNone(DisplaysSlotsDto displaysSlotsDto)
    {
        estadoAtual = ESTADO_VAZIO;
        yield return slots.subirSlotCima(singleDisplaySlotDto.GoSlotCima, posicaoSlotCimaInicial, displaysSlotsDto);
        singleDisplaySlotDto.SlotSpriteCima.sprite = null;
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
}
