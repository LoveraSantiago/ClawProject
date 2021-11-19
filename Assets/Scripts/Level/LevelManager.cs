using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Text pontuacaoFinal;

    public void startLevel()
    {
        CenaUtils.irParaCenaMainGame();
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
