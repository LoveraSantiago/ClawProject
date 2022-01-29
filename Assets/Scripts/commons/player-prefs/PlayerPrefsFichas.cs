using UnityEngine;
using System;

public class PlayerPrefsFichas 
{
    private static readonly string CHAVE_QTD = "qtd";
    private static readonly string CHAVE_TEMPO = "tempo";

    public static int getQtdFichas(Ficha ficha)
    {
        string chave = gerarChaveQtdFichas(ficha);

        if (!PlayerPrefs.HasKey(chave))
        {
            FichaEntidade fichaEntidade = FichaEntidade.getFichaEntidade(ficha);
            PlayerPrefs.SetInt(chave, fichaEntidade.limiteFree);
        }
        return PlayerPrefs.GetInt(chave);
    }

    public static bool possueFichas(Ficha ficha, int qtd)
    {
        string chave = gerarChaveQtdFichas(ficha);
        int qtdAtual = PlayerPrefs.GetInt(chave);
        return qtdAtual >= qtd;
    }

    public static void consumirFicha(Ficha ficha, int qtd)
    {
        string chave = gerarChaveQtdFichas(ficha);

        int qtdAtual = PlayerPrefs.GetInt(chave);
        qtdAtual -= qtd;
        PlayerPrefs.SetInt(chave, qtdAtual);

        FichaEntidade fichaEntidade = FichaEntidade.getFichaEntidade(ficha);
        if(qtdAtual < fichaEntidade.limiteFree)
        {
            DateTime dateTimeNow = DateTime.Now;
        }
    }

    private static string gerarChaveQtdFichas(Ficha ficha)
    {
        return ficha.ToString() + CHAVE_QTD;
    }
}
