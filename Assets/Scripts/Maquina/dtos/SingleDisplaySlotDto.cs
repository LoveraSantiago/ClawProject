using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class SingleDisplaySlotDto 
{
    [Space(3)]
    [SerializeField] private SpriteRenderer slotSpriteMeio;
    [SerializeField] private SpriteRenderer slotSpriteCima;
    [Space(3)]
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject goSlotCima;

    public SpriteRenderer SlotSpriteMeio { get { return slotSpriteMeio; } }
    public SpriteRenderer SlotSpriteCima { get { return slotSpriteCima; } }

    public Animator Animator { get { return animator; } }
    public GameObject GoSlotCima { get { return goSlotCima; } }
}
