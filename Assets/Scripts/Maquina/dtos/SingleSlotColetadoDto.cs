using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class SingleSlotColetadoDto 
{
    [SerializeField] private SpriteRenderer sprRendererSlotColetado;
    [Space(3)]
    [SerializeField] private SpriteRenderer sprRendererSlotBaixo;
    [SerializeField] private SpriteRenderer sprRendererSlotMeio;
    [SerializeField] private SpriteRenderer sprRendererSlotCima;

    public SpriteRenderer SprRendererSlotColetado { get { return sprRendererSlotColetado; } }
    public SpriteRenderer SprRendererSlotBaixo { get { return sprRendererSlotBaixo; } }
    public SpriteRenderer SprRendererSlotMeio { get { return sprRendererSlotMeio; } }
    public SpriteRenderer SprRendererSlotCima { get { return sprRendererSlotCima; } }

    public GameObject GoSlotBaixo { get { return sprRendererSlotBaixo.gameObject; } }
    public GameObject GoSlotCima  { get { return sprRendererSlotCima.gameObject; } }
}
