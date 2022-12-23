using Cinemachine;
using UnityEngine;
using System.Collections;

public class CameraShake 
{    
    protected static CinemachineBasicMultiChannelPerlin perlim;

    public static void configurar(CameraDto cameraShakeDto)
    {        
        configurarPerlim(cameraShakeDto);
    }

    private static void configurarPerlim(CameraDto cameraShakeDto)
    {
        perlim = cameraShakeDto.VirtualCam1.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        perlim.m_PivotOffset = new Vector3(0, 0, 0);
        perlim.m_AmplitudeGain = 0;
        perlim.m_FrequencyGain = 0;
        perlim.m_NoiseProfile = cameraShakeDto.Noise6d;
    }
        
    public void shakeEDiminuir(CameraShakeDto cameraShakeDto)
    {
        perlim.m_PivotOffset = cameraShakeDto.Offset;
        perlim.m_FrequencyGain = cameraShakeDto.GanhoFreq;
        perlim.m_AmplitudeGain = cameraShakeDto.Amplitude;
        ContextoEstaticoUtils.monoBehaviour.StartCoroutine(diminuirEfeito(cameraShakeDto.Amplitude, cameraShakeDto.Duracao));
    }

    public void shakeEParar(CameraShakeDto cameraShakeDto)
    {
        perlim.m_PivotOffset   = cameraShakeDto.Offset;
        perlim.m_FrequencyGain = cameraShakeDto.GanhoFreq;
        perlim.m_AmplitudeGain = cameraShakeDto.Amplitude;
        ContextoEstaticoUtils.monoBehaviour.StartCoroutine(pararEfeito(cameraShakeDto.Duracao));
    }

    private IEnumerator pararEfeito(float duracao)
    {
        yield return new WaitForSeconds(duracao);
        perlim.m_AmplitudeGain = 0;
    }

    private IEnumerator diminuirEfeito(float amplitude, float duracao)
    {
        float duracaoAtual = duracao;
        yield return new WaitForSeconds(duracao / 2);
        while (duracaoAtual > 0f)
        {
            duracaoAtual -= Time.deltaTime;
            perlim.m_AmplitudeGain = Mathf.Lerp(amplitude, 0, 1 - (duracaoAtual / duracao));
            yield return null;
        }
    }
}
