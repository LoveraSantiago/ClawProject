using UnityEngine;
using System.Collections.Generic;

public class PlayerPrefsColetaveis : MonoBehaviour
{
    private const string TAG_INDICE_FAMILIA = "IndiceFamilia";
    private const string TAG_NAVEGACAO_COLETAVEL = "IndiceColetavel";

    public static bool isFamiliaNotLocked(string nomeFamilia)
    {
        return !isFamiliaLocked(nomeFamilia);
    }

    public static bool isFamiliaLocked(string nomeFamilia)
    {
        int resultado = PlayerPrefs.GetInt(nomeFamilia);
        if (resultado == 0) return true;
        return false;
    }

    public static bool isAllFamiliaComColetaveisDisponiveis(ColetavelEntidade.FAMILIA familia)
    {
        ColetavelHelper coletavelHelper = new ColetavelHelper();
        List<ColetavelEntidade> coletaveisDaFamilia = coletavelHelper.getListaDeColetaveisEntidadeByFamilia(familia);
        for(int contador = 0; contador < coletaveisDaFamilia.Count; contador++)
        {
            ColetavelEntidade coletavelIt = coletaveisDaFamilia[contador];
            bool indisponivel = isColetavelIndisponivel(coletavelIt.nome);
            if (indisponivel) return false;
        }
        return true;
    }

    public static bool isColetavelDisponivel(string nomeColetavel)
    {
        int resultado = PlayerPrefs.GetInt(nomeColetavel);
        if (resultado == 1) return true;
        return false;
    }

    public static void disponibilizarColetavel(string nome)
    {
        PlayerPrefs.SetInt(nome, 1);        
    }

    public static bool isColetavelIndisponivel(string nomeColetavel)
    {
        return !isColetavelDisponivel(nomeColetavel);
    }

    public static void unlockFamilia(string nomeFamilia)
    {
        PlayerPrefs.SetInt(nomeFamilia, 1);
    }

    public static void salvarIndiceFamilia(int indice)
    {
        PlayerPrefs.SetInt(TAG_INDICE_FAMILIA, indice);
    }

    public static int recuperarEApagarIndiceFamilia()
    {
        int indice = PlayerPrefs.GetInt(TAG_INDICE_FAMILIA);
        PlayerPrefs.DeleteKey(TAG_INDICE_FAMILIA);
        return indice;
    }

    public static void salvarNavegacaoColetavel(int idColetavel)
    {
        PlayerPrefs.SetInt(TAG_NAVEGACAO_COLETAVEL, idColetavel);
    }

    public static int recuperarEApagarNavegacaoColetavel()
    {
        int id = PlayerPrefs.GetInt(TAG_NAVEGACAO_COLETAVEL);
        PlayerPrefs.DeleteKey(TAG_NAVEGACAO_COLETAVEL);
        return id;
    }
}
