using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class AudioTitleDto 
{
    [SerializeField] private float delayInicioSomGarra;
    [SerializeField] private float delayStopSomGarra;
    [Space(3)]
    [SerializeField] private float delayBumpTexto1;
    [SerializeField] private float delayBumpTexto2;
    [SerializeField] private float delayBumpTexto3;
    [SerializeField] private float delayBumpEstrela;
    [Space(3)]
    [SerializeField] private AudioSource mainAudioSource;    
    [Space(3)]
    [SerializeField] private AudioClip somBackground;
    [SerializeField] private AudioClip somCliqueBotao;
    [SerializeField] private AudioClip somBumpEstrelas;
    [SerializeField] private AudioClip somGarra;

    public float DelayInicioSomGarra { get { return delayInicioSomGarra; } }
    public float DelayStopSomGarra { get { return delayStopSomGarra; } }

    public float DelayBumpTexto1 { get { return delayBumpTexto1; } }
    public float DelayBumpTexto2 { get { return delayBumpTexto2; } }
    public float DelayBumpTexto3 { get { return delayBumpTexto3; } }
    public float DelayBumpEstrela { get { return delayBumpEstrela; } }

    public AudioSource MainAudioSource { get { return mainAudioSource; } }
    public GameObject GoAudioSource { get { return mainAudioSource.gameObject; } }

    public AudioClip SomBackground { get { return somBackground; } }
    public AudioClip SomCliqueBotao { get { return somCliqueBotao; } }
    public AudioClip SomBumpEstrelas { get { return somBumpEstrelas; } }
    public AudioClip SomGarra { get { return somGarra; } }

}
