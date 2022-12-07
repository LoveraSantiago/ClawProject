using UnityEngine;

#pragma warning disable 0649
public class LevelScene : MonoBehaviour,
                         AcaoLevelFromScrollSelecao.ConsumidorEvento
{
    [SerializeField] private MainLevelDto mainLevelDto;                

    private ScrollLevelManager scrollManager;
    private SomManagerLevel somManager;

    void Start()
    {
        ContextoEstaticoUtils.configMainMono(this);

        PrefabLoading prefabLoading = mainLevelDto.PrefabLoading.GetComponent<PrefabLoading>();
        somManager = new SomManagerLevel(mainLevelDto.AudioLevelDto);
        prefabLoading.iniciarLoading(somManager, mainLevelDto.GosDesligar);
        ContextoEstaticoUtils.loading.fecharModal();

        MateriaisUtils.configurar(mainLevelDto.PrefabMateriais);
        mainLevelDto.BtnBack.onClick.AddListener(() =>
        {
            somManager.playSomCliqueVoltar();
            ContextoEstaticoUtils.loading.irParaMapScene();
        });

        PrefabLevelsDto prefabLevels = mainLevelDto.PrefabLevelsDto.GetComponent<PrefabLevelsDto>();
        HelperMapaEntidade.configurar(prefabLevels);

        scrollManager = new ScrollLevelManager(mainLevelDto.LevelsScrollDto);
        mainLevelDto.ScrollRect.onValueChanged.AddListener((pos) => scrollManager.movimentado(pos, null));

        new AcaoLevelFromScrollSelecao()
            .configurarProdutor(scrollManager)
            .adicionarConsumidor(this);

        somManager.playSomBackground();
    }
    
    void AcaoLevelFromScrollSelecao.ConsumidorEvento.consumirEvento(LevelItemScrollSelecaoDto evento)
    {
        mainLevelDto.ImageMaquinaGiratoria.transform.gameObject.SetActive(true);
        mainLevelDto.ImageMaquinaGiratoria.transform.position = evento.posicaoItem;
        somManager.playSomCliqueItem();
        MaterialMiniMaquina.addCores(mainLevelDto.ImageMaquinaGiratoria.material, evento.materialItem);
    }    
}
