using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class SingleSlotColetadoDto 
{
    [SerializeField] private SpriteRenderer sprRendererSlot;
    [SerializeField] private SpriteRenderer sprRendererSlotColetado;

    public SpriteRenderer SprRendererSlot { get { return sprRendererSlot; } }
    public SpriteRenderer SprRendererSlotColetado { get { return sprRendererSlotColetado; } }

    public GameObject GoSlot { get { return sprRendererSlot.gameObject; } }
}
