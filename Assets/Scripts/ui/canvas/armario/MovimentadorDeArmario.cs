using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovimentadorDeArmario : AcaoItemArmarioSelecionado.ProdutorEvento,
                                     AcaoBtnPrateleiraAcionado.ConsumidorEvento
{
    private PrateleirasDto prateleirasDto;
    private MovimentadorArmarioDto movimentadorDto;
    private EstadoPosicoesMovimentadorArmarioDto estadoPosicoesDto;

    private ScrollRect scrollRect;
    private ProdutorDeEvento<IndiceArmarioSelecionadoDto> produtorDeEvento;

    public MovimentadorDeArmario(MainColetaveisDto mainDto)
    {
        this.movimentadorDto = mainDto.MovimentadorDto;
        scrollRect = mainDto.ScrollRect;
        prateleirasDto = mainDto.PrateleirasDto;

        Vector2 posItemReferencia = pegarPosicaoReferencia(mainDto.PrateleirasDto);
        estadoPosicoesDto = new EstadoPosicoesMovimentadorArmarioDto(posItemReferencia);
        
        produtorDeEvento = new ProdutorDeEvento<IndiceArmarioSelecionadoDto>();
    }

    public void movimentarAnimado()
    {
        Debug.Log("Vertical normalized position " + scrollRect.verticalNormalizedPosition);
        estadoPosicoesDto.setMovimentado(true);
        GameObject goSelecionado = EventSystem.current.currentSelectedGameObject;
        int indiceItem = int.Parse(goSelecionado.name);
        int indicePrateleira = int.Parse(goSelecionado.transform.parent.name);

        Vector2 posicaoAnchored = pegarPosicaoClicado(indicePrateleira, indiceItem, prateleirasDto);
        posicaoAnchored = new Vector2(posicaoAnchored.x, posicaoAnchored.y + prateleirasDto.RTransformArmario.offsetMax.y);

        Vector2 diferenca = posicaoAnchored - estadoPosicoesDto.posItemReferencia;
        //Debug.Log("Referencia " + posItemReferencia + " Atual " + posicaoAnchored + " Dif " + diferenca);

        RectTransform rtScrollRect = ((RectTransform)scrollRect.transform);

        float xPivot = diferenca.x / rtScrollRect.rect.width;
        float yPivot = posicaoAnchored.y / rtScrollRect.rect.height;
        //Debug.Log("Pivot X " + xPivot + " Pivot Y " + yPivot + " rect " + rtScrollRect.rect);
        estadoPosicoesDto.setPivotOriginal(rtScrollRect.pivot);
        rtScrollRect.pivot = new Vector2(rtScrollRect.pivot.x + xPivot, 1f - Mathf.Abs(yPivot));

        ContextoEstaticoUtils.monoBehaviour.StartCoroutine(movimentarArmarioAnimado(indicePrateleira, indiceItem, rtScrollRect, diferenca));
    }

    public void movimentarImediato(IndiceArmarioSelecionadoDto indiceArmario)
    {
        estadoPosicoesDto.setMovimentado(true);
        Vector2 posicaoAnchored = pegarPosicaoClicado(indiceArmario.indicePrateleira, indiceArmario.indiceItem, prateleirasDto);
        posicaoAnchored = new Vector2(posicaoAnchored.x, posicaoAnchored.y + prateleirasDto.RTransformArmario.offsetMax.y);

        Vector2 diferenca = posicaoAnchored - estadoPosicoesDto.posItemReferencia;
        RectTransform rtScrollRect = ((RectTransform)scrollRect.transform);
        float xPivot = diferenca.x / rtScrollRect.rect.width;
        float yPivot = posicaoAnchored.y / rtScrollRect.rect.height;
        estadoPosicoesDto.setPivotOriginal(rtScrollRect.pivot);
        rtScrollRect.pivot = new Vector2(rtScrollRect.pivot.x + xPivot, 1f - Mathf.Abs(yPivot));
        estadoPosicoesDto.setPosOriginal(rtScrollRect.anchoredPosition);
        Vector2 posDestino = rtScrollRect.anchoredPosition - diferenca;
        rtScrollRect.anchoredPosition = posDestino;
        rtScrollRect.localScale = new Vector3(movimentadorDto.EscalaFinal, movimentadorDto.EscalaFinal, 1);
    }

    public bool isArmarioMovimentado()
    {
        return estadoPosicoesDto.movimentado;
    }

    public void voltar(ScrollRect scrollRect)
    {
        Debug.Log("Voltar chamado");
        RectTransform rtScrollRect = ((RectTransform)scrollRect.transform);
        ContextoEstaticoUtils.monoBehaviour.StartCoroutine(voltarArmario(rtScrollRect));
    }

    private IEnumerator movimentarArmarioAnimado(int indicePrateleira, int indiceItem, RectTransform rtScrollRect, Vector2 diferenca)
    {
        estadoPosicoesDto.setPosOriginal(rtScrollRect.anchoredPosition);

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
        PrateleiraArmarioDto prateleira = prateleirasDto.PrateleiraDto[indicePrateleira];
        ItemPrateleiraDto itemSelecionado = prateleira.ItensPrateleira[indiceItem];

        IndiceArmarioSelecionadoDto indiceArmarioSelecionado = new IndiceArmarioSelecionadoDto()
            .addIndices(indicePrateleira, indiceItem)
            .addScrollPosition(scrollRect.verticalNormalizedPosition)
            .addItemSelecionado(itemSelecionado);

        produtorDeEvento.produziuEvento(indiceArmarioSelecionado);
        yield return null;
    }

    private IEnumerator voltarArmario(RectTransform rtScrollRect)
    {
        float time = 4f;
        float escalaIt = 4f;
        float escalaInicial = 1;

        while (rtScrollRect.anchoredPosition != estadoPosicoesDto.posOriginal)
        {
            Vector2 result = Vector2.MoveTowards(
                rtScrollRect.anchoredPosition,
                estadoPosicoesDto.posOriginal, 
                movimentadorDto.VelocidadeMovimentacao * 1000f * Time.deltaTime);

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

        rtScrollRect.pivot = estadoPosicoesDto.pivotOriginal;
        estadoPosicoesDto.setMovimentado(false);        
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

    void AcaoBtnPrateleiraAcionado.ConsumidorEvento.consumirEvento(bool evento)
    {
        if (!isArmarioMovimentado())
        {
            movimentarAnimado();
        }
    }
}
