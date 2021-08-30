using Cinemachine;
using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class CameraDto 
{
    [SerializeField] private NoiseSettings noise6d;
    [Space(3)]
    [SerializeField] private CinemachineVirtualCamera virtualCam1;
    [SerializeField] private CinemachineVirtualCamera virtualCam2;
    [SerializeField] private CinemachineVirtualCamera virtualCam3;

    public NoiseSettings Noise6d { get { return noise6d; } }
    public CinemachineVirtualCamera VirtualCam1 { get { return virtualCam1; } }
    public CinemachineVirtualCamera VirtualCam2 { get { return virtualCam2; } }
    public CinemachineVirtualCamera VirtualCam3 { get { return virtualCam3; } }
}
