using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#pragma warning disable 0649
public class ColetaveisSceneV2 : MonoBehaviour 
{
    [SerializeField] private TimerFichaDto timerFichaDto;
    [Space(5)]
    [SerializeField] private PrateleiraArmarioDto[] prateleiraDto;
    [Space(5)]
    [SerializeField] private GameObject prefabMateriais;
    [SerializeField] private GameObject prefabColetaveisDto;

    private TimerFicha timerFichaOuro;

    void Start()
    {
        Utils.configMainMono(this);
        MateriaisUtils.configurar(prefabMateriais);
        HelperColetavelEntidade.configurar(prefabColetaveisDto);

        PlayerPrefsColetaveis.unlockFamilia(ColetavelEntidade.FAMILIA.FRUTAS.ToString());//TEMPORARIAMENTE AQUI               

        timerFichaOuro = new TimerFicha(timerFichaDto, Ficha.OURO);

        HelperColetavelEntidade helperColetavel = new HelperColetavelEntidade();
        Sprite[] sprites = helperColetavel.getAllSpritesColetaveisOrdenados();
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
    }

    private void Update()
    {
        timerFichaOuro.update();
    }
}
