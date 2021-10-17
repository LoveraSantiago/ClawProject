using System.Collections.Generic;
using UnityEngine;

public class ItemsBottomBarFamilias : ItemsBottomBar
{
    private ColetavelEntidade.FAMILIA[] familias;
    private Dictionary<string, Sprite> dicionarioDeSprites;

    public ItemsBottomBarFamilias(ColetavelEntidade.FAMILIA[] familias, Dictionary<string, Sprite> dicionarioDeSprites)
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

    public Color getCorImgDoItemIndice(int indice)
    {
        ColetavelEntidade.FAMILIA familia = familias[indice];
        if (PlayerPrefsColetaveis.isFamiliaLocked(familia.ToString()))
        {
            return Color.black;
        }        
        else
        {
            return Color.white;
        }
    }

    public Material getMaterialDoItemIndice(int indice)
    {
        ColetavelEntidade.FAMILIA familia = familias[indice];
        if (PlayerPrefsColetaveis.isFamiliaLocked(familia.ToString()))
        {
            return null;
        }
        else if (!PlayerPrefsColetaveis.isAllFamiliaComColetaveisDisponiveis(familia))
        {
            Material matGrayScale = new Material(Utils.materialGrayScale);
            ColetavelHelper coletavelHelper = new ColetavelHelper();
            List<ColetavelEntidade> coletaveisDaFamilia = coletavelHelper.getListaDeColetaveisEntidadeByFamilia(familia);
            ColetavelEntidade coletavelEntidade = coletaveisDaFamilia[0];
            Sprite sprite = dicionarioDeSprites[coletavelEntidade.nomeSprite];
            matGrayScale.SetTexture("main_text", sprite.texture);
            return matGrayScale;
        }
        else
        {
            return null;
        }
    }
}
