using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovimentadorDeArmario : AcaoItemArmarioSelecionado.ProdutorEvento
{
    private bool movimentado;
    private Vector2 posItemReferencia;
    private Vector2 posOriginal;
    private Vector2 pivotOriginal;

    private MovimentadorArmarioDto movimentadorDto;
    private ProdutorDeEvento<IndiceArmarioSelecionadoDto> produtorDeEvento;

    public MovimentadorDeArmario(PrateleirasDto prateleirasDto, MovimentadorArmarioDto movimentadorDto)
    {
        this.movimentadorDto = movimentadorDto;
        posItemReferencia = pegarPosicaoReferencia(prateleirasDto);
        produtorDeEvento = new ProdutorDeEvento<IndiceArmarioSelecionadoDto>();
    }

    public void movimentar(ScrollRect scrollRect, PrateleirasDto prateleirasDto)
    {
        movimentado = true;
        GameObject goSelecionado = EventSystem.current.currentSelectedGameObject;
        int indiceItem = int.Parse(goSelecionado.name);
        int indicePrateleira = int.Parse(goSelecionado.transform.parent.name);

        Vector2 posicaoAnchored = pegarPosicaoClicado(indicePrateleira, indiceItem, prateleirasDto);
        posicaoAnchored = new Vector2(posicaoAnchored.x, posicaoAnchored.y + prateleirasDto.RTransformArmario.offsetMax.y);

        Vector2 diferenca = posicaoAnchored - posItemReferencia;
        Debug.Log("Referencia " + posItemReferencia + " Atual " + posicaoAnchored + " Dif " + diferenca);

        RectTransform rtScrollRect = ((RectTransform)scrollRect.transform);

        float xPivot = diferenca.x / rtScrollRect.rect.width;
        float yPivot = posicaoAnchored.y / rtScrollRect.rect.height;
        Debug.Log("Pivot X " + xPivot + " Pivot Y " + yPivot + " rect " + rtScrollRect.rect);

        pivotOriginal = rtScrollRect.pivot;
        rtScrollRect.pivot = new Vector2(rtScrollRect.pivot.x + xPivot, 1f - Mathf.Abs(yPivot));

        Utils.MonoBehaviour.StartCoroutine(movimentarArmario(indicePrateleira, indiceItem, rtScrollRect, diferenca));
    }

    public bool isArmarioMovimentado()
    {
        return movimentado;
    }

    public void voltar(ScrollRect scrollRect)
    {
        Debug.Log("Voltar chamado");
        RectTransform rtScrollRect = ((RectTransform)scrollRect.transform);        
        Utils.MonoBehaviour.StartCoroutine(voltarArmario(rtScrollRect));
    }

    private IEnumerator movimentarArmario(int indicePrateleira, int indiceItem, RectTransform rtScrollRect, Vector2 diferenca)
    {
        posOriginal = rtScrollRect.anchoredPosition;

        Vector2 posDestino = rtScrollRect.anchoredPosition - diferenca;
        float time          = 1f;
        float escalaIt      = 0f;
        float escalaInicial = 1;        

        while(rtScrollRect.anchoredPosition != posDestino)
        {
            Vector2 result = Vector2.MoveTowards(rtScrollRect.anchoredPosition, posDestino, movimentadorDto.VelocidadeMovimentacao * 1000f * Time.deltaTime);
            rtScrollRect.anchoredPosition = result;

            escalaIt = Mathf.Clamp(time, escalaInicial, movimentadorDto.EscalaFinal);
            rtScrollRect.localScale = new Vector3(escalaIt, escalaIt, escalaInicial);

            time = incrementarTimer(time);
            yield return null;
        }

        //Debug.Log("Escala atual " + escalaIt);
        while (escalaIt < movimentadorDto.EscalaFinal)
        {
            escalaIt = Mathf.Clamp(time, escalaInicial, movimentadorDto.EscalaFinal);
            rtScrollRect.localScale = new Vector3(escalaIt, escalaIt, escalaInicial);

            time = incrementarTimer(time);
            yield return null;
        }
        //Debug.Log("Finalizado");
        produtorDeEvento.produziuEvento(new IndiceArmarioSelecionadoDto(indicePrateleira, indiceItem));
        yield return null;
    }

    private IEnumerator voltarArmario(RectTransform rtScrollRect)
    {
        float time = 4f;
        float escalaIt = 4f;
        float escalaInicial = 1;

        while (rtScrollRect.anchoredPosition != posOriginal)
        {
            Vector2 result = Vector2.MoveTowards(rtScrollRect.anchoredPosition, posOriginal, movimentadorDto.VelocidadeMovimentacao * 1000f * Time.deltaTime);
            rtScrollRect.anchoredPosition = result;

            escalaIt = Mathf.Clamp(time, escalaInicial, movimentadorDto.EscalaFinal);
            rtScrollRect.localScale = new Vector3(escalaIt, escalaIt, escalaInicial);

            time = decrementarTimer(time);
            yield return null;
        }

        while (escalaIt > 1)
        {
            escalaIt = Mathf.Clamp(time, escalaInicial, movimentadorDto.EscalaFinal);
            rtScrollRect.localScale = new Vector3(escalaIt, escalaIt, escalaInicial);

            time = decrementarTimer(time);
            yield return null;
        }
        Debug.Log("Finalizado");

        rtScrollRect.pivot = pivotOriginal;
        movimentado = false;        
        yield return null;
    }

    private float incrementarTimer(float timeAtual)
    {
        return timeAtual += (movimentadorDto.VelocidadeZoom * Time.deltaTime);
    }

    private float decrementarTimer(float timeAtual)
    {
        return timeAtual -= (movimentadorDto.VelocidadeZoom * Time.deltaTime);
    }

    private Vector2 pegarPosicaoReferencia(PrateleirasDto prateleirasDto)
    {
        PrateleiraArmarioDto prateleira = prateleirasDto.PrateleiraDto[2];
        ItemPrateleiraDto item = prateleira.ItensPrateleira[2];

        RectTransform rTransformPrateleira = prateleira.RectTransformPrateleira;
        RectTransform rTransformItem = (RectTransform)item.BtnItem.transform;

        return new Vector2(rTransformItem.anchoredPosition.x, rTransformPrateleira.anchoredPosition.y);
    }

    private Vector2 pegarPosicaoClicado(int indicePrateleira, int indiceItem, PrateleirasDto prateleirasDto)
    {
       

        PrateleiraArmarioDto prateleira = prateleirasDto.PrateleiraDto[indicePrateleira];
        ItemPrateleiraDto itemSelecionado = prateleira.ItensPrateleira[indiceItem];
        RectTransform rItemSelecionado = (RectTransform)itemSelecionado.BtnItem.gameObject.transform;
        RectTransform rPrateleira = prateleira.RectTransformPrateleira;

        return new Vector2(rItemSelecionado.anchoredPosition.x, rPrateleira.anchoredPosition.y);
    }

    ProdutorDeEvento<IndiceArmarioSelecionadoDto> AcaoItemArmarioSelecionado.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
