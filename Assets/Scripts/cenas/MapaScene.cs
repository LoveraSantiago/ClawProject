using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
public class MapaScene : MonoBehaviour
{       
    
    [SerializeField] private TimerFichaDto[] timerFichaDto = new TimerFichaDto[3];
    [Space(5)]
    [SerializeField] private LevelMapaUiDto levelMapaUiDto;
    [Space(5)]
    [SerializeField] private ModalFaseDto modalFaseDto;
    [Space(5)]    
    [SerializeField] private ModalNoFichaDto modalNoFichaDto;
    [Space(5)]
    [SerializeField] private BotoesCenasDto botoesCenasDto;
    [Space(5)]
    [SerializeField] private GameObject prefabLevelsDto;

    private AllTimersFichas allTimersFichas;
    private LevelMapaUi levelMapaUi;

    private void Start()
    {
        ModalMapsManager modalManager = new ModalMapsManager(modalFaseDto, modalNoFichaDto);
        new BotoesCenasMapa(botoesCenasDto);

        allTimersFichas = new AllTimersFichas(timerFichaDto);        

        PrefabLevelsDto prefabLevels = prefabLevelsDto.GetComponent<PrefabLevelsDto>();
        LevelMapDto[] levelsMapDto = prefabLevels.getLevelsMapDto();

        levelMapaUi = new LevelMapaUi(levelMapaUiDto);
        levelMapaUi.addMapaParaTela(1, levelsMapDto[0]);
    }

    private void Update()
    {
        allTimersFichas.update();
    }    
}
