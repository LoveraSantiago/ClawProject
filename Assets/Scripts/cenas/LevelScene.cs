using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
public class LevelScene : MonoBehaviour,
                         AcaoLevelFromScrollSelecao.ConsumidorEvento
{
    [SerializeField] private MainLevelDto mainLevelDto;                

    private ScrollLevelManager scrollManager;

    void Start()
    {
        ContextoEstaticoUtils.configMainMono(this);
        MateriaisUtils.configurar(mainLevelDto.PrefabMateriais);
        mainLevelDto.BtnBack.onClick.AddListener(() => voltar());

        scrollManager = new ScrollLevelManager(mainLevelDto.LevelsScrollDto);
        mainLevelDto.ScrollRect.onValueChanged.AddListener((pos) => scrollManager.movimentado(pos, null));

        new AcaoLevelFromScrollSelecao()
            .configurarProdutor(scrollManager)
            .adicionarConsumidor(this);
    }
    
    void AcaoLevelFromScrollSelecao.ConsumidorEvento.consumirEvento(LevelItemScrollSelecaoDto evento)
    {
        mainLevelDto.ImageMaquinaGiratoria.transform.gameObject.SetActive(true);
        mainLevelDto.ImageMaquinaGiratoria.transform.position = evento.posicaoItem;
        MaterialMiniMaquina.addCores(mainLevelDto.ImageMaquinaGiratoria.material, evento.materialItem);
    }

    private void voltar()
    {       
         CenaUtils.irParaCenaMap();       
    }
}
