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

        posicaoInicial = sDisplayDto.GoColetado.transform.localPosition;
        posicaoDesejada = new Vector3(
            sDisplayDto.GoColetado.transform.localPosition.x, 
            0.5f, 
            sDisplayDto.GoColetado.transform.localPosition.z);
    }    

    public void configuradoPeloLevel(Color corDisplay, Color corDentro)
    {
        sDisplayDto.SprDisplay.color = corDisplay;
        sDisplayDto.SprRendererDentro.color = corDentro;
    }   

    public IEnumerator subirSprite(Sprite sprite)
    {
        ocupado = true;

        sDisplayDto.SlotSpriteBaixo.sprite = sprite;
        ligarGlowLuz();
        yield return new WaitForSeconds(displayColetadoDto.InicialDelay);

        while ((Vector3.Distance(sDisplayDto.GoColetado.transform.localPosition, posicaoDesejada))
               > (displayColetadoDto.VelocImg * Time.deltaTime))
        {
            sDisplayDto.GoColetado.transform.localPosition = Vector3.MoveTowards(
                sDisplayDto.GoColetado.transform.localPosition, 
                posicaoDesejada, 
                displayColetadoDto.VelocImg * Time.deltaTime);

            yield return null;
        }

        sDisplayDto.GoColetado.transform.localPosition = posicaoDesejada;
        yield return new WaitForSeconds(displayColetadoDto.InicialDelay);
        desligarGlow();
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

    public IEnumerator descerSprite(float inicialDelay)
    {
        ocupado = false;

        yield return new WaitForSeconds(inicialDelay);

        while ((Vector3.Distance(sDisplayDto.GoColetado.transform.localPosition, posicaoInicial))
               > (displayColetadoDto.VelocImg * Time.deltaTime))
        {
            sDisplayDto.GoColetado.transform.localPosition = Vector3.MoveTowards(
                sDisplayDto.GoColetado.transform.localPosition, 
                posicaoInicial, 
                displayColetadoDto.VelocImg * Time.deltaTime);

            yield return null;
        }
        sDisplayDto.GoColetado.transform.localPosition = posicaoInicial;
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
