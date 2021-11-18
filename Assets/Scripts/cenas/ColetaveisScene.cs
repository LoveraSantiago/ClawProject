using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

#pragma warning disable 0649
public class ColetaveisScene : MonoBehaviour, 
                               IPointerClickHandler     
{
    [SerializeField] private Button btnBack;   
    [Space(5)]
    [SerializeField] private BlocoImgColetaveisDto blocoImgDto;
    [SerializeField] private BlocoImgDetalheColetavelDto blocoImgDetalheDto;
    [Space(5)]
    [SerializeField] private Material materialGrayScale;
    [SerializeField] private GameObject prefabColetaveisDto;
    [Space(5)]
    [SerializeField] private GameObject prefabBottomBar;

    private BlocoImgColetaveis blocoImg;

    // Start is called before the first frame update
    void Start()
    {
        Utils.configMainMono(this);
        Utils.configMainMatGrayScale(materialGrayScale);
        ColetavelHelper.configurar();
        PlayerPrefsColetaveis.unlockFamilia(ColetavelEntidade.FAMILIA.FRUTAS.ToString());//TEMPORARIAMENTE AQUI       

        ColetavelEntidade.FAMILIA[] familias = { ColetavelEntidade.FAMILIA.FRUTAS,
                                                 ColetavelEntidade.FAMILIA.FAKE };

        PrefabDeSpriteDto prefabSpritesDto = prefabColetaveisDto.GetComponent<PrefabDeSpriteDto>();
        Dictionary<string, Sprite> dicionarioDeSprites = prefabSpritesDto.getDicionarioDeSprites();
        blocoImg = new BlocoImgColetaveis(familias, dicionarioDeSprites, blocoImgDto);
        BlocoImgColetaveisDetalhe blocoImgDetalhe = new BlocoImgColetaveisDetalhe(blocoImgDetalheDto);
        ScrollBottomBarSceneColetaveis scBottomBar = new ScrollBottomBarSceneColetaveis(prefabBottomBar, familias, dicionarioDeSprites);

        new AcaoBlocoImgColetavelAtual()
            .configurarProdutor(blocoImg)
            .adicionarConsumidor(blocoImgDetalhe);

        new AcaoBBarPupEscolhido<int>()
            .configurarProdutor(scBottomBar)
            .adicionarConsumidor(blocoImg);

        configBtnBack(btnBack);
        configBtnGanharColetado(blocoImgDetalheDto.BtnGanharColetavel);
        blocoImg.startLaizy();
    }   

    public void OnPointerClick(PointerEventData eventData)
    {
        blocoImg.clicouNaImg(eventData.pointerEnter);
    }

    private void configBtnBack(Button btnBack)
    {
        btnBack.onClick.AddListener(() => CenaUtils.irParaCenaMap());
    }

    private void configBtnGanharColetado(Button btnBack)
    {
        PlayerPrefsLevel.salvarLevel(LevelFlowManager.LEVEL.COLETAVEL);
        btnBack.onClick.AddListener(() => SceneManager.LoadScene("MainGameScene"));
    }   
}
