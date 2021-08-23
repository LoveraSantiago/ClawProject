using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class MainDto 
{
    [SerializeField] private GarraDto garraDto;

    public GarraDto GarraDto { get { return garraDto; } }
}
