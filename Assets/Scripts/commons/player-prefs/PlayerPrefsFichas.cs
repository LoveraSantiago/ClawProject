using UnityEngine;

public class PlayerPrefsFichas 
{
    private static readonly string CHAVE_QTD = "qtd";

    public static int getQtdFichas(Ficha ficha)
    {
        string chave = ficha.ToString() + CHAVE_QTD;

        if (!PlayerPrefs.HasKey(chave))
        {
            FichaEntidade fichaEntidade = FichaEntidade.getFichaEntidade(ficha);
            PlayerPrefs.SetInt(chave, fichaEntidade.limiteFree);
        }
        return PlayerPrefs.GetInt(chave);
    }
}
