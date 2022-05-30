using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class DisplaysColetadosDto 
{
    [SerializeField] private float inicialDelay;
    [SerializeField] private float fimDelay;
    [SerializeField] private float delayMiraSelecionada;
    [SerializeField] private float velocImg;
    [Space(3)]
    [SerializeField] private float posYSlot;
    [SerializeField] private float posYSlotAcrescimo;    
    [Space(3)]
    [SerializeField] private Sprite sprNone;
    [SerializeField] private Sprite sprMiraGrossa;
    [SerializeField] private Material materialAlvoPiscando;
    [SerializeField] private Material materialAlvoSelecionado;
    [Space(3)]
    [SerializeField] private SpriteRenderer sprRendererPlacaGrupo;
    [Space(3)]
    [SerializeField] private SingleSlotColetadoDto[] singleSlotColetadoDto = new SingleSlotColetadoDto[3];
    [Space(3)]
    [SerializeField] private CacaNiquelDto cacaNiquelDto;

    public float InicialDelay { get { return inicialDelay; } }
    public float FimDelay { get { return fimDelay; } }
    public float VelocImg { get { return velocImg; } }
    public float DelayMiraSelecionada { get { return delayMiraSelecionada; } }

    public float PosYSlot { get { return posYSlot; } }
    public float PosYSlotAcrescimo { get { return posYSlotAcrescimo; } }
    public float PosYSlotAcrescimoNeg { get { return -posYSlotAcrescimo; } }

    public Sprite SprNone { get { return sprNone; } }
    public Sprite SprMiraGrossa { get { return sprMiraGrossa; } }
    public Material MaterialAlvoPiscando { get { return materialAlvoPiscando; } }
    public Material MaterialAlvoSelecionado { get { return materialAlvoSelecionado; } }
    public SpriteRenderer SprRendererPlacaGrupo { get { return sprRendererPlacaGrupo; } }

    public SingleSlotColetadoDto[] SingleSlotColetadoDto { get { return singleSlotColetadoDto; } }    

    public CacaNiquelDto CacaNiquelDto { get { return cacaNiquelDto; } }
}
