using UnityEngine;
using System.Collections;

public class DisplayDeColetado 
{    
    private static Material materialGlow;

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

    public IEnumerator mostrarSprite(Sprite sprite, float inicialDelay, float velocidade)
    {
        sprRenderColetado.sprite = sprite;
        ligarGlowLuz();
        yield return new WaitForSeconds(inicialDelay);
        while ((Vector3.Distance(goColetadoSprite.transform.localPosition, posicaoDesejada))
               > (velocidade * Time.deltaTime))
        {
            goColetadoSprite.transform.localPosition = Vector3.MoveTowards(goColetadoSprite.transform.localPosition, posicaoDesejada, velocidade * Time.deltaTime);
            yield return null;
        }
        goColetadoSprite.transform.localPosition = posicaoDesejada;
        yield return new WaitForSeconds(inicialDelay);
        desligarGlow();
    }

    public IEnumerator limparSprite(float inicialDelay, float velocidade)
    {
        yield return new WaitForSeconds(inicialDelay);
        while ((Vector3.Distance(goColetadoSprite.transform.localPosition, posicaoInicial))
               > (velocidade * Time.deltaTime))
        {
            goColetadoSprite.transform.localPosition = Vector3.MoveTowards(goColetadoSprite.transform.localPosition, posicaoInicial, velocidade * Time.deltaTime);
            yield return null;
        }
        goColetadoSprite.transform.localPosition = posicaoInicial;
    }

    public void ligarGlowSucesso()
    {
        materialGlow.SetColor("_corGlow", Color.green);
        sprRenderDentro.material = materialGlow;
    }

    public void ligarGlowFail()
    {
        materialGlow.SetColor("_corGlow", Color.red);
        sprRenderDentro.material = materialGlow;
    }

    public void ligarGlowLuz()
    {
        materialGlow.SetColor("_corGlow", Color.yellow);
        sprRenderDentro.material = materialGlow;
    }

    public void desligarGlow()
    {
        sprRenderDentro.material = materialOriginal;
    }

    public static void configurarDisplay(Material materialGlowArg)
    {        
        materialGlow = materialGlowArg;
    }
}
