using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class DisplaysColetadosDto 
{
    [SerializeField] private float inicialDelay;
    [SerializeField] private float fimDelay;
    [SerializeField] private float velocImg;
    [Space(3)]
    [SerializeField] private Sprite sprNone;
    [Space(3)]
    [SerializeField] private SingleDisplaySlotDto[] singleDisplaySlotDto = new SingleDisplaySlotDto[3];
    [Space(3)]
    [SerializeField] private CacaNiquelDto cacaNiquelDto;

    public float InicialDelay { get { return inicialDelay; } }
    public float FimDelay { get { return fimDelay; } }
    public float VelocImg { get { return velocImg; } }

    public Sprite SprNone { get { return sprNone; } }
    public SingleDisplaySlotDto[] SingleDisplaySlotDto { get { return singleDisplaySlotDto; } }    

    public CacaNiquelDto CacaNiquelDto { get { return cacaNiquelDto; } }
}
