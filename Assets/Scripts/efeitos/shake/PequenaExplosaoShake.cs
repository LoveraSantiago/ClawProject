using UnityEngine;

public class PequenaExplosaoShake : AbstractShake
{
    private MonoBehaviour monoBehaviour;

    public PequenaExplosaoShake(MonoBehaviour monoBehaviour)
    {
        this.monoBehaviour = monoBehaviour;
    }

    public override void shake()
    {
        float amplitude = 1f;

        perlim.m_PivotOffset = new Vector3(50, 50, 50);
        perlim.m_FrequencyGain = 50;
        perlim.m_AmplitudeGain = amplitude;
        monoBehaviour.StartCoroutine(pararEfeito(0.4f));
    }    
}
