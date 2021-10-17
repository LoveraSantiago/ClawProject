using System.Collections.Generic;
using UnityEngine;

public class ItemsBottomBarColetaveis : ItemsBottomBar
{
    private ColetavelEntidade.FAMILIA[] familias;
    private Dictionary<string, Sprite> dicionarioDeSprites;

    public ItemsBottomBarColetaveis(ColetavelEntidade.FAMILIA[] familias, Dictionary<string, Sprite> dicionarioDeSprites)
    {
        this.familias = familias;
        this.dicionarioDeSprites = dicionarioDeSprites;
    }

    public string getLabelQtdDoItemIndice(int indice)
    {
        ColetavelEntidade.FAMILIA familia = familias[indice];
        if (PlayerPrefsColetaveis.isFamiliaLocked(familia.ToString()))
        {
            return "Locked";
        }
        else if (PlayerPrefsColetaveis.isAllFamiliaComColetaveisDisponiveis(familia))
        {
            return "Ok";
        }
        else
        {
            return "Nok";
        }
    }

    public int getQtdItems()
    {
        return familias.Length;
    }

    public Sprite getSprDoItemIndice(int indice)
    {
        ColetavelEntidade.FAMILIA familia = familias[indice];

        ColetavelHelper coletavelHelper = new ColetavelHelper();
        List<ColetavelEntidade> coletaveisDaFamilia = coletavelHelper.getListaDeColetaveisEntidadeByFamilia(familia);
        ColetavelEntidade coletavelEntidade = coletaveisDaFamilia[0];
        return dicionarioDeSprites[coletavelEntidade.nomeSprite];
    }
}
