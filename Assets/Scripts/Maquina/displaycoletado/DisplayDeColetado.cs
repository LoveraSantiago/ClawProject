using UnityEngine;
using System.Collections;

public class DisplayDeColetado 
{
    private static DisplayDeColetadoDto displayColetadoDto;

    private Vector3 posicaoDesejada;
    private Vector3 posicaoInicial;
    
    private Material materialOriginal;
    private SingleDisplayColetadoDto sDisplayDto;

    public DisplayDeColetado(SingleDisplayColetadoDto singleDisplayColetadoDto)
    {
        sDisplayDto = singleDisplayColetadoDto;        
        materialOriginal = sDisplayDto.SprRendererDentro.material;

        posicaoInicial = sDisplayDto.GoColetado.transform.localPosition;
        posicaoDesejada = new Vector3(
            sDisplayDto.GoColetado.transform.localPosition.x, 
            0.5f, 
            sDisplayDto.GoColetado.transform.localPosition.z);
    }    

    public void configuradoPeloLevel(Color corDisplay, string corDentro)
    {
        sDisplayDto.SprDisplay.color = corDisplay;
        sDisplayDto.SprRendererDentro.color = Utils.getCorByHex(corDentro);
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
        displayColetadoDto.MaterialGlowDisplay.SetColor("_corGlow", Color.green);
        sDisplayDto.SprRendererDentro.material = displayColetadoDto.MaterialGlowDisplay;
    }

    public void ligarGlowFail()
    {
        displayColetadoDto.MaterialGlowDisplay.SetColor("_corGlow", Color.red);
        sDisplayDto.SprRendererDentro.material = displayColetadoDto.MaterialGlowDisplay;
    }

    public void ligarGlowLuz()
    {
        displayColetadoDto.MaterialGlowDisplay.SetColor("_corGlow", Color.yellow);
        sDisplayDto.SprRendererDentro.material = displayColetadoDto.MaterialGlowDisplay;
    }

    public void desligarGlow()
    {
        sDisplayDto.SprRendererDentro.material = materialOriginal;
    }

    public static void configurarDisplay(DisplayDeColetadoDto displayColetadoDtoArg)
    {
        displayColetadoDto = displayColetadoDtoArg;
    }
}
