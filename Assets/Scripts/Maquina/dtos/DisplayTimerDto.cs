using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class DisplayTimerDto
{

    [SerializeField] private SpriteRenderer sprRendererPlaca;
    [SerializeField] private GameObject placaEfeito;
    [SerializeField] private Material materialEfeito;
    [Space(5)]
    [SerializeField] private SingleDisplayTimerDto[] singleDisplay = new SingleDisplayTimerDto[5];    

    public SpriteRenderer SprRendererPlaca { get { return sprRendererPlaca; } }
    public GameObject PlacaEfeito { get { return placaEfeito; } }
    public Material MaterialEfeito { get { return materialEfeito; } }

    public SingleDisplayTimerDto[] SingleDisplay { get { return singleDisplay; } }
}
