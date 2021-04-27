using UnityEngine;
using System.Collections;

public class DisplayDeColetado 
{
    private static DisplayDeColetadoDto displayColetadoDto;

    private Vector3 posicaoDesejada;
    private Vector3 posicaoInicial;
    
    private Material materialOriginal;

    private GameObject goColetadoSprite;
    private SpriteRenderer sprRenderDentro;
    private SpriteRenderer sprRenderColetado;

    public DisplayDeColetado(GameObject goDisplay)
    {
        Transform transformDentro = goDisplay.transform.Find("dentro");
        sprRenderDentro = transformDentro.GetComponent<SpriteRenderer>();
        materialOriginal = sprRenderDentro.material;

        Transform transformColetadoSpr = transformDentro.Find("coletado-sprite");
        sprRenderColetado = transformColetadoSpr.GetComponent<SpriteRenderer>();
        goColetadoSprite = sprRenderColetado.gameObject;

        posicaoInicial = goColetadoSprite.transform.localPosition;
        posicaoDesejada = new Vector3(goColetadoSprite.transform.localPosition.x, 0f, goColetadoSprite.transform.localPosition.z);
    }    

    public void limparSprite()
    {
        sprRenderColetado.sprite = null;
        goColetadoSprite.transform.localPosition = posicaoInicial;
    }    

    public IEnumerator mostrarSprite(Sprite sprite)
    {
        sprRenderColetado.sprite = sprite;
        ligarGlowLuz();
        yield return new WaitForSeconds(displayColetadoDto.InicialDelay);

        while ((Vector3.Distance(goColetadoSprite.transform.localPosition, posicaoDesejada))
               > (displayColetadoDto.VelocImg * Time.deltaTime))
        {
            goColetadoSprite.transform.localPosition = Vector3.MoveTowards(
                goColetadoSprite.transform.localPosition, posicaoDesejada, displayColetadoDto.VelocImg * Time.deltaTime);

            yield return null;
        }

        goColetadoSprite.transform.localPosition = posicaoDesejada;
        yield return new WaitForSeconds(displayColetadoDto.InicialDelay);
        desligarGlow();
    }   

    public IEnumerator limparSprite(float inicialDelay)
    {
        yield return new WaitForSeconds(inicialDelay);

        while ((Vector3.Distance(goColetadoSprite.transform.localPosition, posicaoInicial))
               > (displayColetadoDto.VelocImg * Time.deltaTime))
        {
            goColetadoSprite.transform.localPosition = Vector3.MoveTowards(
                goColetadoSprite.transform.localPosition, posicaoInicial, displayColetadoDto.VelocImg * Time.deltaTime);

            yield return null;
        }

        goColetadoSprite.transform.localPosition = posicaoInicial;
    }

    public void ligarGlowSucesso()
    {
        displayColetadoDto.MaterialGlowDisplay.SetColor("_corGlow", Color.green);
        sprRenderDentro.material = displayColetadoDto.MaterialGlowDisplay;
    }

    public void ligarGlowFail()
    {
        displayColetadoDto.MaterialGlowDisplay.SetColor("_corGlow", Color.red);
        sprRenderDentro.material = displayColetadoDto.MaterialGlowDisplay;
    }

    public void ligarGlowLuz()
    {
        displayColetadoDto.MaterialGlowDisplay.SetColor("_corGlow", Color.yellow);
        sprRenderDentro.material = displayColetadoDto.MaterialGlowDisplay;
    }

    public void desligarGlow()
    {
        sprRenderDentro.material = materialOriginal;
    }

    public static void configurarDisplay(DisplayDeColetadoDto displayColetadoDtoArg)
    {
        displayColetadoDto = displayColetadoDtoArg;
    }
}
