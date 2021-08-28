using Cinemachine;
using UnityEngine;
using System.Collections;

public abstract class AbstractShake 
{
    protected static CameraDto cameraShakeDto;
    protected static CinemachineBasicMultiChannelPerlin perlim;

    public static void configurar(CameraDto cameraShakeDtoArg)
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

    public abstract void shake();

    protected IEnumerator pararEfeito(float duracao)
    {
        yield return new WaitForSeconds(duracao);
        perlim.m_AmplitudeGain = 0;
    }

    protected IEnumerator diminuirEfeito(float amplitude, float duracao)
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
