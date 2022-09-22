using UnityEngine;

public class PopuladorPrateleira
{
    private PoolMaterialGrayscale poolMaterialGrayScale;    

    public PopuladorPrateleira()
    {        
        poolMaterialGrayScale = new PoolMaterialGrayscale();
    }

    public void popularItemDaPrateleira(ItemPrateleiraDto itemPrateleira, ColetavelEntidade coletavel)
    {
        //Debug.Log("Vai popular item " + itemPrateleira.ImgItem.gameObject.name + " sprite " + sprite.name);
        itemPrateleira.ImgItem.sprite = coletavel.sprite;
        itemPrateleira.GoItem.SetActive(true);
        if(coletavel.mapaEntidade.isLockado || coletavel.mapaEntidade.isBloqueado)
        {
            popularItemIndisponivel(itemPrateleira);
        }
        else
        {
            itemPrateleira.ImgExclamacao.SetActive(coletavel.isExclamacao);
            popularMaterialItem(itemPrateleira, coletavel);
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
                if (MaterialGrayScale.isMaterialGrayScale(matReuso))
                {
                    poolMaterialGrayScale.addObjeto(matReuso);
                    itemPrateleiraIT.ImgItem.material = null;
                }
            }
        }
    }

    private void popularMaterialItem(ItemPrateleiraDto itemPrateleira, ColetavelEntidade coletavel)
    {
        if (!coletavel.isAdquirido)
        {
            //Debug.Log("Vai popular item grayscale" + itemPrateleira.ImgItem.gameObject.name + " sprite " + sprite.name);
            Material matGray = poolMaterialGrayScale.getObjeto(coletavel.sprite);
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
