using UnityEngine;

public class PopuladorPrateleira
{
    public void popularItemDaPrateleira(ItemPrateleiraDto itemPrateleira, Sprite sprite)
    {
        itemPrateleira.ImgItem.sprite = sprite;
        itemPrateleira.GoItem.SetActive(true);
    }
}
