using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Text pontuacaoFinal;

    public void startLevel()
    {
        SceneManager.LoadScene("MainContainerSceneV2");
    }

    public void goTotMapScene()
    {
        SceneManager.LoadScene("MapScene");
    }

    public void closeDescricaoObjetivo()
    {
        gameObject.SetActive(false);
    }

    public void atualizarPontuacaoFinla(int points)
    {
        pontuacaoFinal.text = points.ToString();
    }
}
