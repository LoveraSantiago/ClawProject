using UnityEngine;

public class PlayerPrefsPowerUp 
{
    private static readonly string PUP = "PUP";    
    private static readonly string PUP_SCROLL = "PUPSCROLL";    
    private static readonly string PUP_AGENDADO = "PUPSAGENDADOS";    

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

    public static void agendarPup(string nomePup, int qtd)
    {        
        WrapperArrayStringInteiro wrapper = recuperarPupAgendado();     
        WrapperSingleStringInteiro single = new WrapperSingleStringInteiro();
        single.texto = nomePup;
        single.qtd = qtd;

        WrapperSingleStringInteiro[] stringInteiros = ArrayUtils.adicionarAoArray(wrapper.stringInteiros, single);
        wrapper.stringInteiros = stringInteiros;
        string agendados = JsonUtility.ToJson(wrapper);
        Debug.Log("Agendado valor: " + agendados);
        PlayerPrefs.SetString(PUP_AGENDADO, agendados);
    }

    public static int recuperarPupAgendado(string nomePup)
    {
        WrapperArrayStringInteiro wrapper = recuperarPupAgendado();
        for(int contador = 0; contador < wrapper.stringInteiros.Length; contador++)
        {
            if (nomePup.Equals(wrapper.stringInteiros[contador].texto))
            {
                PlayerPrefs.DeleteKey(PUP_AGENDADO);
                return wrapper.stringInteiros[contador].qtd;
            }
        }
        PlayerPrefs.DeleteKey(PUP_AGENDADO);
        return 0;
    }

    private static WrapperArrayStringInteiro recuperarPupAgendado()
    {        
        string agendados = PlayerPrefs.GetString(PUP_AGENDADO);
        Debug.Log("Recuperado agendados " + agendados);
        if (Utils.isBlank(agendados))
        {
            WrapperArrayStringInteiro wrapperArrayStringInteiro = new WrapperArrayStringInteiro();
            WrapperSingleStringInteiro[] stringInteiros = new WrapperSingleStringInteiro[0];
            wrapperArrayStringInteiro.stringInteiros = stringInteiros;
            return wrapperArrayStringInteiro;
        }
        else
        {
            return JsonUtility.FromJson<WrapperArrayStringInteiro>(agendados);
        }
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
