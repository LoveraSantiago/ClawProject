using UnityEngine;
using System.Collections;

public class DisplayDeColetado 
{
    private static DisplayDeColetadoDto displayColetadoDto;    

    private Vector3 posicaoDesejada;
    private Vector3 posicaoInicial;
      
    private SingleDisplayColetadoDto sDisplayDto;
    private GlowEfeito glowEfeito;    

    public DisplayDeColetado(SingleDisplayColetadoDto singleDisplayColetadoDto)
    {
        sDisplayDto = singleDisplayColetadoDto;

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

    public void limparSprite()
    {
        sDisplayDto.SprRendererColetado.sprite = null;
        sDisplayDto.GoColetado.transform.localPosition = posicaoInicial;
    }    

    public IEnumerator mostrarSprite(Sprite sprite)
    {
        sDisplayDto.SprRendererColetado.sprite = sprite;
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

    public IEnumerator limparSprite(float inicialDelay)
    {
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

    public MaterialGlow getMaterialGlow()
    {
        return glowEfeito.getMaterialGlow();
    }

    public static void configurarDisplay(DisplayDeColetadoDto displayColetadoDtoArg)
    {
        displayColetadoDto = displayColetadoDtoArg;
    }
}
