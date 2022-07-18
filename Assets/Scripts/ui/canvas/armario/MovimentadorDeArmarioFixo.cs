using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovimentadorDeArmarioFixo : MovimentadorDeArmario
{
    private bool movimentado;
    private Vector2 posItemReferencia;

    public MovimentadorDeArmarioFixo(PrateleirasDto prateleirasDto)
    {
        posItemReferencia = pegarPosicaoReferencia(prateleirasDto);
    }

    public void movimentar(ScrollRect scrollRect, PrateleirasDto prateleirasDto)
    {
        movimentado = true;
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
        rtScrollRect.localScale *= 4;

        rtScrollRect.anchoredPosition -= diferenca;
    }

    public bool isArmarioMovimentado()
    {
        return movimentado;
    }

    public void voltar(ScrollRect scrollRect)
    {
        throw new System.NotImplementedException();
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
