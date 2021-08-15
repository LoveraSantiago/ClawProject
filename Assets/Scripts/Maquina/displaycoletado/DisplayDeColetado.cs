using UnityEngine;
using System.Collections;

public class DisplayDeColetado 
{
    private static DisplayDeColetadoDto displayColetadoDto;

    private bool ocupado;

    private Vector3 posicaoDesejada;
    private Vector3 posicaoInicial;
      
    private GlowEfeito glowEfeito;
    private AnimacaoDisplayColetado animacao;
    private SingleDisplayColetadoDto sDisplayDto;

    public DisplayDeColetado(SingleDisplayColetadoDto singleDisplayColetadoDto)
    {
        sDisplayDto = singleDisplayColetadoDto;

        animacao = new AnimacaoDisplayColetado(singleDisplayColetadoDto.Animator);

        MaterialGlow materialGlow = new MaterialGlow(displayColetadoDto.MaterialGlowDisplay);
        glowEfeito = new GlowEfeito(singleDisplayColetadoDto.SprRendererDentroEfeito.gameObject, materialGlow);        

        posicaoInicial = sDisplayDto.GoSlotBaixo.transform.localPosition;
        posicaoDesejada = new Vector3(
            sDisplayDto.GoSlotBaixo.transform.localPosition.x, 
            0.5f, 
            sDisplayDto.GoSlotBaixo.transform.localPosition.z);
    }    

    public void configuradoPeloLevel(Color corDisplay, Color corDentro)
    {
        sDisplayDto.SprDisplay.color = corDisplay;
        sDisplayDto.SprRendererDentro.color = corDentro;
    }   

    public IEnumerator mostrarAlvo()
    {
        if (ocupado)
        {
            animacao.ligarAnimacaoMira();
        }
        else
        {

        }
        yield return null;
    }

    public IEnumerator subirSlotBaixo(Sprite sprite)
    {
        ocupado = true;

        sDisplayDto.SlotSpriteBaixo.sprite = sprite;
        ligarGlowLuz();
        yield return new WaitForSeconds(displayColetadoDto.InicialDelay);

        while(slotBaixoAtingiuPosicao(posicaoDesejada))        
        {
            moverSlotBaixoAtePosicao(posicaoDesejada);
            yield return null;
        }

        sDisplayDto.GoSlotBaixo.transform.localPosition = posicaoDesejada;
        yield return new WaitForSeconds(displayColetadoDto.InicialDelay);
        desligarGlow();
    }   

    public IEnumerator descerSlotBaixo(float inicialDelay)
    {
        ocupado = false;

        yield return new WaitForSeconds(inicialDelay);

        while(slotBaixoAtingiuPosicao(posicaoInicial))        
        {            
            moverSlotBaixoAtePosicao(posicaoInicial);
            yield return null;
        }
        sDisplayDto.GoSlotBaixo.transform.localPosition = posicaoInicial;
    }            

    private bool slotBaixoAtingiuPosicao(Vector3 posicao)
    {
        return (Vector3.Distance(sDisplayDto.GoSlotBaixo.transform.localPosition, posicao))
               > (displayColetadoDto.VelocImg * Time.deltaTime);
    }

    private void moverSlotBaixoAtePosicao(Vector3 posicao)
    {
        sDisplayDto.GoSlotBaixo.transform.localPosition = Vector3.MoveTowards(
                sDisplayDto.GoSlotBaixo.transform.localPosition,
                posicao,
                displayColetadoDto.VelocImg * Time.deltaTime);
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

    public MaterialGlow getMaterialGlow()
    {
        return glowEfeito.getMaterialGlow();
    }

    public static void configurarDisplay(DisplayDeColetadoDto displayColetadoDtoArg)
    {
        displayColetadoDto = displayColetadoDtoArg;
    }
}
