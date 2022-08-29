using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
public class LevelScene : MonoBehaviour,
                         AcaoItemEscolhido<LevelItemDto>.ConsumidorEvento
{
    [SerializeField] private Button btnBack;
    [Space(5)]
    [SerializeField] private ScrollRect scrollRect;
    [Space(5)]    
    [SerializeField] private LevelsScrollDto levelsScrollDto;
    [Space(5)]
    [SerializeField] private GameObject prefabMateriais;
    [Space(5)]
    [SerializeField] private Image imageMaquinaGiratoria;

    private LevelsScroll levelsScroll;

    void Start()
    {
        Utils.configMainMono(this);
        MateriaisUtils.configurar(prefabMateriais);
        btnBack.onClick.AddListener(() => voltar());

        levelsScroll = new LevelsScroll(levelsScrollDto);
        scrollRect.onValueChanged.AddListener((pos) => levelsScroll.movimentado(pos, levelsScrollDto));

        new AcaoItemEscolhido<LevelItemDto>()
            .configurarProdutor(levelsScroll)
            .adicionarConsumidor(this);
    }
    
    void AcaoItemEscolhido<LevelItemDto>.ConsumidorEvento.consumirEvento(LevelItemDto evento)
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
