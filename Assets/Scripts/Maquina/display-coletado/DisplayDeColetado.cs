using UnityEngine;
using System.Collections;

public class DisplayDeColetado : InformacaoDisplayColetado
{
    private static DisplayDeColetadoDto displayColetadoDto;

    private bool ocupado;

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
        posicaoSlotCimaInicial = sDisplayDto.GoSlotCima.transform.localPosition;

        Vector3 localPosition = sDisplayDto.GoSlotBaixo.transform.localPosition;
        posicaoDesejada = new Vector3(localPosition.x, 0.5f, localPosition.z);

        slots = new MovimentadorDeSlots();
    }    

    public void configuradoPeloLevel(Color corDisplay, Color corDentro)
    {
        sDisplayDto.SprDisplay.color = corDisplay;
        sDisplayDto.SprRendererDentro.color = corDentro;
    }   

    public void mostrarAlvo(MonoBehaviour monoBehaviour)
    {
        if (ocupado)
        {
            animacao.ligarAnimacaoMira();            
        }
        else
        {
            monoBehaviour.StartCoroutine(descerSlotCima(displayColetadoDto.SprVazio));
        }
        ligarGlowLuz();
    }

    public void desligarAlvo(MonoBehaviour monoBehavior)
    {
        if (animacao.isMiraLigado)
        {
            animacao.desligarAnimacao();
        }
        else{
            monoBehavior.StartCoroutine(subirSlotCima());
        }
    }

    public IEnumerator subirSlotBaixo(Sprite sprite)
    {
        ocupado = true;
        sDisplayDto.SlotSpriteBaixo.sprite = sprite;
        ligarGlowLuz();
        yield return slots.subirSlotBaixo(sDisplayDto.GoSlotBaixo, posicaoDesejada, displayColetadoDto);        
        desligarGlow();
    }   

    public IEnumerator descerSlotBaixo()
    {
        ocupado = false;
        yield return slots.descerSlotBaixo(sDisplayDto.GoSlotBaixo, posicaoSlotBaixoInicial, displayColetadoDto);        
    }     
    
    public IEnumerator descerSlotCima(Sprite sprite)
    {
        sDisplayDto.SlotSpriteCima.sprite = sprite;
        sDisplayDto.SlotSpriteCima.color = Color.red;
        yield return slots.descerSlotCima(sDisplayDto.GoSlotCima, posicaoDesejada, displayColetadoDto);        
    }

    public IEnumerator subirSlotCima()
    {
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

    public bool isOcupado()
    {
        return ocupado;
    }

    public bool isDesocupado()
    {
        return !isOcupado();
    }

    public bool isCliqueDentroArea(Vector2 posicao)
    {
        return sDisplayDto.SprRendererDentro.bounds.Contains(posicao);
    }

    public string getColetavelDoDisplayAcertado(Vector2 posicao)
    {
        if (isOcupado() && isCliqueDentroArea(posicao))
        {
            return sDisplayDto.SlotSpriteCima.sprite.name;
        }
        return null;        
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
