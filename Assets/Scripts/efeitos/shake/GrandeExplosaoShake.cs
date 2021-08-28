using UnityEngine;

public class GrandeExplosaoShake : CameraShake
{
    private MonoBehaviour monoBehaviour;

    public GrandeExplosaoShake(MonoBehaviour monoBehaviour)
    {
        this.monoBehaviour = monoBehaviour;
    }

    public override void shake()
    {
        float amplitude = 1f;

        perlim.m_PivotOffset = new Vector3(150, 150, 150);
        perlim.m_FrequencyGain = 25;
        perlim.m_AmplitudeGain = amplitude;
        monoBehaviour.StartCoroutine(diminuirEfeito(amplitude, 0.4f));
    }
}
