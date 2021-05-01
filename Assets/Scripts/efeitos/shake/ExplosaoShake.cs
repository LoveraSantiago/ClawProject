using System.Collections;
using UnityEngine;

public class ExplosaoShake : AbstractShake
{
    private MonoBehaviour monoBehaviour;

    public ExplosaoShake(MonoBehaviour monoBehaviour)
    {
        this.monoBehaviour = monoBehaviour;
    }

    public override void shake()
    {
        perlim.m_PivotOffset = new Vector3(0, 0, 10);
        perlim.m_FrequencyGain = 100;
        perlim.m_AmplitudeGain = 1;
        monoBehaviour.StartCoroutine(diminuirEfeito(1));
    }

    private IEnumerator diminuirEfeito(int duracao)
    {
        float amplitudeAtual = Mathf.Lerp(duracao, 0, Time.deltaTime);
        while(amplitudeAtual > 0f)
        {
            perlim.m_AmplitudeGain = amplitudeAtual;
            amplitudeAtual = Mathf.Lerp(amplitudeAtual, 0, Time.deltaTime);
            yield return null;
        }
    }
}
