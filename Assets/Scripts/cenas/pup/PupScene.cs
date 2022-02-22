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
    [Space(5)]
    [SerializeField] private ModalNoFichaDto modalNoFichaDto;
    
    private TimerFicha timerFichaBronze;

    // Start is called before the first frame update
    void Start()
    {
        Utils.configMainMono(this);
        FactoryPowerUpEntidade.resetContextoEstatico();
        PowerUpEntidade.configurarDicionarioDeSpritesPup(prefabPowerUpDto);

        BlocoImgPowerUp blocoImg   = new BlocoImgPowerUp(blocoImgDto);
        AllLabelsPowerUp allLables = new AllLabelsPowerUp(labelsDto);
        ScrollBottomBarScenePowerUp scBottomBar = new ScrollBottomBarScenePowerUp(prefabBottomBar);

        NavegacaoPowerUp navegacao = new NavegacaoPowerUp(modalNoFichaDto);

        configBtnBack(btnBack);
        btnPratica.onClick.AddListener(() => navegacao.irGameScenePupPratica(blocoImg));
        btnCacaNiquelPupIndividual.onClick.AddListener(() => navegacao.irGameScenePupIndividual(blocoImg));
        btnCacaNiquelPupGeral.onClick.AddListener(() => navegacao.irGameScenePupGeral(blocoImg));        

        new AcaoBlocoImgPowerUpAtual()
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
}
