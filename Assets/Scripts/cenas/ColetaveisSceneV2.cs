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
    private Vector2 posItemReferencia;

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
        posItemReferencia = pegarPosicaoReferencia();
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
            prateleiras.movimentarParaBaixo(prateleirasDto);
        }
        else if(result < 0)
        {
            prateleiras.movimentarParaCima(prateleirasDto);
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

    bool iniciado = false;
    private void cricado()
    {
        GameObject goSelecionado = EventSystem.current.currentSelectedGameObject;
        Utils.MonoBehaviour.StartCoroutine(zoomando(goSelecionado));
    }

    private IEnumerator zoomando(GameObject goSelecionado)
    {        
        Vector2 posicaoAnchored = pegarPosicaoClicado(goSelecionado);
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
        yield return null;
    }

    private Vector2 pegarPosicaoReferencia()
    {
        PrateleiraArmarioDto prateleira = prateleirasDto.PrateleiraDto[2];
        ItemPrateleiraDto item = prateleira.ItensPrateleira[2];

        RectTransform rTransformPrateleira = prateleira.RectTransformPrateleira;
        RectTransform rTransformItem = (RectTransform)item.BtnItem.transform;

        return new Vector2(rTransformItem.anchoredPosition.x, rTransformPrateleira.anchoredPosition.y);
    }

    private Vector2 pegarPosicaoClicado(GameObject goSelecionado)
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
