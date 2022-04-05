using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class SingleSlotColetadoDto 
{
    [SerializeField] private SpriteRenderer sprRendererSlotColetado;

    public SpriteRenderer SprRendererSlotColetado { get { return sprRendererSlotColetado; } }
}
