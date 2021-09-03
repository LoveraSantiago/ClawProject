using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class DisplaysSlotsDto 
{
    [SerializeField] private float inicialDelay;
    [SerializeField] private float fimDelay;
    [SerializeField] private float velocImg;
    [Space(3)]
    [SerializeField] private Sprite sprVazio;
    [SerializeField] private Sprite sprMoeda;    
    [Space(3)]
    [SerializeField] private SingleDisplaySlotDto[] singleDisplaySlotDto = new SingleDisplaySlotDto[3];

    public float InicialDelay { get { return inicialDelay; } }
    public float FimDelay { get { return fimDelay; } }
    public float VelocImg { get { return velocImg; } }

    public Sprite SprVazio { get { return sprVazio; } }
    public Sprite SprMoeda { get { return sprMoeda; } }

    public SingleDisplaySlotDto[] SingleDisplaySlotDto { get { return singleDisplaySlotDto; } }    
}
