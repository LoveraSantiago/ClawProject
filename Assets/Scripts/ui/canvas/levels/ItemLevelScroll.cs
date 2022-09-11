using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLevelScroll 
{
    private ItemLevelDto itemLevelDto;

    public ItemLevelScroll(ItemLevelDto itemLevelDto)
    {
        this.itemLevelDto = itemLevelDto;
    }

    public float getHaltura()
    {
        return itemLevelDto.RItem.rect.height;
    }

    public float getPosY()
    {
        return itemLevelDto.RItem.position.y;
    }
}
