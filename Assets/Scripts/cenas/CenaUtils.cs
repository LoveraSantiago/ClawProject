using UnityEngine.SceneManagement;

public class CenaUtils 
{
    public static void irParaCenaMap()
    {
        SceneManager.LoadScene("MapScene");
    }

    public static void irParaCenaPup()
    {
        SceneManager.LoadScene("PupScene");
    }

    public static void irParaCenaMainGame()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    public static void irParaCenaColetaveis()
    {
        SceneManager.LoadScene("ColetaveisScene");
    }

    public static void irParaCenaNaoImplementada()
    {
        SceneManager.LoadScene("NotImplementedScene");
    }

    public static void irParaCenaLoja()
    {
        SceneManager.LoadScene("LojaScene");
    }
}
