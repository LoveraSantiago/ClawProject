using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapaManager : MonoBehaviour
{
    [SerializeField]
    private GameObject levelObjetivo;


    public void showTarget1()
    {
        levelObjetivo.SetActive(true);
        PlayerPrefsLevel.salvarLevel(LevelFlowManager.LEVEL.HUM);
        updateModal(new Level1());
    }

    public void showTarget2()
    {
        levelObjetivo.SetActive(true);
        PlayerPrefsLevel.salvarLevel(LevelFlowManager.LEVEL.DOIS);              
        updateModal(new Level2());
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
