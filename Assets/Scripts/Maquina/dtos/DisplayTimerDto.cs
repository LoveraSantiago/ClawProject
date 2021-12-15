using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class DisplayTimerDto
{

    [SerializeField] private SpriteRenderer sprRendererPlaca;
    [SerializeField] private SpriteRenderer sprRendererPlacaEfeito;        
    [Space(5)]
    [SerializeField] private SpriteRenderer[] sprRendererMiniSegmentos;
    [Space(5)]
    [SerializeField] private SingleDisplayTimerDto[] singleDisplay = new SingleDisplayTimerDto[5];    

    public SpriteRenderer SprRendererPlaca { get { return sprRendererPlaca; } }
    public GameObject PlacaEfeito { get { return sprRendererPlacaEfeito.gameObject; } }
    public Material MaterialEfeito { get { return sprRendererPlacaEfeito.material; } }    

    public SpriteRenderer[] SprRendererMiniSegmentos { get { return sprRendererMiniSegmentos; } }

    public SingleDisplayTimerDto[] SingleDisplay { get { return singleDisplay; } }
}
