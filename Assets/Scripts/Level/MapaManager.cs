using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapaManager : MonoBehaviour
{
    [SerializeField]
    private GameObject levelObjetivo;


    public void showTarget1()
    {
        levelObjetivo.SetActive(true);
        PlayerPrefsLevel.salvarLevel(LevelFlowManager.LEVEL.HUM);
        Debug.Log("1");
        //string objetivo = new Level1().getMsgObjetivoLevel();
    }

    public void showTarget2()
    {
        levelObjetivo.SetActive(true);
        PlayerPrefsLevel.salvarLevel(LevelFlowManager.LEVEL.DOIS);
        Debug.Log("2");
    }

}
