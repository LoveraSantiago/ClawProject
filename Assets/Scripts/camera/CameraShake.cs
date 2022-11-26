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

    //TODO refatorar muitos argumentos
    public void shakeEDiminuir(
        float amplitude, Vector3 offset, float ganhoFreq, float duracao)
    {
        perlim.m_PivotOffset = offset;
        perlim.m_FrequencyGain = ganhoFreq;
        perlim.m_AmplitudeGain = amplitude;
        ContextoEstaticoUtils.monoBehaviour.StartCoroutine(diminuirEfeito(amplitude, duracao));
    }

    public void shakeEParar(
        float amplitude, Vector3 offset, float ganhoFreq, float duracao)
    {
        perlim.m_PivotOffset = offset;
        perlim.m_FrequencyGain = ganhoFreq;
        perlim.m_AmplitudeGain = amplitude;
        ContextoEstaticoUtils.monoBehaviour.StartCoroutine(pararEfeito(duracao));
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
