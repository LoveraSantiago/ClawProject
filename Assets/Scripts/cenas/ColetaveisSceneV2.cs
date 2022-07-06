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
    [SerializeField] private RectTransform rTransformRefCima;
    [SerializeField] private RectTransform rTransformRefBaixo;
    [SerializeField] private PrateleiraArmarioDto[] prateleiraDto;
    [Space(5)]
    [SerializeField] private GameObject prefabMateriais;
    [SerializeField] private GameObject prefabColetaveisDto;

    private TimerFicha timerFichaOuro;

    private float ultimaPosicao;
    private float posYReferenciaBaixo;
    private float posYReferenciaCima;
    private PrateleiraArmarioDto prateleiraCima;
    private PrateleiraArmarioDto prateleiraBaixo;

    private Sprite[] sprites;
    private int contadorBaixoSprites;
    private int contadorCimaSprites;    

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

        rTransformArmario.offsetMin += new Vector2(rTransformArmario.offsetMin.x, (acrescimoPrateleiras * 400));
        posYReferenciaBaixo = rTransformRefBaixo.position.y;
        posYReferenciaCima = rTransformRefCima.position.y;        

        contadorBaixoSprites = 0;
        contadorCimaSprites = 0;
        for (int contadorPrateleiras = 0; contadorPrateleiras < prateleiraDto.Length; contadorPrateleiras++)
        {
            PrateleiraArmarioDto prateleiraDtoIt = prateleiraDto[contadorPrateleiras];
            for (int contadorItens = 0; contadorItens < prateleiraDtoIt.ItensPrateleira.Length; contadorItens++)
            {
                ItemPrateleiraDto itemPrateleiraIt = prateleiraDtoIt.ItensPrateleira[contadorItens];
                if (contadorBaixoSprites < sprites.Length)
                {
                    itemPrateleiraIt.ImgItem.sprite = sprites[contadorBaixoSprites];                    
                }
                else
                {
                    itemPrateleiraIt.GoItem.SetActive(false);
                }
                contadorBaixoSprites++;
            }
        }

        prateleiraCima  = prateleiraDto[0];
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
            if(contadorBaixoSprites < sprites.Length && posYPrateleira > posYReferenciaBaixo)
            {
                for(int contadorItens = 0; contadorItens < prateleiraCima.ItensPrateleira.Length; contadorItens++)
                {
                    ItemPrateleiraDto itemPrateleiraIt = prateleiraCima.ItensPrateleira[contadorItens];
                    if (contadorBaixoSprites < sprites.Length)
                    {
                        itemPrateleiraIt.ImgItem.sprite = sprites[contadorBaixoSprites];
                        itemPrateleiraIt.GoItem.SetActive(true);
                    }
                    else
                    {
                        itemPrateleiraIt.GoItem.SetActive(false);
                    }
                    contadorBaixoSprites++;
                }
                Vector2 posBaixo = prateleiraBaixo.RectTransformPrateleira.anchoredPosition;
                prateleiraCima.RectTransformPrateleira.anchoredPosition = new Vector2(posBaixo.x, posBaixo.y - 400f);
                prateleiraBaixo = prateleiraCima;
                int indicePrateleira = (int.Parse(prateleiraCima.RectTransformPrateleira.name) + 1) % prateleiraDto.Length;
                prateleiraCima  = prateleiraDto[indicePrateleira];

                contadorCimaSprites += 5;
                Debug.Log("DESCER " + " PCima = " + contadorCimaSprites + " PBaixo = " + contadorBaixoSprites);
            }
        }
        else if(result < 0)
        {
            float posYPrateleira = prateleiraCima.RectTransformPrateleira.transform.position.y;
            if(contadorCimaSprites > 0 && posYPrateleira < posYReferenciaCima)
            {
                for(int contadorItens = prateleiraBaixo.ItensPrateleira.Length - 1; contadorItens >= 0; contadorItens--)
                {
                    ItemPrateleiraDto itemPrateleiraIt = prateleiraBaixo.ItensPrateleira[contadorItens];
                    if(contadorCimaSprites >= 0)
                    {
                        itemPrateleiraIt.ImgItem.sprite = sprites[--contadorCimaSprites];
                        itemPrateleiraIt.GoItem.SetActive(true);

                    }
                    else
                    {
                        itemPrateleiraIt.GoItem.SetActive(false);
                    }
                }
                Vector2 posCima = prateleiraCima.RectTransformPrateleira.anchoredPosition;
                prateleiraBaixo.RectTransformPrateleira.anchoredPosition = new Vector2(posCima.x, posCima.y + 400);
                prateleiraCima = prateleiraBaixo;
                int indicePrateleira = ((int.Parse(prateleiraBaixo.RectTransformPrateleira.name) + prateleiraDto.Length) - 1) % prateleiraDto.Length;
                prateleiraBaixo = prateleiraDto[indicePrateleira];

                contadorBaixoSprites -= 5;
                Debug.Log("SUBIR" + " PCima = " + contadorCimaSprites + " PBaixo = " + contadorBaixoSprites);
            }
        }
        ultimaPosicao = posicao.y;        
    }

    
}
