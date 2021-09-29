using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapaScene : MonoBehaviour
{
    [SerializeField]
    private GameObject modalObjetivo;

    public void showTarget1()
    {
        modalObjetivo.SetActive(true);
        PlayerPrefsLevel.salvarLevel(LevelFlowManager.LEVEL.HUM);
        updateModal(new Level1());
    }

    public void showTarget2()
    {
        modalObjetivo.SetActive(true);
        PlayerPrefsLevel.salvarLevel(LevelFlowManager.LEVEL.DOIS);
        updateModal(new Level2());
    }

    public void showTarget3()
    {
        modalObjetivo.SetActive(true);
        PlayerPrefsLevel.salvarLevel(LevelFlowManager.LEVEL.TRES);
        updateModal(new Level3());
    }

    public void showTarget4()
    {
        modalObjetivo.SetActive(true);
        PlayerPrefsLevel.salvarLevel(LevelFlowManager.LEVEL.QUATRO);
        updateModal(new Level4());
    }

    public void goToPupScene()
    {
        SceneManager.LoadScene("PupScene");
    }

    private static void updateModal(AbstractLevel level)
    {
        string nivelName = level.getLevelName();
        string objetivo = level.getMsgObjetivoLevel();

        GameObject nivelText = GameObject.Find("NivelText");
        GameObject objetivoText = GameObject.Find("ObjetivoText");

        nivelText.GetComponent<Text>().text = nivelName;
        objetivoText.GetComponent<Text>().text = objetivo;
    }
}
