using UnityEngine;

public class LevelItemDto 
{
    public Vector3 posicaoItem { get; private set; }
    public Material materialItem { get; private set; }

    public LevelItemDto(Vector3 posicaoItem, Material materialItem)
    {
        this.posicaoItem = posicaoItem;
        this.materialItem = materialItem;
    }
}
