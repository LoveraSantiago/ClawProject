using UnityEngine;
using System.Collections;

public class DisplayDeColetado 
{
    private Vector3 posicaoDesejada;
    private Vector3 posicaoInicial;

    
    private GameObject goColetadoSprite;
    private SpriteRenderer sprRenderDentro;
    private SpriteRenderer sprRenderColetado;

    public DisplayDeColetado(GameObject goDisplay)
    {
        Transform transformDentro = goDisplay.transform.Find("dentro");
        sprRenderDentro = transformDentro.GetComponent<SpriteRenderer>();

        Transform transformColetadoSpr = transformDentro.Find("coletado-sprite");
        sprRenderColetado = transformColetadoSpr.GetComponent<SpriteRenderer>();
        goColetadoSprite = sprRenderColetado.gameObject;

        posicaoInicial = goColetadoSprite.transform.localPosition;
        posicaoDesejada = new Vector3(goColetadoSprite.transform.localPosition.x, 0f, goColetadoSprite.transform.localPosition.z);
    }

    public void mostrarSprite(Sprite sprite, float inicialDelay, float velocidade, MonoBehaviour monoBehaviour)
    {
        sprRenderColetado.sprite = sprite;
        monoBehaviour.StartCoroutine(subirSprite(posicaoDesejada, inicialDelay, velocidade));
    }

    public void limparSprite()
    {
        sprRenderColetado.sprite = null;
        goColetadoSprite.transform.localPosition = posicaoInicial;
    }

    public void limparSprite(float inicialDelay, float velocidade, MonoBehaviour monoBehaviour)
    {
        monoBehaviour.StartCoroutine(descerSprite(posicaoInicial, inicialDelay, velocidade));        
    }

    private IEnumerator subirSprite(Vector3 posFim, float inicialDelay, float velocidade)
    {
        yield return new WaitForSeconds(inicialDelay);
        while ((Vector3.Distance(goColetadoSprite.transform.localPosition, posFim))
               > (velocidade * Time.deltaTime))
        {
            goColetadoSprite.transform.localPosition = Vector3.MoveTowards(goColetadoSprite.transform.localPosition, posFim, velocidade * Time.deltaTime);
            yield return null;
        }
        goColetadoSprite.transform.localPosition = posFim;
    }

    private IEnumerator descerSprite(Vector3 posFim, float inicialDelay, float velocidade)
    {
        yield return new WaitForSeconds(inicialDelay);
        while ((Vector3.Distance(goColetadoSprite.transform.localPosition, posFim))
               > (velocidade * Time.deltaTime))
        {
            goColetadoSprite.transform.localPosition = Vector3.MoveTowards(goColetadoSprite.transform.localPosition, posFim, velocidade * Time.deltaTime);
            yield return null;
        }
        goColetadoSprite.transform.localPosition = posFim;
    }
}
