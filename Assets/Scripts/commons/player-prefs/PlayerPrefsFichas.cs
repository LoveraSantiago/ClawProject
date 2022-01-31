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
            salvarLimiteParaFicha(ficha);
        }
        return PlayerPrefs.GetInt(chave);
    }

    private static void salvarLimiteParaFicha(Ficha ficha)
    {
        string chave = gerarChaveQtdFichas(ficha);
        FichaEntidade fichaEntidade = FichaEntidade.getFichaEntidade(ficha);
        PlayerPrefs.SetInt(chave, fichaEntidade.limiteFree);
    }

    public static bool possueFichas(Ficha ficha, int qtd)
    {
        string chave = gerarChaveQtdFichas(ficha);
        int qtdAtual = PlayerPrefs.GetInt(chave);
        return qtdAtual >= qtd;
    }

    public static void consumirFicha(Ficha ficha, int qtd)
    {
        if (qtd > 0)
        {
            string chaveQtd = gerarChaveQtdFichas(ficha);

            int qtdAtual = PlayerPrefs.GetInt(chaveQtd);
            qtdAtual -= qtd;
            PlayerPrefs.SetInt(chaveQtd, qtdAtual);

            FichaEntidade fichaEntidade = FichaEntidade.getFichaEntidade(ficha);
            if(qtdAtual < fichaEntidade.limiteFree)
            {
                string chaveTempo = gerarChaveTempo(ficha);
                if (!PlayerPrefs.HasKey(chaveTempo))
                {
                    DateTime dateTimeNow = DateTime.Now;
                    //dateTimeNow = dateTimeNow.AddMinutes(-28);
                    //Debug.Log("Registrando hora " + dateTimeNow.ToString());
                    saveDataFicha(ficha, dateTimeNow);
                }
            }
        }
    }

    public static void adicionarFicha(Ficha ficha, int qtd)
    {
        if(qtd > 0)
        {
            string chaveQtd = gerarChaveQtdFichas(ficha);

            int qtdAnterior = PlayerPrefs.GetInt(chaveQtd);
            int qtdAtual = qtdAnterior + qtd;
            PlayerPrefs.SetInt(chaveQtd, qtdAtual);

            FichaEntidade fichaEntidade = FichaEntidade.getFichaEntidade(ficha);
            if (qtdAtual >= fichaEntidade.limiteFree)
            {
                string chaveTempo = gerarChaveTempo(ficha);
                PlayerPrefs.DeleteKey(chaveTempo);
            }
            else
            {
                DateTime ultimaData = getDataFicha(ficha);
                while(qtdAnterior < qtdAtual)
                {
                    ultimaData = ultimaData.AddHours(fichaEntidade.intervaloHoras)
                                           .AddMinutes(fichaEntidade.intervaloMinutos);
                    qtdAnterior++;
                }
                saveDataFicha(ficha, ultimaData);
            }
        }
    }

    public static DateTime getDataFicha(Ficha ficha)
    {
        string chaveTempo = gerarChaveTempo(ficha);
        string tempoFicha = PlayerPrefs.GetString(chaveTempo);
        return DateTime.Parse(tempoFicha);
    }

    private static void saveDataFicha(Ficha ficha, DateTime dataFicha)
    {
        string chaveTempo = gerarChaveTempo(ficha);
        PlayerPrefs.SetString(chaveTempo, dataFicha.ToString());
    }

    private static string gerarChaveQtdFichas(Ficha ficha)
    {
        return ficha.ToString() + CHAVE_QTD;
    }

    private static string gerarChaveTempo(Ficha ficha)
    {
        return ficha.ToString() + CHAVE_TEMPO;
    }
}
