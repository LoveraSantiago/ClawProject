using System.Collections.Generic;
using UnityEngine;

public class ItemsBottomBarFamilias : ItemsBottomBar
{    
    private string lblQtdAtual;
    private Sprite spriteAtual;
    private Color corAtual;
    private Material materialAtual;        

    public void configurarIndicePesquisado(int indice)
    {
        ColetavelEntidade.FAMILIA familiaAtual = ColetavelEntidade.getFamiliasDeColetaveis()[indice];
        HelperColetavelEntidade helperColetavel = new HelperColetavelEntidade();
        List<ColetavelEntidade> coletaveisDaFamilia = helperColetavel.getListaDeColetaveisEntidadeByFamilia(familiaAtual);
        ColetavelEntidade coletavelEntidade = coletaveisDaFamilia[0];
        spriteAtual = helperColetavel.getSpriteColetavelByNomeSprite(coletavelEntidade.nomeSprite); 

        if (PlayerPrefsColetaveis.isFamiliaLocked(familiaAtual.ToString()))
        {
            lblQtdAtual = "Locked";
            corAtual = Color.black;
            materialAtual = null;
        }
        else if (PlayerPrefsColetaveis.isAllFamiliaComColetaveisDisponiveis(familiaAtual))
        {
            lblQtdAtual = "Ok";
            corAtual = Color.white;
            materialAtual = null;
        }
        else
        {
            lblQtdAtual = "Nok";
            materialAtual = new Material(Utils.materialGrayScale);
            materialAtual.SetTexture("main_text", spriteAtual.texture);
            corAtual = Color.white;
        }
    }

    public string getLabelQtdDoItem()
    {
        return lblQtdAtual;
    }    

    public Sprite getSprDoItem()
    {
        return spriteAtual;
    }

    public Color getCorImgDoItem()
    {
        return corAtual;
    }

    public Material getMaterialDoItem()
    {
        return materialAtual;
    }

    public int getQtdItems()
    {
        return ColetavelEntidade.getFamiliasDeColetaveis().Length;
    }
}
