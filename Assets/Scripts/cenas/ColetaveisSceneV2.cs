using System;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
public class ColetaveisSceneV2 : MonoBehaviour 
{   
    [Space(5)]
    [SerializeField] private TimerFichaDto timerFichaDto;
    [Space(5)]
    [SerializeField] private RectTransform rTransformArmario;
    [SerializeField] private ScrollRect scrollRect;
    [Space(5)]
    [SerializeField] private int qtdPrateleirasVisiveis;
    [SerializeField] private RectTransform rTransformRefBaixo;
    [SerializeField] private PrateleiraArmarioDto[] prateleiraDto;
    [Space(5)]
    [SerializeField] private GameObject prefabMateriais;
    [SerializeField] private GameObject prefabColetaveisDto;

    private TimerFicha timerFichaOuro;

    private float ultimaPosicao;
    private float posYReferenciaBaixo;
    private PrateleiraArmarioDto prateleiraCima;
    private PrateleiraArmarioDto prateleiraBaixo;

    private Sprite[] sprites;
    private int contadorSprites;
    private int contadorPrateleiraCima;

    void Start()
    {
        Utils.configMainMono(this);
        MateriaisUtils.configurar(prefabMateriais);
        HelperColetavelEntidade.configurar(prefabColetaveisDto);

        PlayerPrefsColetaveis.unlockFamilia(ColetavelEntidade.FAMILIA.FRUTAS.ToString());//TEMPORARIAMENTE AQUI               

        timerFichaOuro = new TimerFicha(timerFichaDto, Ficha.OURO);

        HelperColetavelEntidade helperColetavel = new HelperColetavelEntidade();
        sprites = helperColetavel.getAllSpritesColetaveisOrdenados();        
        float result = ((float)sprites.Length)/ ((float)prateleiraDto[0].ItensPrateleira.Length);        
        int qtdPrateleira = (int) Math.Ceiling(result);
        int acrescimoPrateleiras = qtdPrateleirasVisiveis - qtdPrateleira;

        Debug.Log("Pos Antes " + rTransformRefBaixo.position.y);
        rTransformArmario.offsetMin += new Vector2(rTransformArmario.offsetMin.x, (acrescimoPrateleiras * 400));
        posYReferenciaBaixo = rTransformRefBaixo.position.y;
        Debug.Log("Pos Depois " + rTransformRefBaixo.position.y);

        contadorSprites = 0;
        for (int contadorPrateleiras = 0; contadorPrateleiras < prateleiraDto.Length; contadorPrateleiras++)
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

        prateleiraCima = prateleiraDto[contadorPrateleiraCima++];
        prateleiraBaixo = prateleiraDto[prateleiraDto.Length - 1];        

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
            Debug.Log("Ref = " + posYReferenciaBaixo + " prat = " + posYPrateleira);
            if(posYPrateleira > posYReferenciaBaixo)
            {
                for(int contadorItens = 0; contadorItens < prateleiraCima.ItensPrateleira.Length; contadorItens++)
                {
                    ItemPrateleiraDto itemPrateleiraIt = prateleiraCima.ItensPrateleira[contadorItens];
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
                Vector2 posBaixo = prateleiraBaixo.RectTransformPrateleira.anchoredPosition;
                prateleiraCima.RectTransformPrateleira.anchoredPosition = new Vector2(posBaixo.x, posBaixo.y - 400f);
                prateleiraBaixo = prateleiraCima;
                prateleiraCima  = prateleiraDto[contadorPrateleiraCima++ % prateleiraDto.Length];
            }
        }
        else if(result < 0)
        {
            Debug.Log("Desce");

        }
        ultimaPosicao = posicao.y;        
    }
}
