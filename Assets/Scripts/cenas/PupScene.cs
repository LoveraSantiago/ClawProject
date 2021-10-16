using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#pragma warning disable 0649
public class PupScene : MonoBehaviour
{
    [SerializeField] private Button btnBack;
    [SerializeField] private Button btnPratica;    
    [SerializeField] private Button btnCacaNiquelPupIndividual;
    [SerializeField] private Button btnCacaNiquelPupGeral;
    [Space(5)]
    [SerializeField] private BlocoImgDto blocoImgDto;    
    [SerializeField] private GameObject prefabPowerUpDto;
    [Space(5)]
    [SerializeField] private AllLabelsPupDto labelsDto;
    [Space(5)]
    [SerializeField] private GameObject prefabBottomBar;
    
    // Start is called before the first frame update
    void Start()
    {
        Utils.configMainMono(this);
        PowerUpEntidade.configurarDicionarioDeSpritesPup(prefabPowerUpDto);

        BlocoImg blocoImg   = new BlocoImg(blocoImgDto);
        AllLabels allLables = new AllLabels(labelsDto);
        ScrollBottomBarPupScene scBottomBar = new ScrollBottomBarPupScene(prefabBottomBar);

        configBtnBack(btnBack);
        configBtnPratica(btnPratica, blocoImg);
        configBtnCacaNiquelIndividual(btnCacaNiquelPupIndividual, blocoImg);
        configBtnCacaNiquelGeral(btnCacaNiquelPupGeral, blocoImg);

        new AcaoBlocoImgPUpAtual()
            .configurarProdutor(blocoImg)
            .adicionarConsumidor(allLables);

        new AcaoBBarPupEscolhido<int>()
            .configurarProdutor(scBottomBar)
            .adicionarConsumidor(blocoImg);

        blocoImg.startLaizy();
    }   

    private void configBtnBack(Button btnBack)
    {
        btnBack.onClick.AddListener(() => SceneManager.LoadScene("MapScene"));
    }

    private void configBtnPratica(Button btnPratica, BlocoImg blocoImg)
    {
        btnPratica.onClick.AddListener(() => {            
            irGameScene(LevelFlowManager.LEVEL.PUP, blocoImg);            
        });
    }

    private void configBtnCacaNiquelIndividual(Button btnCacaNiquel, BlocoImg blocoImg)
    {
        btnCacaNiquel.onClick.AddListener(() => {            
            irGameScene(LevelFlowManager.LEVEL.CACANIQUEL_PUP_I, blocoImg);            
        });
    }

    private void configBtnCacaNiquelGeral(Button btnCacaNiquel, BlocoImg blocoImg)
    {
        btnCacaNiquel.onClick.AddListener(() => {
            irGameScene(LevelFlowManager.LEVEL.CACANIQUEL_PUP_G, blocoImg);
        });
    }

    private void irGameScene(LevelFlowManager.LEVEL level, BlocoImg blocoImg)
    {
        PlayerPrefsLevel.salvarLevel(level);
        PlayerPrefsPup.salvarIndicePup(blocoImg.getIndicePupAtual());
        SceneManager.LoadScene("MainGameScene");
    }
}
