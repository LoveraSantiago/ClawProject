using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class SingleDisplaySlotDto 
{
    [Space(3)]
    [SerializeField] private SpriteRenderer slotSpriteMeio;
    [Space(3)]
    [SerializeField] private Animator animator;

    public SpriteRenderer SlotSpriteMeio { get { return slotSpriteMeio; } }

    public Animator Animator { get { return animator; } }
}
