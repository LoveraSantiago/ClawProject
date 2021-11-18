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
        CenaUtils.irParaCenaMap();
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
