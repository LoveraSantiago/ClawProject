using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

#pragma warning disable 0649
public class ColetaveisSceneV2 : MonoBehaviour 
{
    [SerializeField] private TimerFichaDto timerFichaDto;
    [Space(5)]
    [SerializeField] private RectTransform rTransformArmario;
    [SerializeField] private ScrollRect scrollRect;
    [Space(5)]
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
        int acrescimoPrateleiras = prateleiraDto.Length - qtdPrateleira;        
        rTransformArmario.offsetMin += new Vector2(rTransformArmario.offsetMin.x, (acrescimoPrateleiras * 400));

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
            Debug.Log("Sobe");
            float posYArmario    = scrollRect.content.position.y;
            float posYPrateleira = prateleiraBaixo.RectTransformPrateleira.position.y;
            Debug.Log("Pos Armario Y = " + posYArmario + " Pos Prateleira Y = " + posYPrateleira);
        }
        else if(result < 0)
        {
            Debug.Log("Desce");

        }
        ultimaPosicao = posicao.y;        
    }
}
