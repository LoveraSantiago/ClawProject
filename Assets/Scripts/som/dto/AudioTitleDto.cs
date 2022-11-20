using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class AudioTitleDto : AudioDto
{
    [Space(3)]
    [SerializeField] private float delayInicioSomGarra;
    [SerializeField] private float delayStopSomGarra;
    [Space(3)]
    [SerializeField] private float delayBumpTexto1;
    [SerializeField] private float delayBumpTexto2;
    [SerializeField] private float delayBumpTexto3;
    [SerializeField] private float delayBumpEstrela;
    [Space(3)]
    [Space(3)]
    [SerializeField] private AudioClipDto somBackground;
    [SerializeField] private AudioClipDto somBumpTexto;
    [SerializeField] private AudioClipDto somStart;
    [SerializeField] private AudioClipDto somBumpEstrelas;

    public float DelayInicioSomGarra { get { return delayInicioSomGarra; } }
    public float DelayStopSomGarra { get { return delayStopSomGarra; } }

    public float DelayBumpTexto1 { get { return delayBumpTexto1; } }
    public float DelayBumpTexto2 { get { return delayBumpTexto2; } }
    public float DelayBumpTexto3 { get { return delayBumpTexto3; } }
    public float DelayBumpEstrela { get { return delayBumpEstrela; } }

    public AudioClipDto SomBackground { get { return somBackground; } }
    public AudioClipDto SomBumpTexto { get { return somBumpTexto; } }
    public AudioClipDto SomBumpEstrelas { get { return somBumpEstrelas; } }
    public AudioClipDto SomStart { get { return somStart; } }
}
