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
    [SerializeField] private AudioClipDto somBackground;
    [SerializeField] private AudioClipDto somCliqueBotao;
    [SerializeField] private AudioClipDto somBumpEstrelas;
    [SerializeField] private AudioClipDto somGarra;
    [SerializeField] private AudioClipDto somBatidaAbrirModal;

    public float DelayInicioSomGarra { get { return delayInicioSomGarra; } }
    public float DelayStopSomGarra { get { return delayStopSomGarra; } }

    public float DelayBumpTexto1 { get { return delayBumpTexto1; } }
    public float DelayBumpTexto2 { get { return delayBumpTexto2; } }
    public float DelayBumpTexto3 { get { return delayBumpTexto3; } }
    public float DelayBumpEstrela { get { return delayBumpEstrela; } }

    public AudioSource MainAudioSource { get { return mainAudioSource; } }
    public GameObject GoAudioSource { get { return mainAudioSource.gameObject; } }

    public AudioClipDto SomBackground { get { return somBackground; } }
    public AudioClipDto SomCliqueBotao { get { return somCliqueBotao; } }
    public AudioClipDto SomBumpEstrelas { get { return somBumpEstrelas; } }
    public AudioClipDto SomGarra { get { return somGarra; } }
    public AudioClipDto SomBatidaAbrirModal { get { return somBatidaAbrirModal; } }

}
