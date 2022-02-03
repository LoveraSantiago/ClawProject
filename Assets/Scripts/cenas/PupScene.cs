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

    private ModalNoFicha modalNoFicha;
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

        modalNoFicha = new ModalNoFicha(modalNoFichaDto);
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
            irGameScenePupPratica(blocoImg);            
        });
    }

    private void configBtnCacaNiquelIndividual(Button btnCacaNiquel, BlocoImgPup blocoImg)
    {
        btnCacaNiquel.onClick.AddListener(() => {            
            irGameScenePupIndividual(blocoImg);            
        });
    }

    private void configBtnCacaNiquelGeral(Button btnCacaNiquel, BlocoImgPup blocoImg)
    {
        btnCacaNiquel.onClick.AddListener(() => {
            irGameScenePupGeral(blocoImg);
        });
    }

    private void irGameScenePupPratica(BlocoImgPup blocoImg)
    {
        PlayerPrefsLevel.salvarLevel(Level.PUP);
        abrirCenaOuModal(blocoImg.getIndicePupAtual(), 0);
    }

    private void irGameScenePupIndividual(BlocoImgPup blocoImg)
    {
        PlayerPrefsLevel.salvarLevel(Level.CACANIQUEL_PUP_I);

        int indicePup = blocoImg.getIndicePupAtual();
        PowerUpEntidade pupEntidade = FactoryPowerUpEntidade.getPowerUpFromIndice(indicePup);
        int precoFicha = int.Parse(pupEntidade.preco);

        abrirCenaOuModal(indicePup, precoFicha);        
    }

    private void irGameScenePupGeral(BlocoImgPup blocoImg)
    {
        PlayerPrefsLevel.salvarLevel(Level.CACANIQUEL_PUP_G);
        abrirCenaOuModal(blocoImg.getIndicePupAtual(), 1);        
    }

    private void abrirCenaOuModal(int indiceAtual, int precoFicha)
    {
        if (PlayerPrefsFichas.possueFichas(Ficha.BRONZE, precoFicha))
        {
            PlayerPrefsFichas.consumirFicha(Ficha.BRONZE, precoFicha);
            PlayerPrefsPup.salvarIndicePup(indiceAtual);
            CenaUtils.irParaCenaMainGame();
        }
        else
        {
            modalNoFicha.ligar();
        }
    }
}
