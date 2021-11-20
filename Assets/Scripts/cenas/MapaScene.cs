using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
public class MapaScene : MonoBehaviour
{
    [SerializeField] private GameObject modalObjetivo;
    [Space(5)]
    [SerializeField] private Button btnLevel1;
    [SerializeField] private Button btnLevel2;
    [SerializeField] private Button btnLevel3;
    [SerializeField] private Button btnLevel4;
    [Space(5)]
    [SerializeField] private Button btnCards;
    [SerializeField] private Button btnScore;
    [SerializeField] private Button btnStore;
    [SerializeField] private Button btnPelucia;
    [SerializeField] private Button btnConfig;

    private void Start()
    {
        btnLevel1.onClick.AddListener(() => goToLevelFase(Level.HUM   , new Level1()));
        btnLevel2.onClick.AddListener(() => goToLevelFase(Level.DOIS  , new Level2()));
        btnLevel3.onClick.AddListener(() => goToLevelFase(Level.TRES  , new Level3()));
        btnLevel4.onClick.AddListener(() => goToLevelFase(Level.QUATRO, new Level4()));

        btnCards  .onClick.AddListener(() => CenaUtils.irParaCenaPup());
        btnStore  .onClick.AddListener(() => CenaUtils.irParaCenaNaoImplementada());
        btnScore  .onClick.AddListener(() => CenaUtils.irParaCenaNaoImplementada());
        btnPelucia.onClick.AddListener(() => CenaUtils.irParaCenaColetaveis());
        btnConfig .onClick.AddListener(() => CenaUtils.irParaCenaNaoImplementada());
    }             

    private void goToLevelFase(Level levelEnum, AbstractLevel level)
    {
        modalObjetivo.SetActive(true);
        PlayerPrefsLevel.salvarLevel(levelEnum);
        updateModal(level);
    }

    private void updateModal(AbstractLevel level)
    {
        string nivelName = level.getLevelName();
        string objetivo = level.getMsgObjetivoLevel();

        GameObject nivelText    = GameObject.Find("NivelText");
        GameObject objetivoText = GameObject.Find("ObjetivoText");

        nivelText.GetComponent<Text>().text = nivelName;
        objetivoText.GetComponent<Text>().text = objetivo;
    }
}
