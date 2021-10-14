using UnityEngine;
using UnityEngine.SceneManagement;
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
        btnLevel1.onClick.AddListener(() => goToLevelFase(LevelFlowManager.LEVEL.HUM   , new Level1()));
        btnLevel2.onClick.AddListener(() => goToLevelFase(LevelFlowManager.LEVEL.DOIS  , new Level2()));
        btnLevel3.onClick.AddListener(() => goToLevelFase(LevelFlowManager.LEVEL.TRES  , new Level3()));
        btnLevel4.onClick.AddListener(() => goToLevelFase(LevelFlowManager.LEVEL.QUATRO, new Level4()));

        btnCards  .onClick.AddListener(() => goToPupScene());
        btnStore  .onClick.AddListener(() => goToNotImplementedScene());
        btnScore  .onClick.AddListener(() => goToNotImplementedScene());
        btnPelucia.onClick.AddListener(() => gotoColetaveisScene());
        btnConfig .onClick.AddListener(() => goToNotImplementedScene());
    }   

    private void goToPupScene()
    {
        SceneManager.LoadScene("PupScene");
    }   

    private void gotoColetaveisScene()
    {
        SceneManager.LoadScene("ColetaveisScene");
    }

    private void goToNotImplementedScene()
    {
        SceneManager.LoadScene("NotImplementedScene");
    }

    private void goToLevelFase(LevelFlowManager.LEVEL levelEnum, AbstractLevel level)
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
