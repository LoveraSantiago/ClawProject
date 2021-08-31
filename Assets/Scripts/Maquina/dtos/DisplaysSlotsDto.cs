using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class DisplaysSlotsDto 
{
    [SerializeField] private float inicialDelay;
    [SerializeField] private float fimDelay;
    [SerializeField] private float velocImg;
    [SerializeField] private Sprite sprVazio;
    [Space(5)]
    [SerializeField] private Material materialGlowDisplay;
    [Space(5)]
    [SerializeField] private SingleDisplaySlotDto[] singleDisplaySlotDto = new SingleDisplaySlotDto[3];

    public float InicialDelay { get { return inicialDelay; } }
    public float FimDelay { get { return fimDelay; } }
    public float VelocImg { get { return velocImg; } }
    public Sprite SprVazio { get { return sprVazio; } }

    public SingleDisplaySlotDto[] SingleDisplaySlotDto { get { return singleDisplaySlotDto; } }

    public Material MaterialGlowDisplay { get { return materialGlowDisplay; } }
}
