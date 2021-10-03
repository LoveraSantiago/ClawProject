using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapaScene : MonoBehaviour
{
    [SerializeField] private GameObject modalObjetivo;
    [Space(5)]
    [SerializeField] private Button btnLevel1;
    [SerializeField] private Button btnLevel2;
    [SerializeField] private Button btnLevel3;
    [SerializeField] private Button btnLevel4;

    private void Start()
    {
        btnLevel1.onClick.AddListener(() => goToLevelFase(LevelFlowManager.LEVEL.HUM   , new Level1()));
        btnLevel2.onClick.AddListener(() => goToLevelFase(LevelFlowManager.LEVEL.DOIS  , new Level2()));
        btnLevel3.onClick.AddListener(() => goToLevelFase(LevelFlowManager.LEVEL.TRES  , new Level3()));
        btnLevel4.onClick.AddListener(() => goToLevelFase(LevelFlowManager.LEVEL.QUATRO, new Level4()));
    }   

    public void goToPupScene()
    {
        SceneManager.LoadScene("PupScene");
    }

    private void goToLevelFase(LevelFlowManager.LEVEL levelEnum, AbstractLevel level)
    {
        modalObjetivo.SetActive(true);
        PlayerPrefsLevel.salvarLevel(LevelFlowManager.LEVEL.QUATRO);
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
