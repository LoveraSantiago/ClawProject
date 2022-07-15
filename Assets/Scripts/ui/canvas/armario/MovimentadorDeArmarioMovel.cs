using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovimentadorDeArmarioMovel : MovimentadorDeArmario
{
    private Vector2 posItemReferencia;

    public MovimentadorDeArmarioMovel(PrateleirasDto prateleirasDto)
    {
        posItemReferencia = pegarPosicaoReferencia(prateleirasDto);
    }

    public void movimentar(ScrollRect scrollRect, PrateleirasDto prateleirasDto)
    {
        GameObject goSelecionado = EventSystem.current.currentSelectedGameObject;
        Vector2 posicaoAnchored = pegarPosicaoClicado(prateleirasDto, goSelecionado);
        posicaoAnchored = new Vector2(posicaoAnchored.x, posicaoAnchored.y + prateleirasDto.RTransformArmario.offsetMax.y);

        Vector2 diferenca = posicaoAnchored - posItemReferencia;
        Debug.Log("Referencia " + posItemReferencia + " Atual " + posicaoAnchored + " Dif " + diferenca);

        RectTransform rtScrollRect = ((RectTransform)scrollRect.transform);

        float xPivot = diferenca.x / rtScrollRect.rect.width;
        float yPivot = posicaoAnchored.y / rtScrollRect.rect.height;
        Debug.Log("Pivot X " + xPivot + " Pivot Y " + yPivot + " rect " + rtScrollRect.rect);

        rtScrollRect.pivot = new Vector2(rtScrollRect.pivot.x + xPivot, 1f - Mathf.Abs(yPivot));

        Utils.MonoBehaviour.StartCoroutine(movimentarArmario(rtScrollRect, diferenca));
    }

    private IEnumerator movimentarArmario(RectTransform rtScrollRect, Vector2 diferenca)
    {        
        Vector2 posDestino = rtScrollRect.anchoredPosition - diferenca;
        float time          = 1f;
        float escalaIt      = 0f;
        float escalaInicial = 1;
        float escalaFinal   = 4;

        while(rtScrollRect.anchoredPosition != posDestino)
        {
            Vector2 result = Vector2.MoveTowards(rtScrollRect.anchoredPosition, posDestino, 2 * 1000f * Time.deltaTime);
            rtScrollRect.anchoredPosition = result;

            escalaIt = Mathf.Clamp(time, escalaInicial, escalaFinal);
            rtScrollRect.localScale = new Vector3(escalaIt, escalaIt, escalaInicial);

            time = incrementarTimer(time);
            yield return null;
        }

        Debug.Log("Escala atual " + escalaIt);
        while (escalaIt < escalaFinal)
        {
            escalaIt = Mathf.Clamp(time, escalaInicial, escalaFinal);
            rtScrollRect.localScale = new Vector3(escalaIt, escalaIt, escalaInicial);

            time = incrementarTimer(time);
            yield return null;
        }
        Debug.Log("Finalizado");
        yield return null;
    }

    private float incrementarTimer(float timeAtual)
    {
        return timeAtual += (5f * Time.deltaTime);
    }

    private Vector2 pegarPosicaoReferencia(PrateleirasDto prateleirasDto)
    {
        PrateleiraArmarioDto prateleira = prateleirasDto.PrateleiraDto[2];
        ItemPrateleiraDto item = prateleira.ItensPrateleira[2];

        RectTransform rTransformPrateleira = prateleira.RectTransformPrateleira;
        RectTransform rTransformItem = (RectTransform)item.BtnItem.transform;

        return new Vector2(rTransformItem.anchoredPosition.x, rTransformPrateleira.anchoredPosition.y);
    }

    private Vector2 pegarPosicaoClicado(PrateleirasDto prateleirasDto, GameObject goSelecionado)
    {
        int nomeBtn = int.Parse(goSelecionado.name);
        int nomeParent = int.Parse(goSelecionado.transform.parent.name);

        PrateleiraArmarioDto prateleira = prateleirasDto.PrateleiraDto[nomeParent];
        ItemPrateleiraDto itemSelecionado = prateleira.ItensPrateleira[nomeBtn];
        RectTransform rItemSelecionado = (RectTransform)itemSelecionado.BtnItem.gameObject.transform;
        RectTransform rPrateleira = prateleira.RectTransformPrateleira;

        return new Vector2(rItemSelecionado.anchoredPosition.x, rPrateleira.anchoredPosition.y);
    }
}
