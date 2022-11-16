using UnityEngine;

#pragma warning disable 0649
public class MapaScene : MonoBehaviour,
                         AcaoMapaNavegado.ConsumidorEvento
{
    [SerializeField] private MainMapaDto mainMapaDto;                        

    private AllTimersFichas allTimersFichas;
    private MapaUi mapaUi;    

    private void Start()
    {
        ContextoEstaticoUtils.configMainMono(this);
        MateriaisUtils.configurar(mainMapaDto.PrefabMateriais);
        PowerUpEntidade.configurarDicionarioDeSpritesPup(mainMapaDto.PrefabPowerUpDto);
        FactoryPowerUpEntidade.resetContextoEstatico();

        PrefabLoading prefabLoading = mainMapaDto.PrefabLoading.GetComponent<PrefabLoading>();
        SomManagerMap somManager = new SomManagerMap(mainMapaDto.AudioMapDto);
        Loading loading = prefabLoading.getLoading(somManager);

        allTimersFichas = new AllTimersFichas(mainMapaDto.TimerFichaDto, loading);        
        ModalMapsManager modalManager = new ModalMapsManager(mainMapaDto, loading);
        new BotoesCenasMapa(mainMapaDto.BotoesCenasDto, loading);

        mapaUi = new MapaUi(mainMapaDto.LevelMapaUiDto);

        PrefabLevelsDto prefabLevels = mainMapaDto.PrefabLevelsDto.GetComponent<PrefabLevelsDto>();
        HelperMapaEntidade.configurar(prefabLevels);
        NavegacaoMapas navegacaoMapas = new NavegacaoMapas(mainMapaDto.BotoesNavegacao);        

        new AcaoMapaNavegado()
            .configurarProdutor(navegacaoMapas)
            .adicionarConsumidor(this)
            .adicionarConsumidor(modalManager);

        new AcaoBotaoMapaAcionado()
            .configurarProdutor(mapaUi.grupoBtnBaloes)
            .adicionarConsumidor(modalManager);

        loading.fecharModal();
        navegacaoMapas.inicializar();
    }

    private void Update()
    {
        allTimersFichas.update();        
    }

    //private void OnDisable()
    //{
    //    //PlayerPrefsMapas.salvarIndiceLevelLiberado(100);
    //    Debug.Log("OnDisable chamado");
    //    FactoryMapaEntidade factoryMapaEntidade = new FactoryMapaEntidade();
    //    PlayerPrefsMapas.salvarChallengeDoMapa(
    //         factoryMapaEntidade.getMapaEntidadeByMapaEnum(MapaEnum.FRUTAS),
    //         2,
    //         0);
    //}

    void AcaoMapaNavegado.ConsumidorEvento.consumirEvento(WrapperLevelMapDto evento)
    {
        mapaUi.addMapaParaTela(evento);        
    }
}
