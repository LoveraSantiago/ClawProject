using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class SingleDisplayColetadoDto
{
    [SerializeField] private SpriteRenderer sprDisplay;
    [SerializeField] private SpriteRenderer sprRendererDentro;
    [SerializeField] private SpriteRenderer sprRendererDentroEfeito;
    [Space(3)]
    [SerializeField] private SpriteRenderer slotSpriteBaixo;
    [SerializeField] private SpriteRenderer slotSpriteCima;
    [Space(3)]
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject goSlotBaixo;
    [SerializeField] private GameObject goSlotCima;

    public SpriteRenderer SprDisplay { get { return sprDisplay; } }
    public SpriteRenderer SprRendererDentro { get { return sprRendererDentro; } }
    public SpriteRenderer SprRendererDentroEfeito { get { return sprRendererDentroEfeito; } }

    public SpriteRenderer SlotSpriteBaixo { get { return slotSpriteBaixo; } }
    public SpriteRenderer SlotSpriteCima { get { return slotSpriteCima; } }

    public Animator Animator { get { return animator; } }
    public GameObject GoSlotBaixo { get { return goSlotBaixo; } }
    public GameObject GoSlotCima { get { return goSlotCima; } }

}