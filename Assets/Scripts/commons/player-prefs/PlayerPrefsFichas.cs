using UnityEngine;
using System;

public class PlayerPrefsFichas 
{
    private static readonly string CHAVE_QTD = "qtd";
    private static readonly string CHAVE_TEMPO = "tempo";
    private static readonly string CHAVE_GANHAR_FICHA_BRONZE = "temfichabronze";

    public int getQtdFichas(Ficha ficha)
    {
        string chave = gerarChaveQtdFichas(ficha);

        if (!PlayerPrefs.HasKey(chave))
        {
            salvarLimiteParaFicha(ficha);
        }
        return PlayerPrefs.GetInt(chave);
    }

    private void salvarLimiteParaFicha(Ficha ficha)
    {
        string chave = gerarChaveQtdFichas(ficha);
        FichaEntidade fichaEntidade = FichaEntidade.getFichaEntidade(ficha);
        PlayerPrefs.SetInt(chave, fichaEntidade.limiteFree);
    }

    public bool possueFichas(Ficha ficha, int qtd)
    {
        string chave = gerarChaveQtdFichas(ficha);
        int qtdAtual = PlayerPrefs.GetInt(chave);
        return qtdAtual >= qtd;
    }

    public void consumirFicha(Ficha ficha, int qtd)
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
    
    public void ganharFicha(Ficha ficha, int qtd)
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
                while (qtdAnterior < qtdAtual)
                {
                    ultimaData = ultimaData.AddHours(fichaEntidade.intervaloHoras)
                                           .AddMinutes(fichaEntidade.intervaloMinutos);
                    qtdAnterior++;
                }
                saveDataFicha(ficha, ultimaData);
            }
        }
    }  

    public void ganhouFichasBronzeCacaNiquel(int qtd)
    {
        PlayerPrefs.SetInt(CHAVE_GANHAR_FICHA_BRONZE, qtd);
    }
    
    public int getFichasDeBronzeGanhasCacaNiquel()
    {
        int result = PlayerPrefs.GetInt(CHAVE_GANHAR_FICHA_BRONZE, 0);
        if (result > 0)
        {
            ganhouFichasBronzeCacaNiquel(0);
        }
        return result;
    }

    public DateTime getDataFicha(Ficha ficha)
    {
        string chaveTempo = gerarChaveTempo(ficha);
        string tempoFicha = PlayerPrefs.GetString(chaveTempo);
        return DateTime.Parse(tempoFicha);
    }

    private void saveDataFicha(Ficha ficha, DateTime dataFicha)
    {
        string chaveTempo = gerarChaveTempo(ficha);
        PlayerPrefs.SetString(chaveTempo, dataFicha.ToString());
    }

    private string gerarChaveQtdFichas(Ficha ficha)
    {
        return ficha.ToString() + CHAVE_QTD;
    }

    private string gerarChaveTempo(Ficha ficha)
    {
        return ficha.ToString() + CHAVE_TEMPO;
    }
}
