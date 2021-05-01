using Cinemachine;
using UnityEngine;

public abstract class AbstractShake 
{
    protected static CameraShakeDto cameraShakeDto;
    protected static CinemachineBasicMultiChannelPerlin perlim;

    public static void configurar(CameraShakeDto cameraShakeDtoArg)
    {
        cameraShakeDto = cameraShakeDtoArg;
        configurarPerlim();
    }

    private static void configurarPerlim()
    {
        perlim = cameraShakeDto.CineMachine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        perlim.m_PivotOffset = new Vector3(0, 0, 0);
        perlim.m_AmplitudeGain = 0;
        perlim.m_FrequencyGain = 0;
        perlim.m_NoiseProfile = cameraShakeDto.Noise6d;
    }    
}
