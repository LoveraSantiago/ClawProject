using UnityEngine;

public class LevelItemScrollSelecaoDto 
{
    public Vector3 posicaoItem { get; private set; }
    public Material materialItem { get; private set; }

    public LevelItemScrollSelecaoDto(Vector3 posicaoItem, Material materialItem)
    {
        this.posicaoItem = posicaoItem;
        this.materialItem = materialItem;
    }
}
