using UnityEngine;

public class PopuladorPrateleira
{
    
    private ColetavelEntidade.FAMILIA ultimaFamilia;
    private HelperColetavelEntidade helperColetavelEntidade;

    public PopuladorPrateleira()
    {
        helperColetavelEntidade = new HelperColetavelEntidade();
    }

    public void popularItemDaPrateleira(ItemPrateleiraDto itemPrateleira, Sprite sprite)
    {
        itemPrateleira.ImgItem.sprite = sprite;
        itemPrateleira.GoItem.SetActive(true);

        ColetavelEntidade coletavel = helperColetavelEntidade.getColetavelEntidadeBySprite(sprite.name);
        ColetavelEntidade.FAMILIA familiaEntidade = coletavel.familia;
        if(familiaEntidade == ultimaFamilia)
        {
            if (PlayerPrefsColetaveis.isFamiliaNotLocked(familiaEntidade.ToString()))
            {
                if (PlayerPrefsColetaveis.isColetavelIndisponivel(coletavel.nome))
                {
                    Material matGray = MaterialGrayScale.of(sprite);
                    itemPrateleira.ImgItem.material = matGray;
                }
                itemPrateleira.ImgItem.color = Color.white;
            }
            else
            {
                itemPrateleira.ImgItem.color    = Color.black;
                itemPrateleira.ImgItem.material = null;
            }
        }
        else
        {
            if (PlayerPrefsColetaveis.isFamiliaNotLocked(familiaEntidade.ToString()))
            {
                if (PlayerPrefsColetaveis.isColetavelIndisponivel(coletavel.nome))
                {
                    Material matGray = MaterialGrayScale.of(sprite);
                    itemPrateleira.ImgItem.material = matGray;
                }
                itemPrateleira.ImgItem.color = Color.white;
            }
            else
            {
                itemPrateleira.ImgItem.color = Color.black;
                itemPrateleira.ImgItem.material = null;
            }

            ultimaFamilia = familiaEntidade;
        }
    }
}
