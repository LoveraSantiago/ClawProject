using UnityEngine;

public class PlayerPrefsPowerUp 
{
    private static readonly string PUP = "PUP";    
    private static readonly string PUP_SCROLL = "PUPSCROLL";    

    public static void salvarIndicePup(int indicePup)
    {
        PlayerPrefs.SetString(PUP, indicePup.ToString());
    }

    public static void salvarPosScroll(float posScroll)
    {
        PlayerPrefs.SetFloat(PUP_SCROLL, posScroll);
    }

    public static int recuperarIndicePup()
    {
        string textoIndiceSalvo = PlayerPrefs.GetString(PUP);
        if(textoIndiceSalvo != null && !textoIndiceSalvo.Equals(""))
        {
            return int.Parse(textoIndiceSalvo);
        }
        return -1;        
    }

    public static int recuperarEApagarIndicePup()
    {
        int indice = recuperarIndicePup();
        PlayerPrefs.DeleteKey(PUP);
        return indice;
    }

    public static float getPosScroll()
    {
        return PlayerPrefs.GetFloat(PUP_SCROLL);
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

    public static void adicionarPup(PowerUpEnums.TIPO tipo, int qtd)
    {
        string nomePup = PowerUpHelper.getNomePupByTipo(tipo);
        adicionarPup(nomePup, qtd);
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
