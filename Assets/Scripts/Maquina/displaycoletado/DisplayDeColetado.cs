using UnityEngine;
using System.Collections;

public class DisplayDeColetado 
{
    private static DisplayDeColetadoDto displayColetadoDto;

    private Vector3 posicaoDesejada;
    private Vector3 posicaoInicial;

    private Color corOriginal;
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
        corOriginal = Utils.getCorByHex(corDentro);
        sDisplayDto.SprRendererDentro.color = corOriginal;
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
        sDisplayDto.SprRendererDentroEfeito.gameObject.SetActive(true);
        displayColetadoDto.MaterialGlowDisplay.SetColor("_corGlow", Color.green);
        //sDisplayDto.SprRendererDentro.material = displayColetadoDto.MaterialGlowDisplay;
        //sDisplayDto.SprRendererDentro.color = Color.white;
    }

    public void ligarGlowFail()
    {
        sDisplayDto.SprRendererDentroEfeito.gameObject.SetActive(true);
        displayColetadoDto.MaterialGlowDisplay.SetColor("_corGlow", Color.red);
        //sDisplayDto.SprRendererDentro.material = displayColetadoDto.MaterialGlowDisplay;
        //sDisplayDto.SprRendererDentro.color = Color.white;
    }

    public void ligarGlowLuz()
    {
        sDisplayDto.SprRendererDentroEfeito.gameObject.SetActive(true);
        displayColetadoDto.MaterialGlowDisplay.SetColor("_corGlow", Color.yellow);
        //sDisplayDto.SprRendererDentro.material = displayColetadoDto.MaterialGlowDisplay;
        //sDisplayDto.SprRendererDentro.color = Color.white;
    }

    public void desligarGlow()
    {
        //sDisplayDto.SprRendererDentro.color = corOriginal;
        //sDisplayDto.SprRendererDentro.material = materialOriginal;
        sDisplayDto.SprRendererDentroEfeito.gameObject.SetActive(false);
    }

    public static void configurarDisplay(DisplayDeColetadoDto displayColetadoDtoArg)
    {
        displayColetadoDto = displayColetadoDtoArg;
    }
}
