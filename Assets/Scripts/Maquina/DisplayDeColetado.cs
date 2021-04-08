using UnityEngine;
using System.Collections;

public class DisplayDeColetado 
{
    private Vector3 posicaoDesejada;
    private Vector3 posicaoInicial;

    private GameObject go;
    private SpriteRenderer spriteRenderer;

    public DisplayDeColetado(SpriteRenderer spriteRenderer)
    {
        this.spriteRenderer = spriteRenderer;
        go = spriteRenderer.gameObject;
        posicaoInicial = go.transform.localPosition;
        posicaoDesejada = new Vector3(go.transform.localPosition.x, 0.45f, go.transform.localPosition.z);
    }

    public void mostrarSprite(Sprite sprite, float velocidade, MonoBehaviour monoBehaviour)
    {
        spriteRenderer.sprite = sprite;
        monoBehaviour.StartCoroutine(subirSprite(posicaoDesejada, velocidade));
    }

    private IEnumerator subirSprite(Vector3 posFim, float velocidade)
    {
        yield return new WaitForSeconds(0.5f);
        while ((Vector3.Distance(go.transform.localPosition, posFim))
               > (velocidade * Time.deltaTime))
        {
            go.transform.localPosition = Vector3.MoveTowards(go.transform.localPosition, posFim, velocidade * Time.deltaTime);
            yield return null;
        }
        go.transform.localPosition = posFim;
    }

    public void limparSprite()
    {
        spriteRenderer.sprite = null;
        go.transform.localPosition = posicaoInicial;
    }
}
