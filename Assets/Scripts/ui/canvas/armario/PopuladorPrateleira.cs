using UnityEngine;

public class PopuladorPrateleira
{
    private bool estadoUltimaFamilia;
    private ColetavelEntidade.FAMILIA ultimaFamilia;
    private HelperColetavelEntidade helperColetavelEntidade;

    public PopuladorPrateleira()
    {
        helperColetavelEntidade = new HelperColetavelEntidade();
        ultimaFamilia = ColetavelEntidade.FAMILIA.DEFAULTS;
    }

    public void popularItemDaPrateleira(ItemPrateleiraDto itemPrateleira, Sprite sprite)
    {
        itemPrateleira.ImgItem.sprite = sprite;
        itemPrateleira.GoItem.SetActive(true);

        ColetavelEntidade coletavel = helperColetavelEntidade.getColetavelEntidadeBySprite(sprite.name);
        ColetavelEntidade.FAMILIA familiaEntidade = coletavel.familia;
        if(familiaEntidade == ultimaFamilia)
        {
            if (estadoUltimaFamilia)
            {
                popularMaterialItem(itemPrateleira, coletavel, sprite);
            }
            else
            {
                popularItemIndisponivel(itemPrateleira);
            }
        }
        else
        {
            estadoUltimaFamilia = PlayerPrefsColetaveis.isFamiliaNotLocked(familiaEntidade.ToString());
            if (estadoUltimaFamilia)
            {
                popularMaterialItem(itemPrateleira, coletavel, sprite);               
            }
            else
            {
                popularItemIndisponivel(itemPrateleira);
            }

            ultimaFamilia = familiaEntidade;
        }
    }

    private void popularMaterialItem(ItemPrateleiraDto itemPrateleira, ColetavelEntidade coletavel, Sprite sprite)
    {
        if (PlayerPrefsColetaveis.isColetavelIndisponivel(coletavel.nome))
        {
            Material matGray = MaterialGrayScale.of(sprite);
            itemPrateleira.ImgItem.material = matGray;
        }
        else
        {
            itemPrateleira.ImgItem.material = null;
        }
        itemPrateleira.ImgItem.color = Color.white;
    }

    private void popularItemIndisponivel(ItemPrateleiraDto itemPrateleira)
    {
        itemPrateleira.ImgItem.color = Color.black;
        itemPrateleira.ImgItem.material = null;
    }
}
