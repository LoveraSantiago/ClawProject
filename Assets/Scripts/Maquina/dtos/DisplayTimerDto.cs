using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class DisplayTimerDto
{

    [SerializeField] private SpriteRenderer sprRendererPlaca;    
    [Space(3)]
    [SerializeField] private Material matSegmentosAditivos;
    [SerializeField] private Material matSegmentosAlpha;
    [Space(3)]
    [SerializeField] private SpriteRenderer sprRendererPlacaGrupo;    
    [SerializeField] private SpriteRenderer sprRenderer2Pontos;    
    [Space(3)]
    [SerializeField] private SingleDisplayTimerDto[] singleDisplay = new SingleDisplayTimerDto[5];    

    public SpriteRenderer SprRendererPlaca { get { return sprRendererPlaca; } }
    public SpriteRenderer SprRendererPlacaGrupo { get { return sprRendererPlacaGrupo; } }    

    public Material MatSegmentosAditivos { get { return matSegmentosAditivos; } }
    public Material MatSegmentosAlpha { get { return matSegmentosAlpha; } }    

    public SpriteRenderer SprRenderer2Pontos { get { return sprRenderer2Pontos; } }

    public SingleDisplayTimerDto[] SingleDisplay { get { return singleDisplay; } }
}
