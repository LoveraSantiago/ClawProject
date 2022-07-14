using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

#pragma warning disable 0649
public class ColetaveisSceneV2 : MonoBehaviour 
{       
    [SerializeField] private TimerFichaDto timerFichaDto;
    [Space(5)]    
    [SerializeField] private ScrollRect scrollRect;
    [Space(5)]
    [SerializeField] private PrateleirasDto prateleirasDto;
    [Space(5)]
    [SerializeField] private GameObject prefabMateriais;
    [SerializeField] private GameObject prefabColetaveisDto;

    private float ultimaPosicao;
    private TimerFicha timerFichaOuro;
    private Prateleiras prateleiras;

    private RectTransform rectTransformReferencia;
    private Vector2 referencia;

    void Start()
    {
        Utils.configMainMono(this);
        MateriaisUtils.configurar(prefabMateriais);
        HelperColetavelEntidade.configurar(prefabColetaveisDto);

        PlayerPrefsColetaveis.unlockFamilia(ColetavelEntidade.FAMILIA.FRUTAS.ToString());//TEMPORARIAMENTE AQUI               

        timerFichaOuro = new TimerFicha(timerFichaDto, Ficha.OURO);
        prateleiras    = new Prateleiras(prateleirasDto);

        scrollRect.onValueChanged.AddListener((pos) => movimentado(pos));
        ultimaPosicao = 1;

        popularBotoes();

        ItemPrateleiraDto item = prateleirasDto.PrateleiraDto[0].ItensPrateleira[2];
        Debug.Log("Referencia nome " + item.GoItem.name + " parent " + item.GoItem.transform.parent.name);
        rectTransformReferencia = (RectTransform)item.GoItem.transform;        
    }

    private void Update()
    {
        timerFichaOuro.update();
    }

    private void movimentado(Vector2 posicao)
    {
        float result = ultimaPosicao - posicao.y;
        if(result > 0)
        {
            prateleiras.movimentarParaBaixo();
        }
        else if(result < 0)
        {
            prateleiras.movimentarParaCima();
        }
        ultimaPosicao = posicao.y;        
    }

    private void popularBotoes()
    {
        for (int contadorPrateleiras = 0; contadorPrateleiras < prateleirasDto.PrateleiraDto.Length; contadorPrateleiras++)
        {
            PrateleiraArmarioDto prateleiraDtoIt = prateleirasDto.PrateleiraDto[contadorPrateleiras];
            for (int contadorItens = 0; contadorItens < prateleiraDtoIt.ItensPrateleira.Length; contadorItens++)
            {
                ItemPrateleiraDto itemPrateleiraIt = prateleiraDtoIt.ItensPrateleira[contadorItens];
                itemPrateleiraIt.BtnItem.onClick.AddListener(() => cricado());
            }
        }
    }

    
    private void cricado()
    {
        GameObject goSelecionado = EventSystem.current.currentSelectedGameObject;
        int nomeBtn    = int.Parse(goSelecionado.name);
        int nomeParent = int.Parse(goSelecionado.transform.parent.name);

        Debug.Log("Cricado nome " + nomeBtn + " parent " + nomeParent);

        ItemPrateleiraDto itemSelecionado = prateleirasDto.PrateleiraDto[nomeParent].ItensPrateleira[nomeBtn];
        RectTransform rItemSelecionado = (RectTransform)itemSelecionado.BtnItem.gameObject.transform;
        
        //Vector2 pivot = rTransformScrollRect.pivot;
        //Debug.Log("Pivot " + pivot);
        RectTransform rtScrollRect = ((RectTransform)scrollRect.transform);
        Vector2 centro = rtScrollRect.rect.center;
        //Debug.Log("Centro " + centro);

        if(referencia == null)
        {
            referencia = rectTransformReferencia.position;
        }

        Utils.MonoBehaviour.StartCoroutine(zoomando(rtScrollRect, rItemSelecionado));
    }

    private IEnumerator zoomando(RectTransform rTransformScroll, RectTransform rTransformItem)
    {

        rTransformScroll.anchoredPosition -= (rTransformItem.anchoredPosition - rectTransformReferencia.anchoredPosition);

        //TENTATIVA 1
        //Debug.Log("Referencia " + rectTransformReferencia + " Item " + (Vector2)rTransformItem.position + " Scroll anchor " + rTransformScroll.anchoredPosition);

        //float distancia = Vector2.Distance(rTransformItem.position, referencia);
        //while (distancia > 0.1f)
        //{
        //    Vector2 diferenca = Vector2.MoveTowards(rTransformItem.position, referencia, 2 * Time.deltaTime);            
        //    rTransformScroll.anchoredPosition = diferenca;
        //    distancia = Vector2.Distance(rTransformItem.position, referencia);

        //    Debug.Log("Referencia " + referencia + " Item " + (Vector2)rTransformItem.position + " diferenca " + diferenca + " Scroll anchor " + rTransformScroll.anchoredPosition + " Distancia " + distancia);            
        //    yield return null;
        //}
        //Debug.Log("Terminado");
        yield return null;
    }
}
