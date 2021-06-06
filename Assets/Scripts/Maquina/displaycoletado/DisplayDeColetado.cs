using UnityEngine;
using System.Collections;

public class DisplayDeColetado 
{
    private static DisplayDeColetadoDto displayColetadoDto;
    private static readonly string propMaterial = "_corGlow";

    private Vector3 posicaoDesejada;
    private Vector3 posicaoInicial;

    private Color corOriginal;
    private Material materialOriginal;
    private SingleDisplayColetadoDto sDisplayDto;

    private Coroutine coroutineArcoIris;

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

    public void ligarArcoIris(MonoBehaviour monobehaviour)
    {
        coroutineArcoIris = monobehaviour.StartCoroutine(ligarGlowArcoIris());
    }

    public void desligarArcoIris(MonoBehaviour monobehaviour)
    {
        monobehaviour.StopCoroutine(coroutineArcoIris);
    }

    private IEnumerator ligarGlowArcoIris()
    {
        while (true)
        {
            displayColetadoDto.MaterialGlowDisplay.SetColor(propMaterial, 
                HSBColor.ToColor(new HSBColor(Mathf.PingPong(Time.time * 0.5f, 1), 1, 1)));
            yield return null;
        }
    }


    public void ligarGlowSucesso()
    {
        sDisplayDto.SprRendererDentroEfeito.gameObject.SetActive(true);
        displayColetadoDto.MaterialGlowDisplay.SetColor(propMaterial, Color.green);
    }

    public void ligarGlowFail()
    {
        sDisplayDto.SprRendererDentroEfeito.gameObject.SetActive(true);
        displayColetadoDto.MaterialGlowDisplay.SetColor(propMaterial, Color.red);
    }

    public void ligarGlowLuz()
    {
        sDisplayDto.SprRendererDentroEfeito.gameObject.SetActive(true);
        displayColetadoDto.MaterialGlowDisplay.SetColor(propMaterial, Color.yellow);
    }

    public void desligarGlow()
    {
        sDisplayDto.SprRendererDentroEfeito.gameObject.SetActive(false);
    }

    public static void configurarDisplay(DisplayDeColetadoDto displayColetadoDtoArg)
    {
        displayColetadoDto = displayColetadoDtoArg;
    }
}
