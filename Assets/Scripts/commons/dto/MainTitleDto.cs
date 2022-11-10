using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class MainTitleDto 
{
    [SerializeField] private GarraTitleDto garraTitleDto;

    public GarraTitleDto GarraTitleDto { get { return garraTitleDto; } }
}
