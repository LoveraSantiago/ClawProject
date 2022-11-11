using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class CenaUtils 
{
    private static readonly string CENA_MAIN_GAME = "MainGameScene";

    public static void irParaCenaMap()
    {
        irParaCena("MapScene");
    }

    public static void irParaCenaMap(float delay)
    {
        irParaCena("MapScene");
    }

    public static void irParaCenaPup()
    {
        irParaCena("PupSceneV2");
    }

    public static void irParaCenaMainGame()
    {
        irParaCena(CENA_MAIN_GAME);
    }

    public static void irParaCenaMainGame(float delay)
    {
        ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(coroutineIrParaCenaComDelay(delay, CENA_MAIN_GAME));
    }

    public static void irParaCenaColetaveis()
    {
        irParaCena("ColetaveisSceneV2");
    }   

    public static void irParaCenaLoja()
    {
        irParaCena("LojaScene");
    }

    public static void irParaCenaConfig()
    {
        irParaCena("ConfigScene");
    }

    public static void irParaCenaLevels()
    {
        irParaCena("LevelsScene");
    }
    
    private static void irParaCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }

    private static IEnumerator coroutineIrParaCenaComDelay(float delay, string nomeCena)
    {
        yield return new WaitForSeconds(delay);
        irParaCena(nomeCena);
        yield return null;
    }
}
