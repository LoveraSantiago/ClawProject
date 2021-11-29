using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
    [SerializeField] private GameObject prefabMateriais;
    [SerializeField] private GameObject prefabColetaveisDto;
    [Space(5)]
    [SerializeField] private GameObject prefabBottomBar;

    private BlocoImgColetaveis blocoImg;

    // Start is called before the first frame update
    void Start()
    {
        Utils.configMainMono(this);
        MateriaisUtils.configurar(prefabMateriais);        
        
        HelperColetavelEntidade.configurar(prefabColetaveisDto);

        PlayerPrefsColetaveis.unlockFamilia(ColetavelEntidade.FAMILIA.FRUTAS.ToString());//TEMPORARIAMENTE AQUI               
                
        blocoImg = new BlocoImgColetaveis(blocoImgDto);
        BlocoImgColetaveisDetalhe blocoImgDetalhe = new BlocoImgColetaveisDetalhe(blocoImgDetalheDto);
        ScrollBottomBarSceneColetaveis scBottomBar = new ScrollBottomBarSceneColetaveis(prefabBottomBar);
        BotaoIrGameColetaveis btnColetaveis = new BotaoIrGameColetaveis(blocoImgDetalheDto.BtnGanharColetavel);

        new AcaoBlocoImgColetavelAtual()
            .configurarProdutor(blocoImg)
            .adicionarConsumidor(blocoImgDetalhe)
            .adicionarConsumidor(btnColetaveis);

        new AcaoBBarItemEscolhido<int>()
            .configurarProdutor(scBottomBar)
            .adicionarConsumidor(blocoImg);

        configBtnBack(btnBack);        
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
}
