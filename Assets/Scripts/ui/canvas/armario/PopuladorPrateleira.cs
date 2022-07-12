using UnityEngine;

public class PopuladorPrateleira
{
    private bool estadoUltimaFamilia;
    private ColetavelEntidade.FAMILIA ultimaFamilia;

    private PoolMaterialGrayscale poolMaterialGrayScale;
    private HelperColetavelEntidade helperColetavelEntidade;

    public PopuladorPrateleira()
    {
        helperColetavelEntidade = new HelperColetavelEntidade();
        ultimaFamilia = ColetavelEntidade.FAMILIA.DEFAULTS;
        poolMaterialGrayScale = new PoolMaterialGrayscale();
    }

    public void popularItemDaPrateleira(ItemPrateleiraDto itemPrateleira, Sprite sprite)
    {
        //Debug.Log("Vai popular item " + itemPrateleira.ImgItem.gameObject.name + " sprite " + sprite.name);
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

    public void disposePrateleira(PrateleiraArmarioDto prateleira)
    {
        //Debug.Log("Dispose " + prateleira.RectTransformPrateleira.name);
        for (int contador = 0; contador < prateleira.ItensPrateleira.Length; contador++)
        {   
            ItemPrateleiraDto itemPrateleiraIT = prateleira.ItensPrateleira[contador];
            if(itemPrateleiraIT.ImgItem.color != Color.black)
            {
                Material matReuso = itemPrateleiraIT.ImgItem.material;
                if ("mat-grayscale".Equals(matReuso.name))
                {
                    poolMaterialGrayScale.addObjeto(matReuso);
                    itemPrateleiraIT.ImgItem.material = null;
                }
            }
        }
    }

    private void popularMaterialItem(ItemPrateleiraDto itemPrateleira, ColetavelEntidade coletavel, Sprite sprite)
    {
        if (PlayerPrefsColetaveis.isColetavelIndisponivel(coletavel.nome))
        {
            //Debug.Log("Vai popular item grayscale" + itemPrateleira.ImgItem.gameObject.name + " sprite " + sprite.name);
            Material matGray = poolMaterialGrayScale.getObjeto(sprite);
            itemPrateleira.ImgItem.material = matGray;
        }
        else
        {
            //Debug.Log("NAO Vai popular item grayscale" + itemPrateleira.ImgItem.gameObject.name + " sprite " + sprite.name);
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
