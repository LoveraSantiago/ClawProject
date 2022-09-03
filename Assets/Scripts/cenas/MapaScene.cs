using UnityEngine;

#pragma warning disable 0649
public class MapaScene : MonoBehaviour, 
                         AcaoItemEscolhido<WrapperLevelMapDto>.ConsumidorEvento
{       
    
    [SerializeField] private TimerFichaDto[] timerFichaDto = new TimerFichaDto[3];
    [Space(5)]
    [SerializeField] private LevelMapaUiDto levelMapaUiDto;
    [Space(5)]
    [SerializeField] private BotoesNavegacaoMapaDto botoesNavegacao;
    [Space(5)]
    [SerializeField] private BotoesCenasDto botoesCenasDto;
    [Space(5)]
    [SerializeField] private ModalFaseDto modalFaseDto;
    [Space(5)]    
    [SerializeField] private ModalNoFichaDto modalNoFichaDto;
    [Space(5)]    
    [SerializeField] private GameObject prefabLevelsDto;
    [SerializeField] private GameObject prefabMateriais;

    private AllTimersFichas allTimersFichas;
    private MapaUi mapaUi;    

    private void Start()
    {
        Utils.configMainMono(this);
        MateriaisUtils.configurar(prefabMateriais);

        allTimersFichas = new AllTimersFichas(timerFichaDto);        
        ModalMapsManager modalManager = new ModalMapsManager(modalFaseDto, modalNoFichaDto);
        new BotoesCenasMapa(botoesCenasDto);

        mapaUi = new MapaUi(levelMapaUiDto);        
        NavegacaoMapas navegacaoMapas = new NavegacaoMapas(botoesNavegacao, prefabLevelsDto);

        new ProdutorConsumidoresDeEvento<WrapperLevelMapDto>()
            .configurarProdutor(navegacaoMapas)
            .adicionarConsumidor(this);

        navegacaoMapas.inicializar();
    }

    private void Update()
    {
        allTimersFichas.update();        
    }

    void AcaoItemEscolhido<WrapperLevelMapDto>.ConsumidorEvento.consumirEvento(WrapperLevelMapDto evento)
    {
        mapaUi.addMapaParaTela(evento);        
    }
}
