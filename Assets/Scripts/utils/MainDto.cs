using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class MainDto 
{
    [SerializeField] private GarraDto garraDto;
    [Space(5)]
    [SerializeField] private ColetaveisDto coletaveisDto;
    [Space(5)]
    [SerializeField] private MaquinaDto maquinaDto;
    [Space(5)]
    [SerializeField] private CameraShakeDto camShakeDto;

    public GarraDto GarraDto { get { return garraDto; } }
    public ColetaveisDto ColetaveisDto { get { return coletaveisDto; } }
    public MaquinaDto MaquinaDto { get { return maquinaDto; } }
    public CameraShakeDto CamShakeDto { get { return camShakeDto; } }
}
