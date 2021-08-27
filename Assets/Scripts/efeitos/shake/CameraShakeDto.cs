using Cinemachine;
using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class CameraShakeDto 
{
    [SerializeField] private CinemachineVirtualCamera cineMachine;
    [SerializeField] private NoiseSettings noise6d;

    public CinemachineVirtualCamera CineMachine { get { return cineMachine; }}
    public NoiseSettings Noise6d { get { return noise6d; } }
}
