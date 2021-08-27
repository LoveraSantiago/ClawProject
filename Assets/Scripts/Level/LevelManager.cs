using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Text pontuacaoFinal;

    public void startLevel()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    public void goTotMapScene()
    {
        SceneManager.LoadScene("MapScene");
    }   

    public void closeDescricaoObjetivo()
    {
        gameObject.SetActive(false);
    }

    public void atualizarPontuacaoFinal(int points)
    {
        pontuacaoFinal.text = points.ToString();
    }
}
