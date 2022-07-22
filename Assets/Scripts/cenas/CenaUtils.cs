using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class CenaUtils 
{
    public static void irParaCenaMap()
    {
        SceneManager.LoadScene("MapScene");
    }

    public static void irParaCenaPup()
    {
        SceneManager.LoadScene("PupSceneV2");
    }

    public static void irParaCenaMainGame()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    public static void irParaCenaMainGame(float delay)
    {
        Utils.MonoBehaviour.StartCoroutine(coroutineIrParaCenaMainGame(delay));
    }

    private static IEnumerator coroutineIrParaCenaMainGame(float delay)
    {
        yield return new WaitForSeconds(delay);
        irParaCenaMainGame();
        yield return null;
    }

    public static void irParaCenaColetaveis()
    {
        SceneManager.LoadScene("ColetaveisSceneV2");
    }

    public static void irParaCenaNaoImplementada()
    {
        SceneManager.LoadScene("NotImplementedScene");
    }

    public static void irParaCenaLoja()
    {
        SceneManager.LoadScene("LojaScene");
    }

    public static void irParaCenaConfig()
    {
        SceneManager.LoadScene("ConfigScene");
    }
}
