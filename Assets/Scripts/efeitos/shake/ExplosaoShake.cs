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
        float amplitude = 1f;

        perlim.m_PivotOffset = new Vector3(0, 0, 10);
        perlim.m_FrequencyGain = 100;
        perlim.m_AmplitudeGain = amplitude;
        monoBehaviour.StartCoroutine(diminuirEfeito(amplitude, 1));
    }

    private IEnumerator diminuirEfeito(float amplitude, float duracao)
    {
        float duracaoAtual = duracao;
        yield return new WaitForSeconds(duracao / 3);
        while(duracaoAtual > 0f)
        {
            duracaoAtual -= Time.deltaTime;
            perlim.m_AmplitudeGain = Mathf.Lerp(amplitude, 0, 1 - (duracaoAtual / duracao));            
            yield return null;
        }
    }
}
