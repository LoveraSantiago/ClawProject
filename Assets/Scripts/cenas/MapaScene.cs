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
    [SerializeField] private Transform transformSegundos;
    [SerializeField] private Transform transformMinutos;
    [SerializeField] private Transform transformHoras;
    [Space(5)]
    [SerializeField] private BotoesCenasDto botoesCenasDto;

    private Relogio relogio;

    private void Start()
    {
        btnLevel1.onClick.AddListener(() => goToLevelFase(Level.HUM   , new Level1()));
        btnLevel2.onClick.AddListener(() => goToLevelFase(Level.DOIS  , new Level2()));
        btnLevel3.onClick.AddListener(() => goToLevelFase(Level.TRES  , new Level3()));
        btnLevel4.onClick.AddListener(() => goToLevelFase(Level.QUATRO, new Level4()));

        new BotoesCenasMapa(botoesCenasDto);

        relogio = new Relogio(transformSegundos, transformMinutos, transformHoras);
    }

    private void Update()
    {
        relogio.updateSegundo();
    }   

    private void goToLevelFase(Level levelEnum, AbstractLevel level)
    {
        modalObjetivo.SetActive(true);
        PlayerPrefsLevel.salvarLevel(levelEnum);
        showModalParaOLevel(level);
    }

    private void showModalParaOLevel(AbstractLevel level)
    {
        string nivelName = level.getLevelName();
        string objetivo = level.getMsgObjetivoLevel();

        GameObject nivelText    = GameObject.Find("NivelText");
        GameObject objetivoText = GameObject.Find("ObjetivoText");

        nivelText.GetComponent<Text>().text = nivelName;
        objetivoText.GetComponent<Text>().text = objetivo;
    }
}
