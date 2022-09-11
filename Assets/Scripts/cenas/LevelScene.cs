using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
public class LevelScene : MonoBehaviour,
                         AcaoLevelFromScrollSelecao.ConsumidorEvento
{
    [SerializeField] private Button btnBack;
    [Space(5)]
    [SerializeField] private ScrollRect scrollRect;
    [Space(5)]    
    [SerializeField] private LevelsScrollDto levelsScrollDto;
    [Space(5)]
    [SerializeField] private Image imageMaquinaGiratoria;
    [Space(5)]
    [SerializeField] private GameObject prefabMateriais;    

    private ScrollLevelManager scrollManager;

    void Start()
    {
        ContextoEstaticoUtils.configMainMono(this);
        MateriaisUtils.configurar(prefabMateriais);
        btnBack.onClick.AddListener(() => voltar());

        scrollManager = new ScrollLevelManager(levelsScrollDto);
        scrollRect.onValueChanged.AddListener((pos) => scrollManager.movimentado(pos, levelsScrollDto));

        new AcaoLevelFromScrollSelecao()
            .configurarProdutor(scrollManager)
            .adicionarConsumidor(this);
    }
    
    void AcaoLevelFromScrollSelecao.ConsumidorEvento.consumirEvento(LevelItemDto evento)
    {
        imageMaquinaGiratoria.transform.gameObject.SetActive(true);
        imageMaquinaGiratoria.transform.position = evento.posicaoItem;
        MaterialMiniMaquina.addCores(imageMaquinaGiratoria.material, evento.materialItem);
    }

    private void voltar()
    {       
         CenaUtils.irParaCenaMap();       
    }
}
