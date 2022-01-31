using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
public class PupScene : MonoBehaviour
{
    [SerializeField] private TimerFichaDto timerFichaDto;
    [Space(5)]
    [SerializeField] private Button btnBack;
    [SerializeField] private Button btnPratica;    
    [SerializeField] private Button btnCacaNiquelPupIndividual;
    [SerializeField] private Button btnCacaNiquelPupGeral;
    [Space(5)]
    [SerializeField] private BlocoImgPupDto blocoImgDto;    
    [Space(5)]
    [SerializeField] private AllLabelsPupDto labelsDto;
    [Space(5)]
    [SerializeField] private GameObject prefabPowerUpDto;
    [SerializeField] private GameObject prefabBottomBar;

    private TimerFicha timerFichaBronze;

    // Start is called before the first frame update
    void Start()
    {
        Utils.configMainMono(this);
        FactoryPowerUpEntidade.resetContextoEstatico();
        PowerUpEntidade.configurarDicionarioDeSpritesPup(prefabPowerUpDto);

        BlocoImgPup blocoImg   = new BlocoImgPup(blocoImgDto);
        AllLabelsPup allLables = new AllLabelsPup(labelsDto);
        ScrollBottomBarScenePup scBottomBar = new ScrollBottomBarScenePup(prefabBottomBar);

        configBtnBack(btnBack);
        configBtnPratica(btnPratica, blocoImg);
        configBtnCacaNiquelIndividual(btnCacaNiquelPupIndividual, blocoImg);
        configBtnCacaNiquelGeral(btnCacaNiquelPupGeral, blocoImg);

        new AcaoBlocoImgPUpAtual()
            .configurarProdutor(blocoImg)
            .adicionarConsumidor(allLables);

        new AcaoBBarItemEscolhido<int>()
            .configurarProdutor(scBottomBar)
            .adicionarConsumidor(blocoImg);

        blocoImg.startLaizy();
        timerFichaBronze = new TimerFicha(timerFichaDto, Ficha.BRONZE);
    }

    private void Update()
    {
        timerFichaBronze.update();
    }

    private void configBtnBack(Button btnBack)
    {
        btnBack.onClick.AddListener(() => CenaUtils.irParaCenaMap());
    }

    private void configBtnPratica(Button btnPratica, BlocoImgPup blocoImg)
    {
        btnPratica.onClick.AddListener(() => {            
            irGameScene(Level.PUP, blocoImg);            
        });
    }

    private void configBtnCacaNiquelIndividual(Button btnCacaNiquel, BlocoImgPup blocoImg)
    {
        btnCacaNiquel.onClick.AddListener(() => {            
            irGameScene(Level.CACANIQUEL_PUP_I, blocoImg);            
        });
    }

    private void configBtnCacaNiquelGeral(Button btnCacaNiquel, BlocoImgPup blocoImg)
    {
        btnCacaNiquel.onClick.AddListener(() => {
            irGameScene(Level.CACANIQUEL_PUP_G, blocoImg);
        });
    }

    private void irGameScene(Level level, BlocoImgPup blocoImg)
    {
        PlayerPrefsLevel.salvarLevel(level);
        PlayerPrefsPup.salvarIndicePup(blocoImg.getIndicePupAtual());
        CenaUtils.irParaCenaMainGame();
    }
}
