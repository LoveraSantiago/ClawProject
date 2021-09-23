using UnityEngine;

public class PlayerPrefsPup 
{
    private static readonly string PUP = "PUP";    

    public static void salvarIndicePup(int indicePup)
    {
        PlayerPrefs.SetInt(PUP, indicePup);
    }

    public static int recuperarIndicePup()
    {
        int indiceSalvo = PlayerPrefs.GetInt(PUP);        
        return indiceSalvo;
    }

    public static int recuperarEApagarIndicePup()
    {
        int indice = recuperarIndicePup();
        PlayerPrefs.DeleteKey(PUP);
        return indice;
    }

    public static int recuperarQtdPup(string nomePup)
    {
        return PlayerPrefs.GetInt(nomePup);
    }

    public static void adicionarPup(string nomePup, int qtd)
    {
        int atual = recuperarQtdPup(nomePup);
        atual += qtd;
        salvarQtdPup(nomePup, atual);
    }

    public static int subtrairPup(string nomePup)
    {
        int qtdAtual = recuperarQtdPup(nomePup);
        if(qtdAtual > 0)
        {
            qtdAtual--;
        }
        salvarQtdPup(nomePup, qtdAtual);
        return qtdAtual;
    }

    private static void salvarQtdPup(string nomePup, int qtd)
    {
        PlayerPrefs.SetInt(nomePup, qtd);
    }
}
