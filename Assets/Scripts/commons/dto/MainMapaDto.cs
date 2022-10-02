using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class MainMapaDto 
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

    public TimerFichaDto[] TimerFichaDto { get { return timerFichaDto; } }
    public LevelMapaUiDto LevelMapaUiDto { get { return levelMapaUiDto; } }
    public BotoesNavegacaoMapaDto BotoesNavegacao { get { return botoesNavegacao; } }
    public BotoesCenasDto BotoesCenasDto { get { return botoesCenasDto; } }
    public ModalFaseDto ModalFaseDto { get { return modalFaseDto; } }
    public ModalNoFichaDto ModalNoFichaDto { get { return modalNoFichaDto; } }
    public GameObject PrefabLevelsDto { get { return prefabLevelsDto; } }
    public GameObject PrefabMateriais { get { return prefabMateriais; } }
}
