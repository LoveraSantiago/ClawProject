using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

#pragma warning disable 0649
public class ColetaveisSceneV2 : MonoBehaviour 
{
    [SerializeField] private RectTransform pRef;
    [Space(5)]
    [SerializeField] private TimerFichaDto timerFichaDto;
    [Space(5)]
    [SerializeField] private RectTransform rTransformArmario;
    [SerializeField] private ScrollRect scrollRect;
    [Space(5)]
    [SerializeField] private int qtdPrateleirasVisiveis;
    [SerializeField] private PrateleiraArmarioDto[] prateleiraDto;
    [Space(5)]
    [SerializeField] private GameObject prefabMateriais;
    [SerializeField] private GameObject prefabColetaveisDto;

    private TimerFicha timerFichaOuro;

    private float ultimaPosicao;
    private PrateleiraArmarioDto prateleiraCima;
    private PrateleiraArmarioDto prateleiraBaixo;

    void Start()
    {
        Utils.configMainMono(this);
        MateriaisUtils.configurar(prefabMateriais);
        HelperColetavelEntidade.configurar(prefabColetaveisDto);

        PlayerPrefsColetaveis.unlockFamilia(ColetavelEntidade.FAMILIA.FRUTAS.ToString());//TEMPORARIAMENTE AQUI               

        timerFichaOuro = new TimerFicha(timerFichaDto, Ficha.OURO);

        HelperColetavelEntidade helperColetavel = new HelperColetavelEntidade();
        Sprite[] sprites = helperColetavel.getAllSpritesColetaveisOrdenados();        
        float result = ((float)sprites.Length)/ ((float)prateleiraDto[0].ItensPrateleira.Length);        
        int qtdPrateleira = (int) Math.Ceiling(result);
        int acrescimoPrateleiras = qtdPrateleirasVisiveis - qtdPrateleira;

        Debug.Log(
               "DPos = " + rTransformArmario.position.y +
               " Offset min = " + rTransformArmario.offsetMin.y +
               " Offset max = " + (-rTransformArmario.offsetMax.y) +
               " Trans = " + rTransformArmario.transform.position.y +
               " min " + rTransformArmario.rect.min.y +
               " rect pos = " + rTransformArmario.rect.position.y +
               " rect y = " + rTransformArmario.rect.y +
               " yMin = " + rTransformArmario.rect.yMin +
               " yMax = " + rTransformArmario.rect.yMax +
               " altura = " + rTransformArmario.rect.height);


        rTransformArmario.offsetMin += new Vector2(rTransformArmario.offsetMin.x, (acrescimoPrateleiras * 400));

        Debug.Log(
               "APos = " + rTransformArmario.position.y +
               " Offset min = " + rTransformArmario.offsetMin.y +
               " Offset max = " + (-rTransformArmario.offsetMax.y) +
               " Trans = " + rTransformArmario.transform.position.y +
               " min " + rTransformArmario.rect.min.y +
               " rect pos = " + rTransformArmario.rect.position.y +
               " rect y = " + rTransformArmario.rect.y +
               " yMin = " + rTransformArmario.rect.yMin +
               " yMax = " + rTransformArmario.rect.yMax +
               " altura = " + rTransformArmario.rect.height);

        int contadorSprites = 0;
        for(int contadorPrateleiras = 0; contadorPrateleiras < prateleiraDto.Length; contadorPrateleiras++)
        {
            PrateleiraArmarioDto prateleiraDtoIt = prateleiraDto[contadorPrateleiras];
            for (int contadorItens = 0; contadorItens < prateleiraDtoIt.ItensPrateleira.Length; contadorItens++)
            {
                ItemPrateleiraDto itemPrateleiraIt = prateleiraDtoIt.ItensPrateleira[contadorItens];
                if (contadorSprites < sprites.Length)
                {
                    itemPrateleiraIt.ImgItem.sprite = sprites[contadorSprites];
                    contadorSprites++;
                }
                else
                {
                    itemPrateleiraIt.GoItem.SetActive(false);
                }
            }
        }

        prateleiraCima = prateleiraDto[0];
        prateleiraBaixo = prateleiraDto[prateleiraDto.Length - 1];
        Debug.Log("Nome " + prateleiraBaixo.RectTransformPrateleira.name);

        scrollRect.onValueChanged.AddListener((pos) => movimentado(pos));
        ultimaPosicao = 1;
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
            float posYPrateleira = prateleiraBaixo.RectTransformPrateleira.transform.position.y;

            Debug.Log(
                "*Pos = " + rTransformArmario.position.y +
                " Anchor pos =" + rTransformArmario.anchoredPosition.y +
                " Offset min = " + rTransformArmario.offsetMin.y +
                " Offset max = " + (-rTransformArmario.offsetMax.y) +
                " Trans = " + rTransformArmario.transform.position.y +
                " min " + rTransformArmario.rect.min.y +
                " rect pos = " + rTransformArmario.rect.position.y +
                " rect y = " + rTransformArmario.rect.y +
                " yMin = " + rTransformArmario.rect.yMin +
                " yMax = " + rTransformArmario.rect.yMax +
                " altura = " + rTransformArmario.rect.height / 2);

            Debug.Log(
                "%Pos = " + prateleiraBaixo.RectTransformPrateleira.position.y +
                " Anchor pos =" + prateleiraBaixo.RectTransformPrateleira.anchoredPosition.y +
                " Offset min = " + prateleiraBaixo.RectTransformPrateleira.offsetMin.y +
                " Offset max = " + (-prateleiraBaixo.RectTransformPrateleira.offsetMax.y) +
                " Trans = " + prateleiraBaixo.RectTransformPrateleira.transform.position.y +
                " min " + prateleiraBaixo.RectTransformPrateleira.rect.min.y +
                " rect pos = " + prateleiraBaixo.RectTransformPrateleira.rect.position.y +
                " rect y = " + prateleiraBaixo.RectTransformPrateleira.rect.y +
                " yMin = " + prateleiraBaixo.RectTransformPrateleira.rect.yMin +
                " yMax = " + prateleiraBaixo.RectTransformPrateleira.rect.yMax +
                " altura = " + prateleiraBaixo.RectTransformPrateleira.rect.height / 2);

            Debug.Log("Result = " + (prateleiraBaixo.RectTransformPrateleira.anchoredPosition.y + rTransformArmario.offsetMax.y));
        }
        else if(result < 0)
        {
            Debug.Log("Desce");

        }
        ultimaPosicao = posicao.y;        
    }
}
